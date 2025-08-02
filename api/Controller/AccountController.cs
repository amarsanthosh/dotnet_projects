using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controller
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenservice;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenservice = tokenService;
            _signInManager = signInManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };
                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password!);
                if (createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                Username = appUser.UserName,
                                Email = appUser.Email,
                                Token = await _tokenservice.createToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(400, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.userName!.ToLower());
            if (user == null) return Unauthorized("Invalid user");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password!, false);
            if (!result.Succeeded) return Unauthorized("Username/password incorrect");

            var refreshToken = _tokenservice.GenerateRefreshToken(HttpContext.Connection.RemoteIpAddress!.ToString());
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            Response.Cookies.Append("refreshToken", refreshToken.Token, new CookieOptions
            {
                // Secure = true,
                // SameSite = SameSiteMode.Strict,
                HttpOnly = true,
                Expires = refreshToken.Expires
            });

            return Ok(
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = await _tokenservice.createToken(user)
                }
            );
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var user = await _userManager.Users.Include(u => u.RefreshTokens)
                                                .SingleOrDefaultAsync(u => u.RefreshTokens.Any(i => i.Token == refreshToken));

            if (user == null)
            {
                return Unauthorized("Invalid Refresh Token");
            }

            var token = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken);
            if (!token!.IsActive)
            {
                return Unauthorized("Token is not Active, Expired/Revoked");
            }

            //Now we Rotate the Refresh Token {assigning the new one for extra security}

            var remoteIp = HttpContext.Connection.RemoteIpAddress!.ToString();

            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = remoteIp;

            var newRefreshToken = _tokenservice.GenerateRefreshToken(remoteIp);
            user.RefreshTokens.Add(newRefreshToken);

            await _userManager.UpdateAsync(user);
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, new CookieOptions
            {
                // Secure = true,
                // SameSite = SameSiteMode.Strict,
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            });

            var newAccessToken = await _tokenservice.createToken(user);

            return Ok(new
            {
                Token = newAccessToken
            });
        }
               
    }
}
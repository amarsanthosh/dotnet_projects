using api.Data;
using api.Interface;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity< AppUser,IdentityRole>(Options =>
{
    Options.Password.RequireDigit = true;
    Options.Password.RequiredLength = 8;
    Options.Password.RequireLowercase = true;
    Options.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

var jwtSettings = builder.Configuration.GetSection("Jwt"); 
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme =
    Options.DefaultChallengeScheme =
    Options.DefaultForbidScheme =
    Options.DefaultScheme =
    Options.DefaultSignInScheme =
    Options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(Options =>
{
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(jwtSettings["Signingkey"]!)
        )
    }; 
} ); 

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // optional UI to test endpoints
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization(); 
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

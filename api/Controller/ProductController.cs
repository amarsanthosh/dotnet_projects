using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using api.Dtos;
using api.Mapper;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace api.Controller
{

    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepo.GetAllProducts();
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productRepo.GetProductById(id);
            if (product == null) return BadRequest("Product not found"); 
            return Ok(product); 
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProducts([FromBody] CreateDto dto)
        {
            var productModel = dto.ToProductFromCreateDto();
            await _productRepo.CreateProducts(productModel);
            return Ok("Successfully Created");
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateProducts([FromRoute] int id, [FromBody] UpdateDto dto)
        {
            var productModel = dto.ToProductFromUpdateDto();
            var product = await _productRepo.UpdateProducts(id, productModel);
            if (product == null)
            {
                return BadRequest("Product Not Found !!");
            }

            return Ok("Successfully Updated");
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            var product = await _productRepo.DeleteProducts(id);
            if (product == null)
            {
                return BadRequest("Product not found!!");
            }
            return Ok("Successfully Deleted");
        }
    }
}
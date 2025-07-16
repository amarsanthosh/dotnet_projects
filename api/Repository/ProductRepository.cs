using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> CreateProducts(Products productmodel)
        {
            await _context.Products.AddAsync(productmodel);
            await _context.SaveChangesAsync();
            return productmodel;
        }

        public async Task<Products?> UpdateProducts(int id, Products productmodel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (product == null)
            {
                return null;
            }
            product.CompanyName = productmodel.CompanyName;
            product.Price = productmodel.Price;
            product.ProductName = productmodel.ProductName;
            product.SellerName = productmodel.SellerName;
            product.Availability = productmodel.Availability;

            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<Products?> DeleteProducts(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();

            return product;
        }
    
    }
}
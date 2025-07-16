using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface IProductRepository
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> CreateProducts(Products productmodel);

        Task<Products?> UpdateProducts(int id, Products productmodel);
        Task<Products?> DeleteProducts(int id); 
    }
}
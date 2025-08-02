using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Mapper
{
    public static class ProductMapper
    {
        public static Products ToProductFromCreateDto(this CreateDto productModel)
        {
            return new Products
            {
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                SellerName = productModel.SellerName,
                Availability = productModel.Availability
            };
        }
        public static Products ToProductFromUpdateDto(this UpdateDto productModel)
        {
            return new Products
            {
                ProductName = productModel.ProductName,
                Price = productModel.Price,
                SellerName = productModel.SellerName,
                Availability = productModel.Availability
            };
        }

    }
}
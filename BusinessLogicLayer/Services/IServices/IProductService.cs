using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProducts();
        Task<ProductResponse?> GetProductByCondition(int id);
        Task<ProductResponse> AddProduct(ProductAddRequest productAddRequest);
        Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);
        Task<bool> DeleteProduct(int id);
    }
}

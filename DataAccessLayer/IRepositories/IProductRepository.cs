using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductByCondition(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);

    }
}

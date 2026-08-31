using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class ProductsRepository(AppDbContext _db) : IProductRepository
    {
        public async Task<Product> AddProduct(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByCondition(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
    }
}

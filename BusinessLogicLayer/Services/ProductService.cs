using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Services.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class ProductService(IProductRepository _productRepository, IMapper _mapper) : IProductService
    {
        public async Task<ProductResponse> AddProduct(ProductAddRequest productAddRequest)
        {
            var product = _mapper.Map<Product>(productAddRequest);

            var createdProduct = await _productRepository.AddProduct(product);

            return _mapper.Map<ProductResponse>(createdProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product? product = await _productRepository.GetProductByCondition(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id {id} not found");

            }
            await _productRepository.DeleteProduct(product);
            return true;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public async Task<ProductResponse?> GetProductByCondition(int id)
        {
            var product = await _productRepository.GetProductByCondition(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with id {id} not found");
            }
            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            var existingsProduct = await _productRepository.GetProductByCondition(productUpdateRequest.Id);
            if (existingsProduct == null)
            {
                throw new NotFoundException($"Product with id {productUpdateRequest.Id} not found");
            }
            _mapper.Map(productUpdateRequest, existingsProduct);
            var updatedProduct = await _productRepository.UpdateProduct(existingsProduct);
            return _mapper.Map<ProductResponse>(updatedProduct);
        }
    }
}

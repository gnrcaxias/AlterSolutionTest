using AlterSolutionTest.Domain.Entities;
using AlterSolutionTest.Domain.Repositories;
using AlterSolutionTest.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlterSolutionTest.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProduct(Product product)
        {
            product.Id = 0;
            return await _productRepository.InsertProduct(product);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }

        public async Task<int> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<IEnumerable<Product>> GetPage(int page, int pageSize)
        {
            return await _productRepository.GetPage(page, pageSize);
        }
    }
}

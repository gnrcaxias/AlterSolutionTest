using AlterSolutionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterSolutionTest.Domain.Services
{
    public interface IProductService
    {
        Task<int> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<int> DeleteProduct(int id);
        Task<int> UpdateProduct(Product product);
        Task<IEnumerable<Product>> GetPage(int page, int pageSize);
    }
}

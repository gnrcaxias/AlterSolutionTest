using AlterSolutionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterSolutionTest.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<int> DeleteProduct(int id);
        Task<int> InsertProduct(Product entity);
        Task<int> UpdateProduct(Product entity);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetPage(int page, int pageSize);
    }
}

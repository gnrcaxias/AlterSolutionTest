using AlterSolutionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterSolutionTest.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<int> Delete(int id);
        Task<int> Insert(Product entity);
        Task<int> Update(Product entity);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetPage(int page, int pageSize);
    }
}

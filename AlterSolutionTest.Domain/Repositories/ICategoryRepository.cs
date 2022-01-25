using AlterSolutionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterSolutionTest.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<int> Delete(int id);
        Task<int> Insert(Category entity);
        Task<int> Update(Category entity);
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetPage(int page, int pageSize);
    }
}

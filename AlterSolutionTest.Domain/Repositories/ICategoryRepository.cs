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
        Task<int> DeleteCategory(int id);
        Task<int> InsertCategory(Category entity);
        Task<int> UpdateCategory(Category entity);
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetPage(int page, int pageSize);
    }
}

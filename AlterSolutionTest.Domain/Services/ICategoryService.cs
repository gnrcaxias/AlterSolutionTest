using AlterSolutionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterSolutionTest.Domain.Services
{
    public interface ICategoryService
    {
        Task<int> CreateCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<int> DeleteCategory(int id);
        Task<int> UpdateCategory(Category category);
        Task<IEnumerable<Category>> GetPage(int page, int pageSize);
    }
}

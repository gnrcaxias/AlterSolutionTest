using AlterSolutionTest.Domain.Entities;
using AlterSolutionTest.Domain.Repositories;
using AlterSolutionTest.Repository.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterSolutionTest.Repository.SqlServer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlServerAlterSolutionContext _dbContext;

        public CategoryRepository(SqlServerAlterSolutionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            _dbContext.Entry(category).State = EntityState.Deleted;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _dbContext.Set<Category>().FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetPage(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await Task.Run(() => _dbContext.Category.Skip(skip).Take(pageSize).ToList());
        }

        public async Task<int> InsertCategory(Category entity)
        {
            _dbContext.Category.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateCategory(Category entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}

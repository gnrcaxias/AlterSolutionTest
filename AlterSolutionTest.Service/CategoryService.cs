using AlterSolutionTest.Domain.Entities;
using AlterSolutionTest.Domain.Repositories;
using AlterSolutionTest.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlterSolutionTest.Service
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateCategory(Category category)
        {
            category.Id = 0;
            return await _categoryRepository.Insert(category);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.Get(id);
        }

        public async Task<int> DeleteCategory(int id)
        {
            return await _categoryRepository.Delete(id);
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return await _categoryRepository.Update(category);
        }

        public async Task<IEnumerable<Category>> GetPage(int page, int pageSize)
        {
            return await _categoryRepository.GetPage(page, pageSize);
        }
    }
}

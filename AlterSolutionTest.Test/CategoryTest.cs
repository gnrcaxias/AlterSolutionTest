using AlterSolutionTest.App.Controllers;
using AlterSolutionTest.Domain.Entities;
using AlterSolutionTest.Repository.SqlServer.Context;
using AlterSolutionTest.Repository.SqlServer.Repositories;
using AlterSolutionTest.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AlterSolutionTest.Test
{
    public class CategoryTest
    {
        private readonly CategoryController _categoryController;


        public CategoryTest(ITestOutputHelper output)
        {
            var dbContext = new SqlServerAlterSolutionContext();
            var categoryRepository = new CategoryRepository(dbContext);
            var categoryApplication = new CategoryService(categoryRepository);
            _categoryController = new CategoryController(categoryApplication);
        }

        [Fact]
        public async Task MustGetCategoryById()
        {
            var category = new Domain.Entities.Category() { Description = "Categoria 5", Active = 1 };
            await _categoryController.Insert(category);

            var actual = (_categoryController.Get(category.Id).Result as OkObjectResult).StatusCode;
            var expected = new OkResult().StatusCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task MustCreateCategory()
        {
            var category = new Domain.Entities.Category() { Description = "Categoria 6", Active = 1 };
            var actual = (_categoryController.Insert(category).Result as OkObjectResult).StatusCode;
            var expected = new OkResult().StatusCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task MustUpdateCategory()
        {
            var category = new Domain.Entities.Category() { Description = "Categoria 7", Active = 1 };
            await _categoryController.Insert(category);

            category.Description = string.Concat("Categoria", new Random().Next(1, 10000).ToString());

            var act = (_categoryController.Update(category).Result as OkObjectResult).StatusCode;
            var exp = new OkResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Fact]
        public async Task MustDeleteCategory()
        {
            var category = new Domain.Entities.Category() { Description = "Categoria 8", Active = 1 };
            await _categoryController.Insert(category);

            var act = _categoryController.Delete(category.Id).Result as OkObjectResult;
            var exp = new OkResult().StatusCode;

            Assert.Equal(exp, act.StatusCode);
        }
    }
}

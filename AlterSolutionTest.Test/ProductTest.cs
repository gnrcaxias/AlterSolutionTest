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
    public class ProductTest
    {
        private readonly ProductController _ProductController;


        public ProductTest(ITestOutputHelper output)
        {
            var dbContext = new SqlServerAlterSolutionContext();
            var productRepository = new ProductRepository(dbContext);
            var ProductApplication = new ProductService(productRepository);
            _ProductController = new ProductController(ProductApplication);
        }

        [Fact]
        public async Task MustGetProductById()
        {
            var Product = new Domain.Entities.Product() { Description = "Produto 01", Active = 1, Code = "C01", Dimensions = "1x1", Reference = "R01", Price = 10, InventoryBalance = 10, Category = new Category { Description = "Categoria Teste", Active = 1 } };
            await _ProductController.Insert(Product);

            var actual = (_ProductController.Get(Product.Id).Result as OkObjectResult).StatusCode;
            var expected = new OkResult().StatusCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task MustCreateProduct()
        {
            var Product = new Domain.Entities.Product() { Description = "Produto 01", Active = 1, Code = "C01", Dimensions = "1x1", Reference = "R01", Price = 10, InventoryBalance = 10, Category = new Category { Description = "Categoria Teste", Active = 1 } };
            var actual = (_ProductController.Insert(Product).Result as OkObjectResult).StatusCode;
            var expected = new OkResult().StatusCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task MustUpdateProduct()
        {
            var Product = new Domain.Entities.Product() { Description = "Produto 01", Active = 1, Code = "C01", Dimensions = "1x1", Reference = "R01", Price = 10, InventoryBalance = 10, Category = new Category { Description = "Categoria Teste", Active = 1 } };
            await _ProductController.Insert(Product);

            Product.Description = string.Concat("Product", new Random().Next(1, 10000).ToString());

            var act = (_ProductController.Update(Product).Result as OkObjectResult).StatusCode;
            var exp = new OkResult().StatusCode;

            Assert.Equal(exp, act);
        }

        [Fact]
        public async Task MustDeleteProduct()
        {
            var Product = new Domain.Entities.Product() { Description = "Produto 01", Active = 1, Code = "C01", Dimensions = "1x1", Reference = "R01", Price = 10, InventoryBalance = 10, Category = new Category { Description = "Categoria Teste", Active = 1 } };
            await _ProductController.Insert(Product);

            var act = _ProductController.Delete(Product.Id).Result as OkObjectResult;
            var exp = new OkResult().StatusCode;

            Assert.Equal(exp, act.StatusCode);
        }
    }
}

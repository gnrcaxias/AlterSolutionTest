using AlterSolutionTest.Domain.Repositories;
using AlterSolutionTest.Domain.Services;
using AlterSolutionTest.Repository.SqlServer.Context;
using AlterSolutionTest.Repository.SqlServer.Repositories;
using AlterSolutionTest.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlterSolutionTest.App
{
    public static class DependencyInjector
    {
        public static void RegisterDependencyInjectionContainers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerAlterSolutionContext>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}

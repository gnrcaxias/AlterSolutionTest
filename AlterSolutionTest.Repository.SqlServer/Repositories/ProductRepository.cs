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
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerAlterSolutionContext _dbContext;

        public ProductRepository(SqlServerAlterSolutionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            var product = await Get(id);
            _dbContext.Entry(product).State = EntityState.Deleted;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetPage(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await Task.Run(() => _dbContext.Product.Skip(skip).Take(pageSize).ToList());
        }

        public async Task<int> Insert(Product entity)
        {
            _dbContext.Product.Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(Product entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}

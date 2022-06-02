
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanA_Assessment.Domain;
using PlanA_Assessment.Application.Contracts;

namespace PlanA_Assessment.Presistence
{
    public class ProductRepository : BaseRepository<Product>, IProductsRepository
    {
        public ProductRepository(ProductDbContext postDbContext): base(postDbContext)
        {

        }
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync(bool includeCategory)
        {
            List<Product> allProducts = new List<Product>();
            allProducts = includeCategory ? await _dbContext.Products.Include(x => x.Category).ToListAsync() : await _dbContext.Products.ToListAsync();
            return allProducts;
        }

        public async Task<Product> GetProductByIdAsync(Guid id, bool includeCategory)
        {
            Product Post = new Product();
            Post = includeCategory ? await _dbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ID == id) : await GetByIdAsync(id);
            return Post;
        }
    }

}

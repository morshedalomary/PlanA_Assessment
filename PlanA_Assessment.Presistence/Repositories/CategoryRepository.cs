
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanA_Assessment.Domain;
using PlanA_Assessment.Application.Contracts;

namespace PlanA_Assessment.Presistence
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext postDbContext) : base(postDbContext)
        {

        }
        public async Task<IReadOnlyList<Category>> GetAllCategoryAsync()
        {
            List<Category> allCategorys = new List<Category>();
            allCategorys = await _dbContext.Categorys.ToListAsync();
            return allCategorys;
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            Category category  = new Category();
            category =  await GetByIdAsync(id);
            return category;
        }
    }

}

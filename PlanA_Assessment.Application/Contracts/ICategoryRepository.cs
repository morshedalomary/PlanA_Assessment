using PlanA_Assessment.Domain;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Contracts
{
   public   interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(Guid id );
    }
}

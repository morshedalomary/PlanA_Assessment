using PlanA_Assessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanA_Assessment.Application.Contracts
{
   public   interface IProductsRepository : IAsyncRepository<Product>
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync(bool includeCategory);
        Task<Product> GetProductByIdAsync(Guid id , bool includeCategory);
        Task<IReadOnlyList<Product>> GetProductBySearch(string  text, bool includeCategory);

    }
}

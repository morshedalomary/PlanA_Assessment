

using System;
using Microsoft.EntityFrameworkCore;
using PlanA_Assessment.Domain;

namespace PlanA_Assessment.Presistence
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var postGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                ID = categoryGuid,
                Name = "Technology"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = postGuid,
                Title = "Introduction to CQRS and Mediator Patterns",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
                Image = "https://api.khalidessaadani.com/uploads/articles_bg.jpg",
                CategoryId = categoryGuid
            });

        }
    }

}

using AutoMapper;
using PlanA_Assessment.Application.Features.Products.Commands.CreateProduct;
using PlanA_Assessment.Application.Features.Products.Commands.DeleteProduct;
using PlanA_Assessment.Application.Features.Products.Commands.UpdateProduct;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductDetail;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductList;
using PlanA_Assessment.Domain;


namespace PlanA_Assessment.Application.Profiles

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductsListViewModel>().ReverseMap();
            CreateMap<Product, GetProductDetailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();
        }
    }
}

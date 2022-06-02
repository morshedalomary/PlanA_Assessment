using AutoMapper;
using PlanA_Assessment.Application.Features.Category.Queries.GetCategoryDetail;
using PlanA_Assessment.Application.Features.Categorys.Commands.CreateCategory;
using PlanA_Assessment.Application.Features.Categorys.Commands.DeleteCategory;
using PlanA_Assessment.Application.Features.Categorys.Commands.UpdateCategory;
using PlanA_Assessment.Application.Features.Categorys.Queries.GetCategoryList;
using PlanA_Assessment.Application.Features.Products.Commands.CreateProduct;
using PlanA_Assessment.Application.Features.Products.Commands.DeleteProduct;
using PlanA_Assessment.Application.Features.Products.Commands.SearchProduct;
using PlanA_Assessment.Application.Features.Products.Commands.UpdateProduct;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductDetail;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductList;
using PlanA_Assessment.Application.Features.Products.Queries.GetProductListBySearch;
using PlanA_Assessment.Domain;


namespace PlanA_Assessment.Application.Profiles

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductsListViewModel>().ReverseMap();
            CreateMap<Product, GetProductDetailViewModel>().ReverseMap();
            CreateMap<Product, GetProductsListSearchViewModel>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();

            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();

            

            CreateMap<Category, GetCategorysListViewModel>().ReverseMap();
            CreateMap<Category, GetCategoryDetailViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
        }
    }
}

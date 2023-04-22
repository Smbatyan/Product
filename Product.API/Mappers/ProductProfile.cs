using AutoMapper;
using Product.API.Contracts.Request.Product;
using Product.API.Contracts.Response;
using Product.API.Entities;

namespace Product.API.Mappers;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductResponse>();
        CreateMap<CreateProductRequest, ProductEntity>();
    }
}
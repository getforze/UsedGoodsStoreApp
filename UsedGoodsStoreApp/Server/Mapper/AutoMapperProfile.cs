using AutoMapper;
using DatabaseSchemaManager.Models;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Server.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DatabaseSchemaManager.Models.Attribute1, AttributeDTO>();
            CreateMap<AttributeDTO, DatabaseSchemaManager.Models.Attribute1>();
            CreateMap<AttributeProduct, AttributeProductDTO>();
            CreateMap<AttributeProductDTO, AttributeProduct>();
            CreateMap<AttributeValue, AttributeValueDTO>();
            CreateMap<AttributeValueDTO, AttributeValue>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>();
            CreateMap<OrderStatus, OrderStatusDTO>();
            CreateMap<OrderStatusDTO, OrderStatus>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<ProductImages, ProductImagesDTO>();
            CreateMap<ProductImagesDTO, ProductImages>();
        }
    }
}

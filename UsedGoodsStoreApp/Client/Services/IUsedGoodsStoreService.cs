using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Services
{
    public interface IUsedGoodsStoreService
    {
        Task<List<AttributeDTO>> GetAttributesList();
        Task<List<AttributeProductDTO>> GetAttributesProductList(int productId);
        Task<List<ProductDTO>> GetProductsInCategory(int categoryId);
        Task<RequestResult> CreateOrder(OrderDTO order);
        Task<RequestResult> UpdateProductImages(MultipartFormDataContent updateProductImages);
        Task<List<OrderDTO>> GetOrders();
        Task<RequestResult> CreateAttributeProduct(AttributeProductRequest attributeProductRequest);
        Task<RequestResult> UpdateOrder(UpdateOrderRequest updateOrderRequest);
        Task<List<OrderDTO>> GetUserOrders(int userId);
        Task<List<ProductDTO>> GetLastProducts();
        Task<RequestResult> DeleteAttribute(DeleteAttributeRequest deleteAttributeRequest);
        Task<RequestResult> UpdateAttribute(UpdateAttributeRequest updateAttributeRequest);
        Task<RequestResult> AddAttribute(AddAttributeRequest addAttributeRequest);
        Task<RequestResult> AddCategory(AddCategoryRequest addCategoryRequest);
        Task<RequestResult> UpdateCategory(UpdateCategoryRequest updateCategoryRequest);
        Task<RequestResult> DeleteCategory(DeleteCategoryRequest deleteCategoryRequest);
        Task<RequestResult> AddProduct(AddProductRequest addProductRequest);
        Task<RequestResult> DeleteProduct(DeleteProductRequest deleteProductRequest);
        Task<RequestResult> UpdateProduct(UpdateProductRequest updateProductRequest);
        Task<List<CategoryDTO>> GetCategoriesList();
        Task<List<ProductDTO>> GetProductsList();
    }
}

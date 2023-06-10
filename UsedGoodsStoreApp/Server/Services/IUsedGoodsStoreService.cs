using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Server.Services
{
    public interface IUsedGoodsStoreService
    {
        Task<RequestResult> AddAttribute(AddAttributeRequest request);
        Task<RequestResult> UpdateAttribute(UpdateAttributeRequest request);
        Task<List<AttributeDTO>> GetAttributesList();
        Task<RequestResult> DeleteAttribute(int idAttribute);
        Task<List<ProductDTO>> GetProductsList();
        Task<List<CategoryDTO>> GetCategoriesList();
        Task<List<AttributeProductDTO>> GetAttributesProduct(int productId);
        Task<List<ProductDTO>> GetProductsInCategory(int categoryId);
        Task<RequestResult> CreateOrder(OrderDTO request);
        Task<RequestResult> UpdateProductImages(IEnumerable<IFormFile> files);
        Task<RequestResult> UpdateCategory(UpdateCategoryRequest request);
        Task<RequestResult> DeleteCategory(int idCattegory);
        Task<RequestResult> AddCategory(AddCategoryRequest request);
        Task<RequestResult> UpdateProduct(UpdateProductRequest request);
        Task<RequestResult> AddProduct(AddProductRequest request);
        Task<RequestResult> DeleteProduct(int idProduct);
        Task<RequestResult> CreateAttributeProduct(AttributeProductRequest request);
        Task<List<OrderDTO>> GetOrders();
        Task<RequestResult> UpdateOrder(UpdateOrderRequest request);
        Task<List<OrderDTO>> GetUserOrders(int userId);
        Task<List<ProductDTO>> GetLastProducts(int quantity = 10);
    }
}

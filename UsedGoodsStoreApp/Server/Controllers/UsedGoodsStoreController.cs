using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UsedGoodsStoreApp.Server.Services;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace Gotec.GoWell.GRecipe.Server;

[ApiController]
[Route($"{Routes.MainModuleRoute}/[action]")]
public class UsedGoodsStoreController : ControllerBase
{
    private readonly IUsedGoodsStoreService _usedGoodsStoreService;
    public UsedGoodsStoreController(IUsedGoodsStoreService usedGoodsStoreService)
    {
        _usedGoodsStoreService = usedGoodsStoreService;
    }

    [HttpPost]
    public async Task<RequestResult> AddAttribute(AddAttributeRequest request)
    {

        return await Handle(() => _usedGoodsStoreService.AddAttribute(request));
    }
    [HttpPost]
    public async Task<RequestResult> UpdateAttribute(UpdateAttributeRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.UpdateAttribute(request));
    }
    [HttpPost]
    public async Task<RequestResult> DeleteAttribute(DeleteAttributeRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.DeleteAttribute(request.AttributeId));
    }
    [HttpGet]
    public async Task<List<AttributeDTO>> GetAttributesList()
    {
        return await _usedGoodsStoreService.GetAttributesList();
    }
    [HttpGet]
    public async Task<List<CategoryDTO>> GetCategoriesList()
    {
        return await _usedGoodsStoreService.GetCategoriesList();
    }
    [HttpGet]
    public async Task<List<ProductDTO>> GetProductsList()
    {
        return await _usedGoodsStoreService.GetProductsList();
    }
    [HttpGet]
    public async Task<List<OrderDTO>> GetOrders()
    {
        return await _usedGoodsStoreService.GetOrders();
    }
    [HttpGet("{productId}")]
    public async Task<List<AttributeProductDTO>> GetAttributesProductList(int productId)
    {
        return await _usedGoodsStoreService.GetAttributesProduct(productId);
    }
    [HttpGet("{userId}")]
    public async Task<List<OrderDTO>> GetUserOrders(int userId)
    {
        return await _usedGoodsStoreService.GetUserOrders(userId);
    }
    [HttpGet("{categoryId}")]
    public async Task<List<ProductDTO>> GetProductsInCategory(int categoryId)
    {
        return await _usedGoodsStoreService.GetProductsInCategory(categoryId);
    }
    [HttpGet]
    public async Task<List<ProductDTO>> GetLastProducts()
    {
        return await _usedGoodsStoreService.GetLastProducts();
    }
    [HttpPost]
    public async Task<RequestResult> CreateAttributeProduct(AttributeProductRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.CreateAttributeProduct(request));
    }
    [HttpPost]
    public async Task<RequestResult> DeleteCategory(DeleteCategoryRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.DeleteCategory(request.CategoryId));
    }
    [HttpPost]
    public async Task<RequestResult> DeleteProduct(DeleteProductRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.DeleteProduct(request.ProductId));
    }
    [HttpPost]
    public async Task<RequestResult> AddProduct(AddProductRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.AddProduct(request));
    }
    [HttpPost]
    public async Task<RequestResult> UpdateProduct(UpdateProductRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.UpdateProduct(request));
    }
    [HttpPost]
    public async Task<RequestResult> UpdateCategory(UpdateCategoryRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.UpdateCategory(request));
    }
    [HttpPost]
    public async Task<RequestResult> AddCategory(AddCategoryRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.AddCategory(request));
    }
    [HttpPost]
    public async Task<RequestResult> CreateOrder(OrderDTO request)
    {
        return await Handle(() => _usedGoodsStoreService.CreateOrder(request));
    }
    [HttpPost]
    public async Task<RequestResult> UpdateProductImages([FromForm] IEnumerable<IFormFile> files)
    {
        return await Handle(() => _usedGoodsStoreService.UpdateProductImages(files));
    }
    [HttpPost]
    public async Task<RequestResult> UpdateOrder(UpdateOrderRequest request)
    {
        return await Handle(() => _usedGoodsStoreService.UpdateOrder(request));
    }
    private async Task<RequestResult> Handle(Func<Task> taskFunc)
    {
        try
        {
            await taskFunc.Invoke();
            return RequestResult.Success();
        }
        catch (Exception ex)
        {
            return RequestResult.Failure(ex);
        }
    }
}

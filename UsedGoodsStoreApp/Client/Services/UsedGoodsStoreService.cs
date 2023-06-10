using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Services
{
    public class UsedGoodsStoreService : IUsedGoodsStoreService
    {
        private readonly IHttpService _httpService;
        private readonly ISnackbar _snackbar;

        public UsedGoodsStoreService(IHttpService httpService, ISnackbar snackbar)
        {
            _httpService = httpService;
            _snackbar = snackbar;
        }

        public async Task<List<AttributeDTO>> GetAttributesList()
        {
            try
            {

                var list = await _httpService.Get<List<AttributeDTO>>($"{Routes.MainModuleRoute}/GetAttributesList");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<AttributeDTO>();
            }
        }
        public async Task<List<CategoryDTO>> GetCategoriesList()
        {
            try
            {

                var list = await _httpService.Get<List<CategoryDTO>>($"{Routes.MainModuleRoute}/GetCategoriesList");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<CategoryDTO>();
            }
        }
        public async Task<List<ProductDTO>> GetProductsList()
        {
            try
            {

                var list = await _httpService.Get<List<ProductDTO>>($"{Routes.MainModuleRoute}/GetProductsList");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<ProductDTO>();
            }
        }
        public async Task<List<OrderDTO>> GetOrders()
        {
            try
            {

                var list = await _httpService.Get<List<OrderDTO>>($"{Routes.MainModuleRoute}/GetOrders");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<OrderDTO>();
            }
        }
        public async Task<List<OrderDTO>> GetUserOrders(int userId)
        {
            try
            {
                var list = await _httpService.Get<List<OrderDTO>>($"{Routes.MainModuleRoute}/GetUserOrders/{userId}");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<OrderDTO>();
            }
        }
        public async Task<List<AttributeProductDTO>> GetAttributesProductList(int productId)
        {
            try
            {

                var list = await _httpService.Get<List<AttributeProductDTO>>($"{Routes.MainModuleRoute}/GetAttributesProductList/{productId}");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<AttributeProductDTO>();
            }
        }
        public async Task<List<ProductDTO>> GetProductsInCategory(int categoryId)
        {
            try
            {

                var list = await _httpService.Get<List<ProductDTO>>($"{Routes.MainModuleRoute}/GetProductsInCategory/{categoryId}");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<ProductDTO>();
            }
        }
        public async Task<List<ProductDTO>> GetLastProducts()
        {
            try
            {

                var list = await _httpService.Get<List<ProductDTO>>($"{Routes.MainModuleRoute}/GetLastProducts");
                return list;
            }
            catch (Exception ex)
            {
                _snackbar.Add(ex.Message, Severity.Error);
                return new List<ProductDTO>();
            }
        }
        public async Task<RequestResult> DeleteAttribute(DeleteAttributeRequest deleteAttributeRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/DeleteAttribute" , deleteAttributeRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/deleteProductRequest" , deleteProductRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> UpdateAttribute(UpdateAttributeRequest updateAttributeRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/UpdateAttribute", updateAttributeRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> AddAttribute(AddAttributeRequest addAttributeRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/AddAttribute", addAttributeRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> AddCategory(AddCategoryRequest addCategoryRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/AddCategory", addCategoryRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> AddProduct(AddProductRequest addProductRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/AddProduct", addProductRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/UpdateCategory", updateCategoryRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/UpdateProduct", updateProductRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> CreateOrder(OrderDTO order)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/CreateOrder", order);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add("Zamówienie dodane", Severity.Success);
            return result;
        }
        public async Task<RequestResult> DeleteCategory(DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/DeleteCategory", deleteCategoryRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> UpdateProductImages(MultipartFormDataContent file)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/UpdateProductImages", file);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> CreateAttributeProduct(AttributeProductRequest attributeProductRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/CreateAttributeProduct", attributeProductRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
        public async Task<RequestResult> UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var result = await _httpService.Post<RequestResult>($"{Routes.MainModuleRoute}/UpdateOrder", updateOrderRequest);
            if (result.Failed)
                _snackbar.Add(result.ErrorCode, Severity.Error);
            else
                _snackbar.Add(result.SuccessCode, Severity.Success);
            return result;
        }
    }
}

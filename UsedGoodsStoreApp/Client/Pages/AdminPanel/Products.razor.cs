using MudBlazor;
using UsedGoodsStoreApp.Client.Components.AdminPanel;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages.AdminPanel
{
    public partial class Products
    {
        List<ProductDTO> ProductsList = new List<ProductDTO>();
        private bool _loading;
        protected override async Task OnInitializedAsync()
        {
            await DownloadData();
        }
        public async Task DownloadData()
        {
            _loading = true;
            StateHasChanged();
            ProductsList = await UsedGoodsStoreService.GetProductsList() ?? new List<ProductDTO>();
            _loading = false;
            StateHasChanged();
        }
        public async Task AddProduct()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var result = await DialogService.Show<ProductCreator>("Stwórz", closeOnEscapeKey).Result;
            await DownloadData();
        }
        public async Task DeleteProduct(int idProduct)
        {
            await UsedGoodsStoreService.DeleteProduct(new DeleteProductRequest { ProductId = idProduct });
            await DownloadData();
        }
        public async Task UpdateProduct(ProductDTO product)
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(ProductEditor.Product), product);
            await DialogService.Show<ProductEditor>("Edycja", parameters, closeOnEscapeKey).Result;
            await DownloadData();
        }
        public async Task CofigureAttributes(ProductDTO product)
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, FullScreen=true , CloseButton = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(CofigureAttributesInProduct.Product), product);
            await DialogService.Show<CofigureAttributesInProduct>("Konfiguracja atrybutów", parameters, closeOnEscapeKey).Result;
            await DownloadData();
        }
        public async Task CofigureImages(ProductDTO product)
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true, FullScreen=true , CloseButton = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(ProductImagesEditor.Product), product);
            await DialogService.Show<ProductImagesEditor>("Konfiguracja zdjęć", parameters, closeOnEscapeKey).Result;
            await DownloadData();
        }
    }
}

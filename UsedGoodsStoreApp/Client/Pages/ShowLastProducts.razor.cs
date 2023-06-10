using Microsoft.AspNetCore.Components;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages
{
    public partial class ShowLastProducts
    {
        public ProductDTO Product { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        private bool _loading;
        protected override async Task OnInitializedAsync()
        {
            await DownloadData();
        }
        public async Task DownloadData()
        {
            _loading = true;
            StateHasChanged();
            Product = null;
            Products = await UsedGoodsStoreService.GetLastProducts();
            _loading = false;
            StateHasChanged();

        }
        public void GoBack()
        {
            Product = null;
            StateHasChanged();
        }
        public async Task SetProduct(ProductDTO product)
        {
            Product = product;
            StateHasChanged();
        }
    }
}

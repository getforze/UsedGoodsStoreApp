using Microsoft.AspNetCore.Components;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages
{
    public partial class ProductsInCategory
    {
        public ProductDTO Product { get; set; }
        private int categoryId;

        [Parameter]
        public int CategoryId
        {
            get => categoryId;
            set
            {
                categoryId = value;
                DownloadData();
            }
        }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        private bool _loading;
        public async Task DownloadData()
        {
            _loading = true;
            StateHasChanged();
            Product = null;
            Products = await UsedGoodsStoreService.GetProductsInCategory(CategoryId);
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

using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components
{
    public partial class ProductViewer
    {
        [Parameter]
        public ProductDTO Product { get; set; } = new ProductDTO();
        public void AddToCart()
        {
            var result = ShoppingCart.AddProductToCart(Product);
            if(!result)
                Snackbar.Add("Product jest już w koszyku", Severity.Error);
            else
                Snackbar.Add("Product dodano do koszyka", Severity.Success);

        }
    }
}

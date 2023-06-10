using MudBlazor;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages
{
    public partial class Cart
    {
        public void DeleteProduct(ProductDTO product)
        {
            var result = ShoppingCart.RemoveProductFromCart(product);
            if(!result)
                Snackbar.Add("Nie istnieje ten produkt w koszyku", Severity.Error);
            else
                Snackbar.Add("Usunięto produkt z koszyka", Severity.Success);

        }
        public void OrderProducts()
        {
            NavigationManager.NavigateTo("/orderProducts");
        }
    }
}

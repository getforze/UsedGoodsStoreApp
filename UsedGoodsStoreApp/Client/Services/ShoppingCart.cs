using MudBlazor;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Services
{
    public class ShoppingCart
    {
        //private readonly ISnackbar _snackbar;
        //
        //public ShoppingCart(ISnackbar snackbar)
        //{
        //    _snackbar = snackbar;
        //}

        public event Action OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public bool AddProductToCart(ProductDTO productDTO)
        {
            if(Products.Any(x => x.ProductId == productDTO.ProductId))
            {
                NotifyStateChanged();
                //_snackbar.Add("Product jest już w koszyku", Severity.Error);
                return false;
            }
            else
            {
                Products.Add(productDTO);
                NotifyStateChanged();
                return true;
                //_snackbar.Add("Product dodano do koszyka", Severity.Success);

            }
        }
        public bool RemoveProductFromCart(ProductDTO productDTO)
        {
            var product = Products.Where(x => x.ProductId == productDTO.ProductId).FirstOrDefault();
            if(product != null)
            {
                Products.Remove(product);
                NotifyStateChanged();
                return true;
                //_snackbar.Add("Usunięto produkt z koszyka", Severity.Success);
            }
            else
            {
                NotifyStateChanged();
                return false;
                //_snackbar.Add("Nie istnieje ten produkt w koszyku", Severity.Error);
            }
        }
    }
}

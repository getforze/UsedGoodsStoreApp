using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class ProductCreator
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public ProductDTO Product { get; set; }= new ProductDTO();
        List<CategoryDTO> CategoriesList = new List<CategoryDTO>();
        protected override async Task OnInitializedAsync()
        {
            CategoriesList = await UsedGoodsStoreService.GetCategoriesList() ?? new List<CategoryDTO>();
        }
        public async Task AddNewProduct()
        {
            var result = await UsedGoodsStoreService.AddProduct(new AddProductRequest { Name = Product.Name, Price = Product.Price, CategoryId = Product.CategoryId });
            if(!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }
    }
}

using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class ProductEditor
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public ProductDTO Product { get; set; }
        List<CategoryDTO> CategoriesList = new List<CategoryDTO>();
        protected override async Task OnInitializedAsync()
        {
            CategoriesList = await UsedGoodsStoreService.GetCategoriesList() ?? new List<CategoryDTO>();
            StateHasChanged();
        }
        public async Task EditProduct()
        {
            var result = await UsedGoodsStoreService.UpdateProduct(new UpdateProductRequest { ProductId = Product.ProductId , CategoryId = Product.CategoryId, Name = Product.Name, Price = Product.Price});
            if (!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }

    }
}

using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class CategoryEditor
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public CategoryDTO Category { get; set; }
        [Parameter]
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public async Task EditCategory()
        {
            var result = await UsedGoodsStoreService.UpdateCategory(new UpdateCategoryRequest { CategoryId = Category.CategoryId , Name = Category.Name , ParentCategoryId = Category.ParentCategoryId});
            if (!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }

    }
}

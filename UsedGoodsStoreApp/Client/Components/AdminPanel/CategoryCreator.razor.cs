using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class CategoryCreator
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public CategoryDTO Category { get; set; }= new CategoryDTO();
        public async Task AddNewCategory()
        {
            var result = await UsedGoodsStoreService.AddCategory(new AddCategoryRequest { Name = Category.Name, ParentCategoryId = Category.ParentCategoryId });
            if(!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }
    }
}

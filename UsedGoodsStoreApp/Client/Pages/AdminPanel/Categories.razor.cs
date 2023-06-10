using MudBlazor;
using UsedGoodsStoreApp.Client.Components.AdminPanel;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages.AdminPanel
{
    public partial class Categories
    {
        List<CategoryDTO> CategoriesList = new List<CategoryDTO>();
        private bool _loading;
        protected override async Task OnInitializedAsync()
        {
            await DownloadData();
        }
        public async Task DownloadData()
        {
            _loading = true;
            StateHasChanged();
            CategoriesList = await UsedGoodsStoreService.GetCategoriesList() ?? new List<CategoryDTO>();
            _loading = false;
            StateHasChanged();
        }
        public async Task AddCategory()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(CategoryCreator.Categories), CategoriesList ?? new List<CategoryDTO>());
            var result = await DialogService.Show<CategoryCreator>("Stwórz", parameters, closeOnEscapeKey).Result;
            await DownloadData();
        }
        public async Task DeleteCategory(int idCategory)
        {
            await UsedGoodsStoreService.DeleteCategory(new DeleteCategoryRequest { CategoryId = idCategory });
            await DownloadData();
        }
        public async Task UpdateCategory(CategoryDTO category)
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(CategoryEditor.Category), category);
            parameters.Add(nameof(CategoryEditor.Categories), CategoriesList ?? new List<CategoryDTO>());
            await DialogService.Show<CategoryEditor>("Edycja", parameters, closeOnEscapeKey).Result;
            await DownloadData();
        }
    }
}

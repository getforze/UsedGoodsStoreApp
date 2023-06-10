using Microsoft.AspNetCore.Components;
using System.Text;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Shared
{
    public partial class NavMenu
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
        public void OpenCategorySite(int categoryId)
        {
            NavigationManager.NavigateTo($"/ProductsInCategory/{categoryId}");
        }
    }
}

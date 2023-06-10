using MudBlazor;
using UsedGoodsStoreApp.Client.Components.AdminPanel;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages.AdminPanel
{
    public partial class Attributes
    {
        List<AttributeDTO> AttributesList = new List<AttributeDTO>();
        private bool _loading;
        protected override async Task OnInitializedAsync()
        {
           await DownloadData();
        }
        public async Task DownloadData()
        {
            _loading = true;
            StateHasChanged();
            AttributesList = await UsedGoodsStoreService.GetAttributesList() ?? new List<AttributeDTO>();
            _loading = false;
            StateHasChanged();
        }
        public async Task AddAttribute()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var result = await DialogService.Show<AttributeCreator>("Stwórz", closeOnEscapeKey).Result;
            await DownloadData();
        }
        public async Task DeleteAttribute(int idAttribute)
        {
            await UsedGoodsStoreService.DeleteAttribute(new DeleteAttributeRequest { AttributeId = idAttribute });
            await DownloadData();
        }
        public async Task UpdateAttribute(AttributeDTO attributeDTO)
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(AttributeEditor.Attribute), attributeDTO);
            await DialogService.Show<AttributeEditor>("Edycja", parameters, closeOnEscapeKey).Result;
            await DownloadData();
        }

    }
}

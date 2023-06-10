using MudBlazor;
using UsedGoodsStoreApp.Client.Components.AdminPanel;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages
{
    public partial class UserOrders
    {
        List<OrderDTO> OrdersList = new List<OrderDTO>();
        private bool _loading;
        protected override async Task OnInitializedAsync()
        {
           await DownloadData();
        }
        public async Task DownloadData()
        {
            _loading = true;
            StateHasChanged();
            OrdersList = await UsedGoodsStoreService.GetUserOrders(LoginState.User.UserId) ?? new List<OrderDTO>();
            _loading = false;
            StateHasChanged();
        }

        public async Task OpenPreview(OrderDTO order)
        {

            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(OrderProductViewer.Products), order.OrderItems ?? new List<OrderItemDTO>());
            var result = await DialogService.Show<OrderProductViewer>("Podgląd", parameters, closeOnEscapeKey).Result;
        }

    }
}

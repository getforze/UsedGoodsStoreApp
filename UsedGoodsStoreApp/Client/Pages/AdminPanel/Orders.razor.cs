using MudBlazor;
using UsedGoodsStoreApp.Client.Components.AdminPanel;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages.AdminPanel
{
    public partial class Orders
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
            OrdersList = await UsedGoodsStoreService.GetOrders() ?? new List<OrderDTO>();
            _loading = false;
            StateHasChanged();
        }

        public async Task AcceptOrder(OrderDTO order)
        {
            order.OrderStatusId = (int)Statuses.Accepted;
            await Send(order);
        }
        public async Task CancelOrder(OrderDTO order)
        {
            order.OrderStatusId = (int)Statuses.Cancel;
            await Send(order);
        }
        public async Task OpenPreview(OrderDTO order)
        {

            DialogOptions closeOnEscapeKey = new DialogOptions() { CloseOnEscapeKey = true };
            var parameters = new DialogParameters();
            parameters.Add(nameof(OrderProductViewer.Products), order.OrderItems ?? new List<OrderItemDTO>());
            var result = await DialogService.Show<OrderProductViewer>("Podgląd", parameters, closeOnEscapeKey).Result;
        }
        public async Task Send(OrderDTO order)
        {
            await UsedGoodsStoreService.UpdateOrder(new UpdateOrderRequest { Order = order});
            await DownloadData();
        }

    }
}

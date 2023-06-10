using MudBlazor;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Pages
{
    public partial class OrderProducts
    {
        MudForm form;
        public OrderDTO Order { get; set; } = new OrderDTO();
        protected override void OnInitialized()
        {
            Order.UserId = LoginState.User.UserId;
            Order.OrderStatusId = ((int)Statuses.WaitingForAccept);
            LoginState.OnChange += StateHasChanged;
        }
        public async Task CreateOrder()
        {
            await form.Validate();
            if (!form.IsValid)
            {
                Snackbar.Add("Uzupełnij dane");
                return;
            }
            Order.OrderItems = new List<OrderItemDTO>();
            foreach (var item in ShoppingCart.Products)
            {
                OrderItemDTO itemDTO = new OrderItemDTO();
                itemDTO.ProductId = item.ProductId;
                itemDTO.Price = item.Price;
                Order.OrderItems.Add(itemDTO);
            }
            var result = await UsedGoodsStoreService.CreateOrder(Order);
            if(result != null)
            {
                ShoppingCart.Products = new List<ProductDTO>();
                ShoppingCart.NotifyStateChanged();
                NavigationManager.NavigateTo("/");
            }
        }
    }
}

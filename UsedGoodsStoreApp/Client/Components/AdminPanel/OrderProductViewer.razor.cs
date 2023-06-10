using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Collections;
using System.Net.Http.Headers;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class OrderProductViewer
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public List<OrderItemDTO> Products { get; set; } = new List<OrderItemDTO>();
        public ProductDTO Product { get; set; }
        public void GoBack()
        {
            Product = null;
            StateHasChanged();
        }
        public async Task SetProduct(ProductDTO product)
        {
            Product = product;
            StateHasChanged();
        }
    }
}

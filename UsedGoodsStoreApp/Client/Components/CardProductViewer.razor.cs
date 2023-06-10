using Microsoft.AspNetCore.Components;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components
{
    public partial class CardProductViewer
    {
        [Parameter]
        public ProductDTO Product { get; set; } = new ProductDTO();
        [Parameter]
        public EventCallback<ProductDTO> Callback { get; set; }
        public async Task EventCall(ProductDTO product)
        {
            await Callback.InvokeAsync(product);
        }
    }
}

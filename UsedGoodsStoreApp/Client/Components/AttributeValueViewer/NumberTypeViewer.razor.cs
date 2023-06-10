using Microsoft.AspNetCore.Components;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components.AttributeValueViewer
{
    public partial class NumberTypeViewer
    {
        [Parameter]
        public AttributeProductDTO Attribute { get; set; }
    }
}

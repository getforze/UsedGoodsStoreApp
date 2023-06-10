using Microsoft.AspNetCore.Components;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components.AttributeValueViewer
{
    public partial class AttributeTypeViewer
    {
        [Parameter]
        public AttributeProductDTO Attribute { get; set; }
    }
}

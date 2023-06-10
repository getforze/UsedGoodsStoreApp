using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class CofigureAttributesInProduct
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public ProductDTO Product { get; set; }
        public List<AttributeDTO> Attributes { get; set; } = new List<AttributeDTO>();
        public List<AttributeProductDTO> AttributesProduct { get; set; } = new List<AttributeProductDTO>();
        protected override async Task OnInitializedAsync()
        {
            Attributes = await UsedGoodsStoreService.GetAttributesList() ?? new List<AttributeDTO>();
            AttributesProduct = await UsedGoodsStoreService.GetAttributesProductList(Product.ProductId) ?? new List<AttributeProductDTO>();
            StateHasChanged();
        }
        public void AddAtribute(AttributeDTO attribute)
        {
            var order = 1;
            if (AttributesProduct.Any())
                order = AttributesProduct.Max(comparer => comparer.AttributeValue.DisplayOrder) +1;
            AttributesProduct.Add(new AttributeProductDTO { Attribute1 = attribute, AttributeValue = new AttributeValueDTO { AttributeId = attribute.AttributeId, Value = "" , DisplayOrder = order } });
            StateHasChanged();
        }
        public void DeleteAttribute(AttributeProductDTO attribute)
        {
            AttributesProduct.Remove(attribute);
            StateHasChanged();
        }
        public async Task UpdateAttributesProduct()
        {
            var result = await UsedGoodsStoreService.CreateAttributeProduct(new AttributeProductRequest { ProductId = Product.ProductId, attributeValues = AttributesProduct.Select(x => x.AttributeValue).ToList() });
            if (!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }

    }
}

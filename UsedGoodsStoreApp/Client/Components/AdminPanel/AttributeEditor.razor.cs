using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class AttributeEditor
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public AttributeDTO Attribute { get; set; }
        public async Task AddNewAttribute()
        {
            var result = await UsedGoodsStoreService.UpdateAttribute(new UpdateAttributeRequest { AttributeId = Attribute.AttributeId , Name = Attribute.Name , Type = Attribute.Type});
            if (!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }

    }
}

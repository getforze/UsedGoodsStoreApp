using Microsoft.AspNetCore.Components;
using MudBlazor;
using UsedGoodsStoreApp.Shared.Models;
using UsedGoodsStoreApp.Shared.Requests;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel
{
    public partial class AttributeCreator
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        public AttributeDTO Attribute { get; set; }= new AttributeDTO();
        public async Task AddNewAttribute()
        {
            var result = await UsedGoodsStoreService.AddAttribute(new AddAttributeRequest { Name = Attribute.Name, Type = Attribute.Type });
            if(!result.Failed)
                MudDialog.Close(DialogResult.Ok(true));
        }
    }
}

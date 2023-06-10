﻿using Microsoft.AspNetCore.Components;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Client.Components.AdminPanel.AttributeValue
{
    public partial class NumberType
    {
        [Parameter]
        public AttributeProductDTO Attribute { get; set; }
    }
}

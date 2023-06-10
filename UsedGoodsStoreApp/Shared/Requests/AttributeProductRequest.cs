using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Shared
{
    public class AttributeProductRequest
    {
        public int ProductId { get; set; }
        public List<AttributeValueDTO> attributeValues { get; set; } = new List<AttributeValueDTO>();
    }
}

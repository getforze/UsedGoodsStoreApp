using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedGoodsStoreApp.Shared.Models
{
    public class AttributeDTO
    {
        public int AttributeId { get; set; }

        public string Name { get; set; } = null!;

        public string Type { get; set; }

        public virtual List<AttributeProductDTO> AttributeProducts { get; set; } = new List<AttributeProductDTO>();

        public virtual List<AttributeValueDTO> AttributeValues { get; set; } = new List<AttributeValueDTO>();
    }
}

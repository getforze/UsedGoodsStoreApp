using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UsedGoodsStoreApp.Shared.Models;

namespace UsedGoodsStoreApp.Shared
{
    public class UpdateProductImages
    {

        public StreamContent Images;
        public int ProductId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedGoodsStoreApp.Shared
{
    public class UpdateCategoryRequest
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }
}

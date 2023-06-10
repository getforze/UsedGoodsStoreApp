using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedGoodsStoreApp.Shared
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}

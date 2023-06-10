using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedGoodsStoreApp.Shared
{
    public class Routes
    {
        public const string MainModuleRoute = "UsedGoodsStore";
        public const string ProductsInCategory = $"{MainModuleRoute}/ProductsInCategory";
        public const string AdminPanel = "adm-panel";
        public const string AdminPanelAttributes = $"{AdminPanel}/attributes";
        public const string AdminPanelCategories = $"{AdminPanel}/categories";
        public const string AdminPanelProducts = $"{AdminPanel}/products";
        public const string AdminPanelOrders = $"{AdminPanel}/orders";
        public const string UserOrder = $"UserOrder";
    }
}

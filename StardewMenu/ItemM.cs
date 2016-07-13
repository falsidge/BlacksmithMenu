using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
namespace StardewMenu
{
    public class ItemM : StardewValley.Menus.ShopMenu
    {
        public ItemM(Dictionary<Item, int[]> itemPriceAndStock, int currency = 0, string who = null) : base(itemPriceAndStock, currency, who)
        {

        }
    }
}

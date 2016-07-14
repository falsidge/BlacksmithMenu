using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewValley;
using Microsoft.Xna.Framework;
namespace StardewMenu
{
    public class MenuConfig : Config
    {
        public List<Dictionary<string,int>> stock { get; set;}
        public override T GenerateDefaultConfig<T>()
        {
            stock = new List<Dictionary<string, int>>();
            stock.Add(new Dictionary<string, int>() { {"id",378 }, { "amount",0}, { "cost", 75 } });
            stock.Add(new Dictionary<string, int>() { { "id", 380 }, { "amount", 0 }, { "cost", 150 } });
            stock.Add(new Dictionary<string, int>() { { "id", 382 }, { "amount", 0 }, { "cost", 150 } });
            stock.Add(new Dictionary<string, int>() { { "id", 384 }, { "amount", 0 }, { "cost", 400 } });
            stock.Add(new Dictionary<string, int>() { { "id", 386 }, { "amount", 0 }, { "cost", 750 } });
           // Dictionary<Item, int[]> dictionary = new Dictionary<Item, int[]>();

            return this as T;
        }
    }
}

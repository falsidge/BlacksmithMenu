using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewValley;
using StardewModdingAPI.Events;
using StardewValley.Menus;
using Microsoft.Xna.Framework;

namespace StardewMenu
{
    public class Main : Mod
    { 
        public static MenuConfig ModConfig { get; private set; }
        public static Dictionary<Item, int[]> itemsinstock { get; set; }
        public override void Entry(params object[] objects)
        {
            ModConfig = new MenuConfig().InitializeConfig(BaseConfigPath);
            StardewModdingAPI.Events.MenuEvents.MenuChanged += MenuChanged;
            StardewModdingAPI.Events.GameEvents.GameLoaded += updateStock;
            //StardewModdingAPI.Command.RegisterCommand("time","set time to 800").CommandFired += Time;
            //StardewModdingAPI.Command.RegisterCommand("d", "turn on debug").CommandFired += Deb;
            StardewModdingAPI.Command.RegisterCommand("updateStock", "reloads config and updates stock").CommandFired += updateStock;
        }
        private void MenuChanged(object sender, EventArgsClickableMenuChanged e)
        {
            if (Game1.activeClickableMenu is StardewValley.Menus.ShopMenu)
            {
                StardewValley.Menus.ShopMenu a = (StardewValley.Menus.ShopMenu)Game1.activeClickableMenu;
                if (a.portraitPerson.getName() == "Clint" && a.potraitPersonDialogue != Game1.parseText("I can upgrade your tools with more power. You'll have to leave them with me for a few days, though.", Game1.dialogueFont, Game1.tileSize * 5 - Game1.pixelZoom * 4))
                {
                    Game1.activeClickableMenu = (IClickableMenu)new ItemM(itemsinstock, 0, "Clint");
                }
            }
        }
        public void updateStock()
        {

            itemsinstock = new Dictionary<Item, int[]>();
            ModConfig = ModConfig.ReloadConfig();
            for (int i = 0; i < ModConfig.stock.Count; i++)
            {
                Boolean errored = false;
                Dictionary<string, int> sitem = ModConfig.stock[i];
                if (!sitem.ContainsKey("cost"))
                {
                    Log.Error("Index " + i + " : is missing cost");
                    errored = true;
                }
                if (!sitem.ContainsKey("id"))
                {
                    Log.Error("Index " + i + " : is missing id");
                    errored = true;
                }
                if (!sitem.ContainsKey("amount"))
                {
                    Log.Error("Index " + i + " : is missing amount");
                    errored = true;
                }
                if (!errored)
                {
                  itemsinstock.Add((Item)new StardewValley.Object(Vector2.Zero, sitem["id"], sitem["amount"] == 0 ? int.MaxValue : 1), new int[2] { sitem["cost"], sitem["amount"] == 0 ? int.MaxValue : sitem["amount"] });
                }
            }
        }
        public void updateStock(object sender, EventArgs e)
        {
            this.updateStock();
        }
        /*private void Time(object o, EventArgsCommand e)
        {
            Game1.timeOfDay = 900;
        }
        private void Deb(object o, EventArgsCommand e)
        {
            Game1.debugMode = true;
        }*/
    }
}

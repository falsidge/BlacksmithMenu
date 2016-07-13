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
        public override void Entry(params object[] objects)
        {
            StardewModdingAPI.Events.MenuEvents.MenuChanged += MenuChanged;
            //StardewModdingAPI.Command.RegisterCommand("time","set time to 800").CommandFired += Time;
            //StardewModdingAPI.Command.RegisterCommand("d", "turn on debug").CommandFired += Deb;
        }
        private void MenuChanged(object sender, EventArgsClickableMenuChanged e)
        {
            if (Game1.activeClickableMenu is StardewValley.Menus.ShopMenu)
            {
                StardewValley.Menus.ShopMenu a = (StardewValley.Menus.ShopMenu)Game1.activeClickableMenu;
                if (a.portraitPerson.getName() == "Clint" && a.potraitPersonDialogue != Game1.parseText("I can upgrade your tools with more power. You'll have to leave them with me for a few days, though.", Game1.dialogueFont, Game1.tileSize * 5 - Game1.pixelZoom * 4))
                {
                    Dictionary<Item, int[]> dictionary = new Dictionary<Item, int[]>();
                    dictionary.Add((Item)new StardewValley.Object(Vector2.Zero, 378, int.MaxValue), new int[2]
                    {
        75,
        int.MaxValue
                    });
                    dictionary.Add((Item)new StardewValley.Object(Vector2.Zero, 380, int.MaxValue), new int[2]
                    {
        150,
        int.MaxValue
                    });
                    dictionary.Add((Item)new StardewValley.Object(Vector2.Zero, 382, int.MaxValue), new int[2]
                    {
        150,
        int.MaxValue
                    });
                    dictionary.Add((Item)new StardewValley.Object(Vector2.Zero, 384, int.MaxValue), new int[2]
                    {
        400,
        int.MaxValue
                    });
                    dictionary.Add((Item)new StardewValley.Object(Vector2.Zero, 386, int.MaxValue), new int[2]
{
        400,
        int.MaxValue
});
                    Game1.activeClickableMenu = (IClickableMenu)new ItemM(dictionary, 0, "Clint");

                }
            }
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

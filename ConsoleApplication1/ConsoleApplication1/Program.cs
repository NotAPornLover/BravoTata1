using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace BravoTata
{
    class Program
    {
        public static Obj_AI_Hero Player = ObjectManager.Player;
        public static Menu Menu;
        public static int lastrecordeddeaths = 0;
        public static string[] phrases = { "Lasa boss, ca noi e valoarea <3", "I-auzi, pula mea, ai murit?", "Bravo tata, mare mort.", "Valoarea nu este o valoare, este un stil de viata.", "Si când mor am valoare, la sicriu fac buzunare" };

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Menu = new Menu("CBravo Tata", "hi", true);
            Menu.AddItem(new MenuItem("enabled", "Enabled").SetValue(true));
            Menu.AddToMainMenu();

            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (!Menu.Item("enabled").GetValue<bool>())
                return;
            if (lastrecordeddeaths < Player.Deaths)
            {
                Random r = new Random();
                lastrecordeddeaths = Player.Deaths;
                Game.PrintChat("<font color='#259FF8'>" + phrases[r.Next(0, phrases.Count() - 1)] + "</font>");
            }
            else Game.PrintChat("Daca mori te bat");
        }
    }
}


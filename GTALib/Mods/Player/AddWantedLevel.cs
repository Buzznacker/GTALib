using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;

namespace GTALib.Mods.Player
{
    public class AddWantedLevel : Mod
    {
        public AddWantedLevel() : base("Add Wanted Level", ModType.Runnable, Category.Player)
        {
        }

        protected override void Run()
        {
            int wantedLevel = Game.Player.WantedLevel;
            if (wantedLevel != 5)
            {
                Game.Player.WantedLevel++;
                UI.ShowSubtitle("Brought Wanted Level one level higher");
            }
            else
                UI.ShowSubtitle("Cannot bring wanted level any higher");
        }
    }
}

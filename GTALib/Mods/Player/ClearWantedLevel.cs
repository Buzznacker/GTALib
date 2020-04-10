using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;

namespace GTALib.Mods.Player
{
    public class ClearWantedLevel : Mod
    {
        public ClearWantedLevel() : base("Clear Wanted Level", ModType.Runnable, Category.Player)
        {
        }

        protected override void Run()
        {
            Game.Player.WantedLevel = 0;
        }
    }
}

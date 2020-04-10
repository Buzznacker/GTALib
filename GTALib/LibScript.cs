using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTALib.Menu;
using GTALib.Mods;
using GTALib.Mods.Player;
using GTALib.Mods.Vehicle;
using GTALib.Mods.Weapons;

namespace GTALib
{
    public class LibScript : Script
    {
        
        public Dictionary<string, Mod> Mods
        {
            get;
        } = new Dictionary<string, Mod>();

        public LibScript()
        {
            registerMod(
                new SlowMotionAim(),
                new FixVehicle(),
                new AddWantedLevel(),
                new GodMode(),
                new ClearWantedLevel());
            new MenuHandler(this);
        }

        private void registerMod(params Mod[] mods)
        {
            foreach(Mod mod in mods)
            {
                Mods.Add(mod.Name, mod);
                if (mod.ModType == ModType.ToggleAble)
                    Tick += mod.OnTick;

            }
        }
    }
}

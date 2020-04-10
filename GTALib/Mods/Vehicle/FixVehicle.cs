using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;

namespace GTALib.Mods.Vehicle
{
    public class FixVehicle : Mod
    {
        public FixVehicle() : base("Fix Vehicle", ModType.Runnable, Category.Vehicle)
        {
        }

        protected override void Run()
        {
            Ped curPed = Game.Player.Character;
            if(curPed.IsInVehicle())
            {
                curPed.CurrentVehicle.Repair();
                UI.ShowSubtitle("Your vehicle has been repaired");
            }
            else
            {
                UI.ShowSubtitle("You are not in a vehicle");
            }
        }
    }
}

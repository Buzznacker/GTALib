using GTA;
using GTALib.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTALib.Mods.Player
{
    public class GodMode : Mod
    {
        public GodMode() : base("God Mode", ModType.ToggleAble, Category.Player)
        {
            AddSetting(new Setting<dynamic>("Fire Proof", false));
            AddSetting(new Setting<dynamic>("Explosion Proof", false));
        }

        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);
            Game.Player.IsInvincible = true;
            Ped curPed = Game.Player.Character;
            curPed.IsFireProof = ((bool)GetSetting("Fire Proof").Value);
            curPed.IsExplosionProof = ((bool)GetSetting("Explosion Proof").Value);
        }

        protected override void OnDisable()
        {
            Ped curPed = Game.Player.Character;
            curPed.IsFireProof = false;
            curPed.IsExplosionProof = false;
            base.OnDisable();
        }
    }
}

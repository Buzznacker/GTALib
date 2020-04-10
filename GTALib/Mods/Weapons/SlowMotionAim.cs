using GTALib.Settings;
using GTALib.Settings.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;

namespace GTALib.Mods.Weapons
{
    public class SlowMotionAim : Mod
    {
        private bool _slowed = false;

        public SlowMotionAim() : base("Slow Aim", ModType.ToggleAble, Category.Weapons)
        {
            AddSetting(new Setting<dynamic>("Speed", new SettingFloat(0.5f, 0.1f, 0.1f, 1.4f)));
        }

        public override void OnTick(object sender, EventArgs e)
        {
            base.OnTick(sender, e);
            if(Game.Player.IsAiming)
            {
                if(!_slowed)
                {
                    _slowed = true;
                    Setting<dynamic> setting = GetSetting("Speed");
                    Game.TimeScale = ((SettingFloat)setting.Value).Current;
                }    
            } else if (_slowed)
            {
                SetSpeedBackToNormal();
            }
        }

        protected override void OnDisable()
        {
            SetSpeedBackToNormal();
            base.OnDisable();

        }

        private void SetSpeedBackToNormal()
        {
            Game.TimeScale = 1.5f;
            _slowed = false;
        }
    }
}

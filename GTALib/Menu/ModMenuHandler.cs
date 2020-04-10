using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTALib.Mods;
using GTALib.Settings;
using GTALib.Settings.Impl;
using NativeUI;

namespace GTALib.Menu
{
    public class ModMenuHandler
    {
        private LibScript _script;

        public ModMenuHandler(LibScript script)
        {
            this._script = script;
        }

        public void OnItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if(_script.Mods.TryGetValue(sender.Subtitle.Caption, out Mod mod))
            {
                if(selectedItem.Text == "Activate")
                {
                    mod.Toggle();
                } 
            }
        }

        public void OnCheckBoxHandler(UIMenu sender, UIMenuCheckboxItem checkboxItem, bool Checked)
        {
            if (_script.Mods.TryGetValue(sender.Subtitle.Caption, out Mod mod))
            {
                if (checkboxItem.Text == "Toggle")
                {
                    mod.Toggle();
                }
                else if (mod.Settings.TryGetValue(checkboxItem.Text, out Setting<dynamic> setting))
                {
                    setting.Value = Checked;
                }
            }
        }

        public void OnListChangeHandler(UIMenu sender, UIMenuListItem listItem, int newIndex)
        {
            if(_script.Mods.TryGetValue(sender.Subtitle.Caption, out Mod mod)
                && mod.Settings.TryGetValue(listItem.Text, out Setting<dynamic> setting))
            {
                object newValue = listItem.IndexToItem(newIndex);
                if(setting.Value is SettingInt)
                {
                    ((SettingInt)setting.Value).Current = (int)newValue;
                }
                else if(setting.Value is SettingFloat)
                {
                    ((SettingFloat)setting.Value).Current = (float)newValue;
                }
            }
        }
    }
}

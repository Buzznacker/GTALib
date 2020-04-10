using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTALib.Settings;

namespace GTALib.Mods
{
    public enum ModType
    {
        ToggleAble,
        Runnable
    }

    public enum Category
    {
        Player,
        Weapons,
        Vehicle,
        Misc
    }

    public class Mod
    {

        public string Name
        {
            get; set;
        }

        public ModType ModType
        {
            get; set;
        }

        public Category Category
        {
            get; set;
        }

        public bool Toggled
        {
            get; set;
        } = false;

        public Dictionary<string, Setting<dynamic>> Settings
        {
            get;
        } = new Dictionary<string, Setting<dynamic>>();

        public Mod(string name, ModType modType, Category category)
        {
            this.Name = name;
            this.ModType = modType;
            this.Category = category;
        }

        public virtual void OnTick(object sender, EventArgs e)
        {
            if (!Toggled)
                return;
        }

        protected virtual void OnEnable()
        {
            UI.Notify(this.Name + " has been enabled");
        }

        protected virtual void OnDisable()
        {
            UI.Notify(this.Name + " has been disabled");
        }

        protected virtual void Run() { }

        protected void AddSetting(Setting<dynamic> setting)
        {
            Settings.Add(setting.Name, setting);
        }

        protected Setting<dynamic> GetSetting(string name)
        {
            if(Settings.TryGetValue(name, out Setting<dynamic> val))
            {
                return val;
            }
            return null;
        }

        private void RanRanned()
        {
            UI.Notify(this.Name + " has been executed");
            Run();
            Toggle();
        }

        public void Toggle()
        {
            if(!Toggled)
            {
                Toggled = true;
                if (this.ModType == ModType.ToggleAble)
                    OnEnable();
                else
                    RanRanned();

            } else
            {
                Toggled = false;
                if (this.ModType == ModType.ToggleAble)
                    OnDisable();
            }
        }
    }
}

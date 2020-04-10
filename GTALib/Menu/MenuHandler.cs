using GTALib.Mods;
using GTALib.Settings;
using GTALib.Settings.Impl;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTALib.Menu
{
    public class MenuHandler
    {
        private LibScript _script;
        private UIMenu _mainMenu;
        private MenuPool _menuPool;
        private ModMenuHandler modMenuHandler;
        
        public MenuHandler(LibScript script)
        {
            this._script = script;
            script.KeyUp += OnKeyUp;
            script.Tick += Tick;
            modMenuHandler = new ModMenuHandler(script);
            initMenus();
        }

        private void initMenus()
        {
            _mainMenu = new UIMenu("Marc McDormott", "C'est légal");
            _menuPool = new MenuPool();
            _menuPool.Add(_mainMenu);
            foreach(Category category in Enum.GetValues(typeof(Category)))
            {
                UIMenu categoryMenu = _menuPool.AddSubMenu(_mainMenu, category.ToString());
                categoryMenu.OnItemSelect += OnItemSelectHandler;
                categoryMenu.OnCheckboxChange += OnCheckBoxHandler;
                _script.Mods.Values
                    .Where(mod => mod.Category == category)
                    .ToList()
                    .ForEach((mod) =>
                    {
                        if(mod.Settings.Count > 0)
                        {
                            UIMenu moduleMenu = _menuPool.AddSubMenu(categoryMenu, mod.Name);
                            if (mod.ModType == ModType.ToggleAble)
                            {
                                moduleMenu.AddItem(new UIMenuCheckboxItem("Toggle", false));
                            }
                            else
                            {
                                moduleMenu.AddItem(new UIMenuItem("Activate"));
                            }

                            foreach(Setting<dynamic> setting in mod.Settings.Values)
                            {
                                if(setting.Value is bool)
                                {
                                    moduleMenu.AddItem(new UIMenuCheckboxItem(setting.Name, false));
                                }
                                else if (setting.Value is SettingInt)
                                {
                                    SettingInt settingInt = setting.Value;
                                    int indexDefault = 0;
                                    List<object> integers = new List<object>();
                                    int index = 0;
                                    for(int i = settingInt.Min; i <= settingInt.Max; i += settingInt.Incrementation)
                                    {
                                        integers.Add(i);
                                        if (i == settingInt.Current)
                                            indexDefault = index;
                                        index++;
                                    }
                                    moduleMenu.AddItem(new UIMenuListItem(setting.Name, integers, indexDefault));  
                                }
                                else if (setting.Value is SettingFloat)
                                {
                                    SettingFloat settingFloat = setting.Value;
                                    int indexDefault = 0;
                                    List<object> floats = new List<object>();
                                    int index = 0;
                                    for(float i = settingFloat.Min; i < settingFloat.Max; i += settingFloat.Incrementation)
                                    {
                                        floats.Add(i);
                                        if(i == settingFloat.Current)
                                            indexDefault = index;
                                        index++;
                                    }
                                    moduleMenu.AddItem(new UIMenuListItem(setting.Name, floats, indexDefault));
                                }
                            }
                            moduleMenu.OnListChange += modMenuHandler.OnListChangeHandler;
                            moduleMenu.OnCheckboxChange += modMenuHandler.OnCheckBoxHandler;
                            moduleMenu.OnItemSelect += modMenuHandler.OnItemSelectHandler;
                        } else
                        {
                            if(mod.ModType == ModType.ToggleAble)
                            {
                                categoryMenu.AddItem(new UIMenuCheckboxItem(mod.Name, false));
                            }
                            else
                            {
                                categoryMenu.AddItem(new UIMenuItem(mod.Name));
                            }
                        }
                    });
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            _menuPool.ProcessMenus();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F3)
            {
                if (_menuPool.IsAnyMenuOpen())
                    _menuPool.CloseAllMenus();
                else
                    _mainMenu.Visible = true;
            }
        }

        private void OnItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (_script.Mods.TryGetValue(selectedItem.Text, out Mod mod) && mod.Settings.Count == 0)
            {
                mod.Toggle();
            }
        }

        private void OnCheckBoxHandler(UIMenu sender, UIMenuCheckboxItem checkboxItem, bool Checked)
        {
            if (_script.Mods.TryGetValue(checkboxItem.Text, out Mod mod) && mod.Settings.Count == 0)
            {
                mod.Toggle();
            }
        }
    }
}

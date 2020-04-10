using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTALib.Settings
{
    public class Setting<E>
    {
        
        public E Value
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public Setting(string name, E val)
        {
            this.Name = name;
            this.Value = val;
        }

    }
}

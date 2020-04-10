using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTALib.Settings.Impl
{
    public class SettingInt
    {
        public int Max
        {
            get; set;
        }

        public int Min
        {
            get; set;
        }

        public int Current
        {
            get; set;
        }

        public int Incrementation
        {
            get; private set;
        }

        public SettingInt(int defaultValue, int incrementation)
        {
            this.Current = defaultValue;
            this.Incrementation = incrementation;
        }
    }
}

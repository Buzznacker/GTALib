using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTALib.Settings.Impl
{
    public class SettingFloat
    {
        public float Max
        {
            get; private set;
        }

        public float Min
        {
            get; private set;
        }

        public float Current
        {
            get; set;
        }

        public float Incrementation
        {
            get; set;
        }

        public SettingFloat(float defaultValue, float incrementation, float min, float max)
        {
            this.Current = defaultValue;
            this.Incrementation = incrementation;
            this.Min = min;
            this.Max = max;
        }
    }
}

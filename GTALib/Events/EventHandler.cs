using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTALib.Events
{
    public class EventHandler
    {
        private LibScript _script;

        public EventHandler(LibScript script)
        {
            this._script = script;
            script.KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {

        }

    }
}

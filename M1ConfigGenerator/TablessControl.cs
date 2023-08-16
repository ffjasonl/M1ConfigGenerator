using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M1ConfigGenerator
{
    class TablessControl : TabControl
    {
        // this class creates a new tab control called TablessControl that will show the tabs in design mode
        // but will remove the tabs and borders while the program is running
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode)
                m.Result = (IntPtr)1;
            else
                base.WndProc(ref m);
        }

        public static implicit operator TablessControl(bool v)
        {
            throw new NotImplementedException();
        }
    }
}

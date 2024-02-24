using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class ReplayMode : ModuleType.DualSidedToggle
    {
        public ReplayMode()
        {
            name = "ReplayMode";
            name1 = "Record";
            name2 = "Replay";
        }
    }
}

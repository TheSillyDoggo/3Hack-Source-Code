using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class ReplayModule : Module
    {
        public ReplayModule()
        {
            name = "Replay";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Replay")
                {
                    item.render = enabled;
                }
            }
        }
    }
}
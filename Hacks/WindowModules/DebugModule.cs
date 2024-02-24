using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class DebugModule : Module
    {
        public DebugModule()
        {
            name = "Debug";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Debug")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class WorldModule : Module
    {
        public WorldModule()
        {
            name = "World";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "World")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

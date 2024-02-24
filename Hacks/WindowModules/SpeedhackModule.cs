using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class SpeedhackModule : Module
    {
        public SpeedhackModule()
        {
            name = "Speedhack";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Speedhack")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

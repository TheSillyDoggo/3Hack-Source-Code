using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class CreatorModule : Module
    {
        public CreatorModule()
        {
            name = "Creator";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Creator")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

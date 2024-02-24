using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    public class StatusModule : Module
    {
        public StatusModule()
        {
            name = "Status";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Status")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

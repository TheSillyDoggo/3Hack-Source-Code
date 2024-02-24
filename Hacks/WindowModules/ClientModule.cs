using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class ClientModule : Module
    {
        public ClientModule()
        {
            name = "Client";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Client")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

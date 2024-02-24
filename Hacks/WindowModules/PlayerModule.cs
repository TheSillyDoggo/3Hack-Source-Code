using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class PlayerModule : Module
    {
        public PlayerModule()
        {
            name = "Player";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Player")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class ScriptModule : Module
    {
        public ScriptModule()
        {
            name = "Scripts";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Scripts")
                {
                    item.render = enabled;
                }
            }
        }
    }
}
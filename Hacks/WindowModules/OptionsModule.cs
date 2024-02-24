using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class OptionsModule : Module
    {
        public OptionsModule()
        {
            name = "Options";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name.StartsWith("Options"))
                {
                    item.render = enabled;
                }
            }
        }
    }
}

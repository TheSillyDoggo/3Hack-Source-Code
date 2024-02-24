using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class TestingModule : Module
    {
        public TestingModule()
        {
            name = "Testing";

            description = "Unfinished features";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Testing")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

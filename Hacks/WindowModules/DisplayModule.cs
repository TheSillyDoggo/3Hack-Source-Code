﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules
{
    [System.Serializable]
    public class DisplayModule : Module
    {
        public DisplayModule()
        {
            name = "Display";
        }

        public override void Update()
        {
            foreach (var item in ModMain.cwm.wnds)
            {
                if (item.name == "Display")
                {
                    item.render = enabled;
                }
            }
        }
    }
}

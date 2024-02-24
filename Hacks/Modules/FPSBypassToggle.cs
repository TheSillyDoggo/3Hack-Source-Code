using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class VSync : Module
    {
        public VSync()
        {
            name = "VSync";

            enabled = true;
        }

        public override void Update()
        {
            if (enabled)
            {
                QualitySettings.vSyncCount = 1;
            }
            else
            {
                QualitySettings.vSyncCount = 0;
            }
        }
    }
}

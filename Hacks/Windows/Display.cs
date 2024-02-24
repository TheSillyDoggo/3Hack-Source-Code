using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Windows
{
    public class Display : Window
    {
        public Display()
        {
            rect.position = new UnityEngine.Vector2(230 + 230 + 20 + 230 + 20 + 230 + 20, 20);
            name = "Display";

            modules.Add(new Modules.Fullscreen());
            modules.Add(new Modules.ResolutionInput());
            modules.Add(new Modules.ResolutionApply());
            
            modules.Add(new Modules.VSync());
        }


        public override void OnUpdate()
        {
            
        }
    }
}
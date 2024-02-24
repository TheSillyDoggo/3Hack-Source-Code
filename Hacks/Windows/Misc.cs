using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Jint;
using Jint.Runtime.Interop;

namespace Windows
{
    public class Misc : Window
    {

        public Misc()
        {
            rect.position = new UnityEngine.Vector2(230 + 230 + 20 + 230 + 20 + 230 + 20 + 230 + 20 + 230 + 20, 20);
            name = "Misc";

            modules.Add(new Modules.DemonList());
        }

    }
}
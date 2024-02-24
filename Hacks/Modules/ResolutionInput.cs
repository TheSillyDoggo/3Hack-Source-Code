using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class ResolutionInput : ModuleType.TextInput
    {
        public ResolutionInput()
        {
            name = "Resolution";

            text = PlayerPrefs.GetString("Res", "960x540");
        }

        public override void Update()
        {
            PlayerPrefs.SetString("Res", text);
        }
    }
}

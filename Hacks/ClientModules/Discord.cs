using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class Discord : ModuleType.Button
    {
        public Discord()
        {
            name = "Discord";
            description = "Opens a link to the 3Hack Discord server";
        }

        public override void OnClick()
        {
            //PlayerPrefs.DeleteAll();
            Application.OpenURL("https://discord.com/invite/vvu2wpA4E3");
        }


    }
}

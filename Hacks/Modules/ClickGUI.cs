using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Modules
{
    [System.Serializable]
    class ClickGUI : Module
    {
        public ClickGUI()
        {
            name = "ClickGUI";
            description = "The GUI That your looking at right now";

            mustHaveKeyBind = true;

            //ModuleSetting m = new ModuleSetting();

            //m.name = "Better";
            //m.boolValue = true;
            keybind = KeyCode.RightShift;
            //settings.Add(m);
        }
        public override void Update()
        {
            ModMain.clickGUIKeyCode = keybind;

            enabled = ModMain.showClickGUI;
        }

        public override void OnClick()
        {
            if (!Keybinds.editing)
            {
                ModMain.showClickGUI = false;
            }
        }
    }
}

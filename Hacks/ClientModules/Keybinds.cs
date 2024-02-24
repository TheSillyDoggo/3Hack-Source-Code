using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class Keybinds : ModuleType.Button
    {
        public static bool editing;

        public static Module module;
        public Keybinds()
        {
            name = "Keybinds";
            description = "Modify the keybinds of modules";
        }

        public override void OnClick()
        {
            canClick = false;
            editing = true;
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && module == null)
            {
                canClick = true;
                editing = false;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape) && module != null)
            {
                if (module.mustHaveKeyBind)
                {
                    return;
                }
                canClick = true;
                editing = false;
                return;
            }

            if (!ModMain.showClickGUI)
            {
                canClick = true;
                editing = false;
                return;
            }
                try
            {
                if (module.name == "ClickGUI")
                {
                    ModMain.showClickGUI = true;
                }

                if (Input.GetKeyDown(KeyCode.Escape) || !ModMain.showClickGUI)
                {
                    if (module == null)
                    {
                        canClick = true;
                        editing = false;
                        return;
                    }
                    else
                    {
                        if (!module.mustHaveKeyBind)
                        {
                            canClick = true;
                            editing = false;
                            return;
                        }
                        else
                        {
                            ModMain.showClickGUI = true;
                        }
                    }

                }

                if (module != null)
                {
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        if (!module.mustHaveKeyBind)
                        {
                            module.keybind = KeyCode.None;
                            module = null;
                        }
                        return;
                    }
                    foreach (var key in (KeyCode[])Enum.GetValues(typeof(KeyCode)))
                    {
                        if (key != KeyCode.Mouse1)
                        {
                            if (Input.GetKeyDown(key))
                            {
                                module.keybind = key;
                                module = null;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class ResolutionApply : ModuleType.Button
    {
        public ResolutionApply()
        {
            name = "Apply";
            canClick = true;
        }

        public override void OnClick()
        {
            if (Fullscreen.isFullscreen)
            {
                Screen.SetResolution(Display.displays[0].systemWidth, Display.displays[0].systemHeight, true);
            }
            else
            {
                var res = new Resolution();
                res.width = int.Parse(PlayerPrefs.GetString("Res").ToUpper().Split("X".ToCharArray())[0]);
                res.height = int.Parse(PlayerPrefs.GetString("Res").ToUpper().Split("X".ToCharArray())[1]);
                Screen.SetResolution(res.width, res.height, enabled);
            }

            canClick = true;
        }
    }
}

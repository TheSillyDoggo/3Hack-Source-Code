using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Modules
{
    public class SelectedReplay : ModuleType.TextDropdown
    {
        public SelectedReplay()
        {
            text = PlayerPrefs.GetString("selectedReplay", "");
            name = "selectedReplay";
           
            string path = Application.dataPath;

            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                path += "/../../";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                path += "/../";
            }

            path += "Replays/";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var item in Directory.GetFiles(path))
            {
                Debug.Log(Path.GetExtension(item));
                if (Path.GetExtension(item) == ".replay")
                {
                    content.Add(Path.GetFileName(item).Replace(".replay", ""));
                }
            }
        }

        public override void Update()
        {
            PlayerPrefs.SetString("selectedReplay", text);
        }
    }
}

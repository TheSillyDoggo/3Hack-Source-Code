using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;
namespace Modules
{
    public class ReplaySave : ModuleType.Button
    {
        public ReplaySave()
        {
            name = "Save";
            canClick = true;
        }

        public override void OnClick()
        {
            canClick = true;

            string s = "";

            foreach (var item in Windows.Replay.inputCheck)
            {
                s += item + ";";
            }

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
            path += Windows.Replay.selectedReplay.text;
            path += ".replay";

            File.WriteAllText(path, s);
        }
    }
}

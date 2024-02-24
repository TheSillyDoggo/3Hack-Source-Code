using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

public class Save
{
    public static string path;
    public static string header;
    public static void SaveToFile()
    {
        path = Application.dataPath;
        string s = "[modules]\n";

        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            path += "/../../";
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path += "/../";
        }

        path += "save.ini";


        foreach (var window in ModMain.cwm.wnds)
        {
            foreach (var module in window.modules)
            {
                s += module.name + ":" + module.enabled + ":" + module.keybind + "\n";
            }
        }
        s += "[pos]\n";

        foreach (var window in ModMain.cwm.wnds)
        {
            s += window.name + ":" + window.rect.x + ":" + window.rect.y + "\n";
        }

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        s += "[settings]\n";

        foreach (var window in ModMain.cwm.wnds)
        {
            foreach (var module in window.modules)
            {
                foreach (var setting in module.settings)
                {
                    s += setting.name + ":" + setting.enabled + ":" + module.name + "\n";
                }
            }
        }

        s += "[client]\n";

        s += "scale:" + ModMain.scale + "\n";
        s += "tutorial:" + ModMain.tutorial + "\n";

        if (!File.Exists(path))
        {
            File.Create(path);
        }

        File.WriteAllText(path, s);
    }

    public static void LoadFromFile()
    {
        header = "modules";
        path = Application.dataPath;
        string s = "";

        if (Application.platform == RuntimePlatform.OSXPlayer)
        {
            path += "/../../";
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path += "/../";
        }

        path += "save.ini";

        bool e = false;

        if (File.Exists(path))
        {
            s = File.ReadAllText(path);
            foreach (var line in s.Split("\n".ToCharArray()))
            {
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    header = line.Substring(1, line.Length - 2);
                }
                else
                {
                    HandleLine(line);
                }
            }
        }
        else
        {
            ModMain.scale = 0.25f + (Screen.height / 1080) * 0.25f;
        }
    }

    public static void HandleLine(string line)
    {
        string[] parts = line.Split(":".ToCharArray());
        if (header == "pos")
        {
            foreach (var window in ModMain.cwm.wnds)
            {
                if (window.name.StartsWith(parts[0]))
                {
                    window.rect.x = float.Parse(parts[1]);
                    window.rect.y = float.Parse(parts[2]);
                }
            }
        }
        else if (header == "modules")
        {
            foreach (var window in ModMain.cwm.wnds)
            {
                foreach (var module in window.modules)
                {
                    try
                    {
                        if (module.name == parts[0])
                        {
                            module.enabled = bool.Parse(parts[1]);

                            if (parts[2] != "None")
                            {
                                KeyCode thisKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), parts[2]);
                                module.keybind = thisKeyCode;
                                module.OnLoadedSave();
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        else if (header == "settings")
        {
            foreach (var window in ModMain.cwm.wnds)
            {
                foreach (var module in window.modules)
                {
                    if (module.name == parts[2])
                    {
                        foreach (var setting in module.settings)
                        {
                            if (setting.name == parts[0])
                            {
                                setting.enabled = bool.Parse(parts[1]);
                            }
                        }
                    }
                }
            }
        }
        else if (header == "client")
        {
            if ("scale" == parts[0])
            {
                ModMain.scale = float.Parse(parts[1]);
            }
            if ("tutorial" == parts[0])
            {
                ModMain.tutorial = bool.Parse(parts[1]);
            }
        }
    }
}

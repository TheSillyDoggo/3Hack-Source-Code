using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Scene_Switcher
{
    public void Draw()
    {
        DrawUtils.DrawRect(new UnityEngine.Rect(300, 200, Screen.width - 600, Screen.height - 400), new Color(0, 0, 0, 0.75f));
    }
}

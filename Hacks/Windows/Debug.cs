using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

namespace Windows
{
    public class Debug : Window
    {
        public Debug()
        {
            rect.position = new UnityEngine.Vector2(230 + 150 + 150 + 20, 20);
            rect.width += 20;
            name = "Debug";
            //modules.Add(new Patches.InfiniteDistance());
        }

        public override void Draw()
        {
            UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
            rectAct = new Rect(rect.x, rect.y, 230.0f * ModMain.scale, 50 * ModMain.scale);

            float yOff = rect.y == 0 ? 28 : 0;

            if (ModMain.showClickGUI)
            {
                DrawUtils.DrawRect(rect, DrawUtils.Accent());
                UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleCenter;

                DrawUtils.DrawText(rect, name, Color.white);

                yOff = 0;
            }

            Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            
            DrawUtils.DrawRect(AddRect(rect, new Rect(0, 50.0f * ModMain.scale - yOff, 0, (50 * ModMain.scale) * 3)), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, 0.25f));

            UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleLeft;

            DrawUtils.DrawText(AddRect(rect, new Rect(0, 50.0f * ModMain.scale - yOff, 20, 0)), "Frame Time: " + (Time.unscaledDeltaTime * 1000).ToString().Substring(0, 5) + "ms", Color.white);
            DrawUtils.DrawText(AddRect(rect, new Rect(0, (50.0f + 30.0f) * ModMain.scale - yOff, 0, 0)), "FPS: " + (int)(1f / Time.unscaledDeltaTime), Color.white);
            DrawUtils.DrawText(AddRect(rect, new Rect(0, (50.0f + 60.0f) * ModMain.scale - yOff, 0, 0)), "Objects: " + UnityEngine.GameObject.FindObjectsOfType<Transform>().Length, Color.white);

            rectAct = AddRect(rectAct, new Rect(0, 0, 0, 50 * ModMain.scale * 4));
        }
    }
}
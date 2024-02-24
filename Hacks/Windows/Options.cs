using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Windows
{
    public class Options : Window
    {
        public static Module module;
        public Options()
        {
            rect.position = new UnityEngine.Vector2(230 + 50 + 20, 20);
            name = "Options";

            //modules.Add(new Modules.Keybinds());
            //modules.Add(new Modules.Freecam());
        }

        public override void Draw()
        {
            if (module == null)
            {
                name = "Options";
            }
            else
            {
                name = "Options (" + module.name + ")";
            }

            UnityEngine.GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
            if (!ModMain.showClickGUI)
                return;

            rectAct = new Rect(rect.x, rect.y, 230.0f * ModMain.scale, 50 * ModMain.scale);

            DrawUtils.DrawRect(rect, DrawUtils.Accent());
            UnityEngine.GUI.skin.label.alignment = TextAnchor.MiddleCenter;

            DrawUtils.DrawText(rect, name, Color.white);

            if (module == null)
            {
                DrawUtils.DrawRect(AddRect(rect, new Rect(0, 50.0f * ModMain.scale, 0, (50 * ModMain.scale) * 3)), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));

                DrawUtils.DrawText(AddRect(rect, new Rect(0, 0 * ModMain.scale, 0, 50)), "No Module Selected", Color.white);
                DrawUtils.DrawText(AddRect(rect, new Rect(0, 50.0f * 1.3f * ModMain.scale, 0, 50)), "Right click a Module to change their options", Color.white);
            }
            else
            {
                if (module.settings.Count == 0)
                {
                    DrawUtils.DrawRect(AddRect(rect, new Rect(0, 50.0f * ModMain.scale, 0, (50 * ModMain.scale) * 3)), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));

                    DrawUtils.DrawText(AddRect(rect, new Rect(0, 10 * ModMain.scale, 0, 50)), "This module has no options", Color.white);
                    DrawUtils.DrawText(AddRect(rect, new Rect(0, 50.0f * 1.3f * ModMain.scale, 0, 50)), "Try another module\n¯\\_(ツ)_/¯", Color.white);
                }
                else
                {
                    DrawUtils.DrawRect(AddRect(rect, new Rect(0, 50.0f * ModMain.scale, 0, (50 * ModMain.scale) * modules.Count)), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));
                }
            }

            Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            int e = 0;
            if (module != null)
            {
                foreach (var item in module.settings)
                {
                    e++;
                    item.Draw(AddRect(rect, new Rect(0, (50.0f * e) * ModMain.scale, 0, 0)), this);
                }
            }

            rectAct = AddRect(rectAct, new Rect(0, 0, 0, 50 * ModMain.scale * e));
        }
    }
}

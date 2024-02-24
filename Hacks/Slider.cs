using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModuleType
{
    public class Slider : Module
    {
        public float value;

        public bool down;

        public virtual void Draw(Rect rect, Window wnd)
        {
            Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
            
            DrawUtils.DrawRect(rect, new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));
            

            if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
            {
                Event ae = Event.current;
                if (ae.button == 0 && ae.type == EventType.MouseDown)
                {
                    Window wndA = wnd;

                    ModMain.cwm.wnds.Remove(wnd);
                    ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);

                    down = true;
                }

                if (ae.button == 1 && ae.type == EventType.MouseDown && !Modules.Keybinds.editing)
                {
                    Window wndA = wnd;

                    ModMain.cwm.wnds.Remove(wnd);
                    ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);

                    Windows.Options.module = this;
                }
            }

            Event a = Event.current;
            if (a.button == 0 && a.type == EventType.MouseUp)
            {
                Window wndA = wnd;

                ModMain.cwm.wnds.Remove(wnd);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);

                down = false;
            }

            float width = 40;
            float x = rect.x + rect.width - width;

            DrawUtils.DrawRect(new Rect(x, rect.y, width, rect.height), Color.red);


            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            DrawUtils.DrawText(rect, name, DrawUtils.Accent());


            GUI.skin.label.alignment = TextAnchor.MiddleCenter;

            try
            {
                if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
                {
                    if (description != "")
                    {
                        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                        DrawUtils.DrawRect(new Rect(10, Screen.height - 10 - (40 * ModMain.scale * 2), 60 * description.Length, 40 * 2 * ModMain.scale), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, 0.25f));

                        GUI.skin.label.fontSize = Mathf.RoundToInt(45 * ModMain.scale);
                        DrawUtils.DrawText(new Rect(15, Screen.height - 10 - (40 * ModMain.scale * 2), 60 * description.Length, 40 * 2 * ModMain.scale), description, Color.white);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
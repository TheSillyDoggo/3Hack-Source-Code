using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ModuleType
{
    public class DualSidedOption : ModuleSetting
    {
        public string name1, name2;
        public bool rightOn, anySelected = true;

        public override void Draw(Rect rect, Window wnd)
        {
            Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
            if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width / 2 && mPos.y < rect.y + rect.height)
            {
                if (Input.GetMouseButton(0))
                {
                    DrawUtils.DrawRect(new Rect(rect.x, rect.y, rect.width / 2, rect.height), new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f));
                }
                else
                {
                    DrawUtils.DrawRect(new Rect(rect.x, rect.y, rect.width / 2, rect.height), new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f));
                }
            }
            else
            {
                DrawUtils.DrawRect(new Rect(rect.x, rect.y, rect.width / 2, rect.height), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));
            }

            if (mPos.x > rect.x + (rect.width / 2) && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
            {
                if (Input.GetMouseButton(0))
                {
                    DrawUtils.DrawRect(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, rect.height), new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f));
                }
                else
                {
                    DrawUtils.DrawRect(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, rect.height), new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f));
                }
            }
            else
            {
                DrawUtils.DrawRect(new Rect(rect.x + (rect.width / 2), rect.y, rect.width / 2, rect.height), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));
            }

            if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
            {
                Event a = Event.current;
                if (a.button == 0 && a.type == EventType.MouseDown)
                {
                    if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width / 2 && mPos.y < rect.y + rect.height)
                    {
                        rightOn = false;
                        enabled = rightOn;
                    }
                    if (mPos.x > rect.x + (rect.width / 2) && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
                    {
                        rightOn = true;
                        enabled = rightOn;
                    }
                    Window wndA = wnd;

                    ModMain.cwm.wnds.Remove(wnd);
                    ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);
                }

                if (a.button == 1 && a.type == EventType.MouseDown && Modules.Keybinds.editing)
                {
                    Window wndA = wnd;

                    ModMain.cwm.wnds.Remove(wnd);
                    ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);

                    Modules.Keybinds.module = this;
                }
            }

            if (anySelected)
            {
                if (rightOn == false)
                {
                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                    DrawUtils.DrawText(rect, " " + name1, DrawUtils.Accent());

                    GUI.skin.label.alignment = TextAnchor.MiddleRight;
                    DrawUtils.DrawText(rect, name2 + " ", Color.white);
                }
                else
                {
                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                    DrawUtils.DrawText(rect, " " + name1, Color.white);

                    GUI.skin.label.alignment = TextAnchor.MiddleRight;
                    DrawUtils.DrawText(rect, name2 + " ", DrawUtils.Accent());
                }
            }
            else
            {
                GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                DrawUtils.DrawText(rect, " " + name1, Color.white);

                GUI.skin.label.alignment = TextAnchor.MiddleRight;
                DrawUtils.DrawText(rect, name2 + " ", Color.white);
            }
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

            rightOn = enabled;
        }
    }
}
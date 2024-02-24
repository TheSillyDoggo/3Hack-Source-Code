using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModuleType
{
    public class TextDropdown : Module
    {
        public string text, placeHolder;
        public bool numberOnly;
        public Color colour;

        public bool showingDropdown = false;
        public List<string> content = new List<string>();

        public override void Draw(Rect rect, Window wnd)
        {
            Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            GUI.skin.textField.alignment = TextAnchor.MiddleLeft;
            GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
            GUI.skin.textField.fontSize = Mathf.RoundToInt(21 * ModMain.scale);

            DrawUtils.DrawRect(rect, new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));

            Rect rec = AddRect(AddRect(rect, new Rect(4, 4, -8, -8)), new Rect(0, 0, (50 * ModMain.scale) * -1 - 4, 0));

            DrawUtils.DrawRect(AddRect(AddRect(rect, new Rect(4, 4, -8, -8)), new Rect(0, 0, (50 * ModMain.scale) * -1 - 4, 0)), new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f));

            //50 * ModMain.scale

            text = DrawUtils.DrawTextField(rec, text, Color.white);

            if (numberOnly)
            {
                text = Regex.Replace(text, @"[^0-9 .]", "");
            }


            #region Dropdown

            if (showingDropdown)
            {
                Color col = new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f);
                DrawUtils.DrawRect(AddRect(rect, new Rect(rect.width, 0, 0, rect.height * (content.Count -1))), col);

                int f = 0;
                foreach (var item in content)
                {
                    Rect reect = AddRect(rect, new Rect(rect.width, rect.height * f, 0, 0));
                    DrawUtils.DrawText(reect, "  " + item, Color.white);
                    f++;

                    if (Event.current.type == EventType.MouseDown)
                    {
                        if (mPos.x > reect.x && mPos.y > reect.y && mPos.x < reect.x + reect.width && mPos.y < reect.y + reect.height)
                        {
                            text = item;
                            showingDropdown = false;
                        }
                    }
                }
            }

            #endregion

            Rect recA = new Rect(0/*rect.width - rec.width*/, rect.y, rect.width - rec.width, rect.height);

            GUI.skin.label.fontSize = Mathf.RoundToInt(25 * ModMain.scale);
            GUI.skin.label.alignment = TextAnchor.MiddleRight;
            DrawUtils.DrawText(rect, showingDropdown ? "<    " : ">    ", Color.white);

            GUI.skin.label.alignment = TextAnchor.MiddleCenter;

            if (Event.current.type == EventType.MouseDown)
            {
                if (mPos.x > rect.width - (50 * ModMain.scale) && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
                {
                    showingDropdown = !showingDropdown;
                }
            }

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace ModuleType
{
    public class TextInput : Module
    {
        public string text, placeHolder;
        public bool numberOnly;
        public Color colour;
        public override void Draw(Rect rect, Window wnd)
        {
            Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            GUI.skin.textField.alignment = TextAnchor.MiddleLeft;
            GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
            GUI.skin.textField.fontSize = Mathf.RoundToInt(21 * ModMain.scale);

            DrawUtils.DrawRect(rect, new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));

            DrawUtils.DrawRect(AddRect(rect, new Rect(4, 4, -8, -8)), new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f));

            text = DrawUtils.DrawTextField(AddRect(rect, new Rect(4, 4, -8, -8)), text, Color.white);

            if (numberOnly)
            {
                text = Regex.Replace(text, @"[^0-9 .]", "");
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
        }
    }
}
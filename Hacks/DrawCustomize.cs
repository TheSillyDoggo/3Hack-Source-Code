using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DrawCustomize
{
    public static List<string> buttons = new List<string>() { "If", "You", "Are", "Reading", "This", "You", "Get", "No", "Bitches" };

    public static int selected = 0;

    public static bool open = false;

    public static void Draw()
    {
        Rect rect = new Rect(Screen.width / 2f - (Screen.width / 2.5f) / 2, Screen.height / 2f - (Screen.height / 2.5f) / 2, Screen.width / 2.5f, Screen.height / 2.5f);
        DrawUtils.DrawRect(new UnityEngine.Rect(0, 0, Screen.width, Screen.height), new Color(0,0,0, 0.3f));

        DrawUtils.DrawRect(rect, new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));

        DrawUtils.DrawRect(new Rect(rect.x + 200, rect.y, 2, rect.height), DrawUtils.Accent());

        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        Event a = Event.current;

        for (int i = 0; i < buttons.Count; i++)
        {
            GUI.skin.label.fontSize = 16;
            GUI.skin.label.alignment = TextAnchor.MiddleLeft;

            DrawUtils.DrawText(new Rect(rect.x + 10, rect.y + (30 * i), 200, 30), buttons[i], (selected == i) ? DrawUtils.Accent() : Color.white);

            if (mPos.x > rect.x && mPos.x < rect.x + 200 && mPos.y > rect.y + (30 * i) && mPos.y < (rect.y + (30 * i)) + 30)
            {
                if (a.type == EventType.MouseDown)
                {
                    selected = i;
                }
            }
        }
    }
}
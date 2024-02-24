using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ModuleSetting : Module
{
    public bool boolValue;

    public int type = 1;

    public virtual void Draw(Rect rect, Window wnd)
    {
        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
        if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
        {
            if (Input.GetMouseButton(0))
            {
                DrawUtils.DrawRect(rect, new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f));
            }
            else
            {
                DrawUtils.DrawRect(rect, new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f));
            }
        }
        else
        {
            DrawUtils.DrawRect(rect, new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f));
        }

        if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
        {
            Event a = Event.current;
            if (a.button == 0 && a.type == EventType.MouseDown)
            {
                Window wndA = wnd;

                ModMain.cwm.wnds.Remove(wnd);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);

                enabled = !enabled;
                boolValue = enabled;
            }
        }


        if (boolValue)
        {
            DrawUtils.DrawText(rect, name, DrawUtils.Accent());
        }
        else
        {
            DrawUtils.DrawText(rect, name, Color.white);
        }

        try
        {
            if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
            {
                if (description != "")
                {
                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                    DrawUtils.DrawRect(new Rect(10, Screen.height - 10 - (40 * ModMain.scale * 2), 60 * description.Length, 40 * 2 * ModMain.scale), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, 0.25f));

                    GUI.skin.label.fontSize = Mathf.RoundToInt(38 * ModMain.scale);
                    DrawUtils.DrawText(new Rect(15, Screen.height - 10 - (40 * ModMain.scale * 2), 60 * description.Length, 40 * 2 * ModMain.scale), description, Color.white);
                }
            }
        }
        catch (Exception)
        {

        }
    }

    public virtual void OnClick()
    {
        if (type == 1)
        {
            boolValue = !boolValue;
        }
    }
}
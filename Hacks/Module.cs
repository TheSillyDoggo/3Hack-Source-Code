using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Module
{
    public string name;
    public bool enabled, mustHaveKeyBind;
    public string description;

    public KeyCode keybind = KeyCode.None;

    public List<ModuleSetting> settings = new List<ModuleSetting>();

    //inherits for modules

    public virtual void Update()
    {

    }

    public virtual void OnClick()
    {

    }

    public virtual void OnDraw()
    {

    }

    //for status only
    
    public virtual void OnLoadedSave()
    {

    }

    public virtual void Draw(Rect rect, Window wnd)
    {
        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
        if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
        {
            if (Input.GetMouseButton(0))
            {
                DrawUtils.DrawRect(rect, new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, ClientWindowManager.alpha));
            }
            else
            {
                DrawUtils.DrawRect(rect, new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f, ClientWindowManager.alpha));
            }
        }
        else
        {
            DrawUtils.DrawRect(rect, new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, ClientWindowManager.alpha));
        }

        if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
        {
            Event a = Event.current;
            if (a.button == 0 && a.type == EventType.MouseDown)
            {
                Window wndA = wnd;

                /*ModMain.cwm.wnds.Remove(wnd);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);*/

                enabled = !enabled;

                OnClick();
            }

            if (a.button == 1 && a.type == EventType.MouseDown && Modules.Keybinds.editing)
            {
                Window wndA = wnd;

                /*ModMain.cwm.wnds.Remove(wnd);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);*/

                Modules.Keybinds.module = this;
            }

            if (a.button == 1 && a.type == EventType.MouseDown && !Modules.Keybinds.editing)
            {
                Window wndA = wnd;

                /*ModMain.cwm.wnds.Remove(wnd);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wndA);*/

                Windows.Options.module = this;
            }
        }


        if (enabled)
        {
            DrawUtils.DrawText(rect, " " + name, DrawUtils.Accent());

            if (keybind != KeyCode.None)
            {
                GUI.skin.label.alignment = TextAnchor.MiddleRight;
                DrawUtils.DrawText(rect, "[" + keybind.ToString() + "] ", new Color(DrawUtils.Accent().r, DrawUtils.Accent().g, DrawUtils.Accent().b, ClientWindowManager.alpha));

                //if (this.settings.Count != 0)
                    //GUI.DrawTexture(new Rect(rect.x + rect.width - (5 * ModMain.scale) - (rect.height * 0.6f), rect.y + rect.height - (5 * ModMain.scale) - (rect.height * 0.6f), (rect.height * 0.6f), (rect.height * 0.6f)), ClientWindowManager.cog, ScaleMode.StretchToFill, true, 10f, DrawUtils.Accent(), 0, 0);
            }
        }
        else
        {
            DrawUtils.DrawText(rect, " " + name, new Color(1, 1, 1, ClientWindowManager.alpha));

            if (keybind != KeyCode.None)
            {
                GUI.skin.label.alignment = TextAnchor.MiddleRight;
                DrawUtils.DrawText(rect, "[" + keybind.ToString() + "] ", new Color(1, 1, 1, ClientWindowManager.alpha));
                
                //if (this.settings.Count != 0)
                    //GUI.DrawTexture(new Rect(rect.x + rect.width - (5 * ModMain.scale) - (rect.height * 0.6f), rect.y + rect.height - (5 * ModMain.scale) - (rect.height * 0.6f), (rect.height * 0.6f), (rect.height * 0.6f)), ClientWindowManager.cog, ScaleMode.StretchToFill, true, 10f, Color.white, 0, 0);
            }
        }
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        try
        {
            if (mPos.x > rect.x && mPos.y > rect.y && mPos.x < rect.x + rect.width && mPos.y < rect.y + rect.height)
            {
                if (description != "")
                {
                    GUI.skin.label.alignment = TextAnchor.MiddleLeft;
                    DrawUtils.DrawRect(new Rect(10, Screen.height - 10 - (40 * ModMain.scale * 2), 60 * description.Length, 40 * 2 * ModMain.scale), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, 0.25f * ClientWindowManager.alpha));

                    GUI.skin.label.fontSize = Mathf.RoundToInt(45 * ModMain.scale);
                    DrawUtils.DrawText(new Rect(15, Screen.height - 10 - (40 * ModMain.scale * 2), 60 * description.Length, 40 * 2 * ModMain.scale), description, new Color(1, 1, 1, ClientWindowManager.alpha));
                }
            }
        }
        catch (Exception)
        {
            //no more error
        }
    }

    //to be used once :3
    public Rect AddRect(Rect rect1, Rect rect2)
    {
        return new Rect(rect1.x + rect2.x, rect1.y + rect2.y, rect1.width + rect2.width, rect1.height + rect2.height);
    }
}
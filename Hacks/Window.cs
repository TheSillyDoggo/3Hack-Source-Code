using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Window
{
    public Rect rect = new Rect(50, 20, 230.0f * ModMain.scale, 50 * ModMain.scale);

    public Rect rectAct = new Rect(50, 20, 230.0f * ModMain.scale, 50 * ModMain.scale);

    public Vector2 offset;
    public bool dragging = false;
    public bool render = false;
    public string name = "Test Window :)";

    public List<Module> modules = new List<Module>();
    public virtual void Draw()
    {
        GUI.skin.label.fontSize = Mathf.RoundToInt(23 * ModMain.scale);
        if (!ModMain.showClickGUI)
            return;


        rect.width = 230 * ModMain.scale;
        rect.height = 50 * ModMain.scale;
        rectAct = new Rect(rect.x, rect.y, 230.0f * ModMain.scale, 50 * ModMain.scale);

        DrawUtils.DrawRect(rect, new Color(DrawUtils.Accent().r, DrawUtils.Accent().g, DrawUtils.Accent().b, ClientWindowManager.alpha));
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        DrawUtils.DrawText(rect, name, new Color(1, 1, 1, ClientWindowManager.alpha));

        DrawUtils.DrawRect(AddRect(rect, new Rect(0, 50.0f * ModMain.scale * modules.Count, 0, (50 * ModMain.scale))), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, ClientWindowManager.alpha));

        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        int e = 0;
        foreach (var item in modules)
        {
            e++;
            item.Draw(AddRect(rect, new Rect(0, (50.0f * e) * ModMain.scale, 0, 0)), this);
        }

        rectAct = AddRect(rectAct, new Rect(0, 0, 0, 50 * ModMain.scale * e));
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnLateUpdate()
    {

    }

    public void Update()
    {
        foreach (var item in modules)
        {
            if (Input.GetKeyDown(item.keybind))
            {
                item.enabled = !item.enabled;

                /*Window wnd = this;

                ModMain.cwm.wnds.Remove(this);
                ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);*/
            }

            item.Update();

            foreach (var itemA in item.settings)
            {
                itemA.Update();
            }

        }

        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        if (ModMain.showClickGUI)
        {
            if (!Input.GetMouseButton(0))
            {
                dragging = false;
            }

            if (mPos.x > rectAct.x && mPos.y > rectAct.y && mPos.x < rectAct.x + rectAct.width && mPos.y < rectAct.y + rectAct.height)
                ClientWindowManager.isOver = true;

            float ts = Time.timeScale;

            Time.timeScale = 0.1f;
            if ((mPos.x > rect.position.x && mPos.y > rect.position.y) && (mPos.x < rect.position.x + rect.width && mPos.y < rect.position.y + rect.height))
            {
                if (Input.GetMouseButtonDown(0))
                {

                    offset = rect.position - mPos;
                    dragging = true;

                    /*Window wnd = this;

                    ModMain.cwm.wnds.Remove(this);
                    ModMain.cwm.wnds.Insert(ModMain.cwm.wnds.Count, wnd);*/
                }
            }

            if (dragging)
            {
                rect.position = mPos + offset;
            }

            if (rect.x < 0)
            {
                rect.x = 0;
            }
            if (rect.y < 0)
            {
                rect.y = 0;
            }

            if (rect.x > Screen.width - rect.width)
            {
                rect.x = Screen.width - rect.width;
            }

            if (rect.y + rectAct.height > Screen.height)
            {
                rect.y = Screen.height - rectAct.height;
            }

            Time.timeScale = ts;
        }

        OnUpdate();
    }

    public Rect AddRect(Rect rect1, Rect rect2)
    {
        return new Rect(rect1.x + rect2.x, rect1.y + rect2.y, rect1.width + rect2.width, rect1.height + rect2.height);
    }

    public virtual void OnSceneChanged(int buildIndex, string sceneName)
    {

    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class SceneSwitcher : Module
    {
        public bool SceneSwitcherOpen;

        public Vector2 selectedSpot;

        public List<SceneTile> tiles = new List<SceneTile>();

        public SceneSwitcher()
        {
            name = "Scene Switcher";
            description = "Switch Scenes by holding " + keybind.ToString();
            keybind = KeyCode.Return;
            enabled = false;

            tiles.Add(new SceneTile());

            SceneTile st = new SceneTile();

            st.spot = Vector2.right;

            tiles.Add(st);

            SceneTile sta = new SceneTile();

            sta.spot = Vector2.right * 2;

            tiles.Add(st);
        }

        public override void Update()
        {
            description = "Switch Scenes by holding " + keybind.ToString();

            SceneSwitcherOpen = Input.GetKey(keybind);
        }

        public override void OnDraw()
        {
            if (false)
            {
                DrawUtils.DrawRect(new UnityEngine.Rect(0, 0, Screen.width, Screen.height), new Color(0, 0, 0, 0.5f));
                DrawUtils.DrawOutlinedRect(new UnityEngine.Rect(100, 125, Screen.width - 200, Screen.height - (125 * 2)), DrawUtils.Accent(), 7);

                foreach (var item in tiles)
                {
                    item.Draw(selectedSpot);
                }
            }
        }
    }
}

/*
Main Menu
Level Editor
Online Levels
Last Scene
*/
[System.Serializable]
public class SceneTile
{
    public string SceneName;
    public Vector2 spot;

    public SceneTile()
    {
        positions.Add(new Vector2(384 - 20, 384 / 2));
        positions.Add(new Vector2(384 * 2, 384 / 2));
        positions.Add(new Vector2((384 * 3) + 20, 384 / 2));
    }

    public void Draw(Vector2 selectedSpot)
    {
        Rect rect = new Rect(0, 0, 384, Screen.height - 384);

        rect.position = positions[(int)spot.x];

        if (spot == selectedSpot)
        {
            DrawUtils.DrawOutlinedRect(rect, DrawUtils.Accent(), 7);
        }
        else
        {
            DrawUtils.DrawOutlinedRect(rect, Color.white, 4);
        }
    }

    public List<Vector2> positions = new List<Vector2>();
}

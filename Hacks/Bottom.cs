using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bottom
{
    public static bool load;
    public static List<Texture2D> textures;
    public static float size = 120 * ModMain.scale;
    public static int moduleCount = 8;

    public static void Draw()
    {
        
        DrawUtils.DrawRect(new UnityEngine.Rect(Screen.width / 2 - (moduleCount * size) / 2 + ((20 * ModMain.scale * moduleCount) + (20 * ModMain.scale)) / 2, Screen.height - (75 * ModMain.scale) - size, moduleCount * size - (20 * ModMain.scale * moduleCount) + (20 * ModMain.scale), size), new Color(36 / 255.0f, 36 / 255.0f, 36 / 255.0f, ClientWindowManager.alpha));

        if (!load)
        {
            textures = new List<Texture2D>();

            for (int i = 0; i < moduleCount; i++)
            {
                string text2 = Application.dataPath;
                if (Application.platform == RuntimePlatform.OSXPlayer)
                {
                    text2 += $"/../../Assets/Tab{i}.png";
                }
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    text2 += $"/../Assets/Tab{i}.png";
                }
                else
                {
                    text2 += $"Assets/Tab{i}.png";
                }

                load = true;

                if (!File.Exists(text2))
                {
                    text2 = Application.dataPath + "/../Assets/Background.png";
                }

                Texture2D TextureSheet = new Texture2D(10, 10);
                //TextureSheet.LoadImage(File.ReadAllBytes(text2));
                //logoTexture.LoadRawTextureData(Assets.LogoAsset.bytes);
                TextureSheet.Apply();

                textures.Add(TextureSheet);
            }
        }


        Event a = Event.current;
        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        for (int i = 0; i < moduleCount; i++)
        {
            float x = Screen.width / 2 - (moduleCount * size) / 2 + (size * i) - (20 * ModMain.scale * i) + ((20 * ModMain.scale * moduleCount) + (20 * ModMain.scale)) / 2;

            bool enabled = ModMain.cwm.wnds[i].render;
            
            Color colour = enabled ? new Color(25 / 255.0f, 25 / 255.0f, 25 / 255.0f, ClientWindowManager.alpha) : new Color(30 / 255.0f, 30 / 255.0f, 30 / 255.0f, ClientWindowManager.alpha);
            Color colour2 = enabled ? new Color(DrawUtils.Accent().r, DrawUtils.Accent().g, DrawUtils.Accent().b, ClientWindowManager.alpha) : new Color(1, 1, 1, ClientWindowManager.alpha);

            DrawUtils.DrawRect(new Rect(x + (20 * ModMain.scale), Screen.height - ((75 - 20) * ModMain.scale) - size, 80 * ModMain.scale, 80 * ModMain.scale), colour);

            GUI.DrawTexture(new Rect(x + (28 * ModMain.scale), Screen.height - ((75 - 28) * ModMain.scale) - size, (80 - 16) * ModMain.scale, (80 - 16) * ModMain.scale), textures[i], ScaleMode.StretchToFill, true, 0, colour2, 0, 0);

            
            if (a.button == 0 && a.type == EventType.MouseDown)
            {
                if (mPos.x > x + (20 * ModMain.scale) && mPos.x < (x + (20 * ModMain.scale)) + (80 * ModMain.scale) && mPos.y > Screen.height - ((75 - 20) * ModMain.scale) - size && mPos.y < (Screen.height - ((75 - 20) * ModMain.scale) - size) + (80 * ModMain.scale))
                {
                    Debug.Log($"click {ModMain.cwm.wnds[i].name}");
                    ModMain.cwm.wnds[11].modules[i].enabled = !ModMain.cwm.wnds[11].modules[i].enabled;
                }
            }
        }
    }

    public static void Update()
    {
        Vector2 mPos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        if (mPos.x > Screen.width / 2 - (moduleCount * size) / 2 + ((20 * ModMain.scale * moduleCount) + (20 * ModMain.scale)) / 2 && mPos.y > Screen.height - (75 * ModMain.scale) - size)
        {
            if (mPos.x < (Screen.width / 2 - (moduleCount * size) / 2 + ((20 * ModMain.scale * moduleCount) + (20 * ModMain.scale)) / 2) + (moduleCount * size - (20 * ModMain.scale * moduleCount) + (20 * ModMain.scale)) && mPos.y < (Screen.height - (75 * ModMain.scale) - size) + size)
            {
                ClientWindowManager.isOver = true;
            }
        }
    }
}
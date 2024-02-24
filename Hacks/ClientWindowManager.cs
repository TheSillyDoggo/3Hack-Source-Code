using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClientWindowManager
{
    public static bool isOver;

    public static float alpha = 1f;

    public static float effectVal, effectIntensity = 0.3f, effectDur = 0.15f;

    public static EffectType effectType = EffectType.Black;

    public static Texture2D effectTexture, logoTexture, logoTexture2;

    public static bool a;

    public enum EffectType
    {
        None,
        Black,
        Image
    }

    public List<Window> wnds = new List<Window>();
    public ClientWindowManager()
    {
        wnds.Add(new Windows.World());
        wnds.Add(new Windows.Player());
        wnds.Add(new Windows.Speedhack());
        wnds.Add(new Windows.Status());
        wnds.Add(new Windows.Creator());
        wnds.Add(new Windows.Display());
        wnds.Add(new Windows.Replay());
        wnds.Add(new Windows.Client());
        wnds.Add(new Windows.Misc());
        wnds.Add(new Windows.Options());
        wnds.Add(new Windows.Debug()); 
        wnds.Add(new Windows.GUI());
        wnds.Add(new Windows.Testing());
    }

    public void Update()
    {
        if (!a)
        {
            string text = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                text += "/../../Assets/Background.png";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                text += "/../Assets/Background.png";
            }
            else
            {
                text += "Assets/Background.png";
            }

            string text2 = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                text2 += "/../../Assets/Logo.png";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                text2 += "/../Assets/Logo.png";
            }
            else
            {
                text2 += "Assets/Logo.png";
            }

            string text3 = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                text3 += "/../../Assets/LogoOut.png";
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                text3 += "/../Assets/LogoOut.png";
            }
            else
            {
                text3 += "Assets/LogoOut.png";
            }

            effectTexture = new Texture2D(10, 10);
            effectTexture.LoadImage(File.ReadAllBytes(text));
            effectTexture.Apply();

            a = true;

            logoTexture = new Texture2D(10, 10);
            logoTexture.LoadImage(File.ReadAllBytes(text2));
            //logoTexture.LoadRawTextureData(Assets.LogoAsset.bytes);
            logoTexture.Apply();

            logoTexture2 = new Texture2D(10, 10);
            logoTexture2.LoadImage(File.ReadAllBytes(text3));
            //logoTexture.LoadRawTextureData(Assets.LogoAsset.bytes);
            logoTexture2.Apply();
        }

        isOver = false;

        effectVal += (Time.unscaledDeltaTime / effectDur) * (ModMain.showClickGUI?1:-1);

        effectVal = Mathf.Clamp01(effectVal);

        alpha = effectVal;

        foreach (var item in wnds)
        {
            //if (item.render)
            //{
                item.Update();
            //}
        }

        Bottom.Update();

        if (DrawCustomize.open)
        {

            GameObject eso = GameObject.Find("EventSystem");
            isOver = true;
            
            if (eso != null)
            {
                EventSystem es = eso.GetComponent<EventSystem>();

                es.enabled = !isOver;
            }
        }

        if (ModMain.showClickGUI)
        {
            GameObject eso = GameObject.Find("EventSystem");

            if (eso != null)
            {
                EventSystem es = eso.GetComponent<EventSystem>();

                es.enabled = !isOver;
            }
        }
        else
        {
            GameObject eso = GameObject.Find("EventSystem");

            if (eso != null)
            {
                EventSystem es = eso.GetComponent<EventSystem>();

                es.enabled = true;
            }
        }
    }

    public void Draw()
    {
        if (effectType != EffectType.None)
            DrawBackground();

        foreach (var item in wnds)
        {
            foreach (var itemA in item.modules)
            {
                itemA.OnDraw();
            }

            if (item.render)
            {
                item.Draw();
            }
        }

        //Bottom.Draw();
    }


    public void LateUpdate()
    {
        foreach (var item in wnds)
        {
            item.OnLateUpdate();
        }
    }

    public void OnSceneChanged(int buildIndex, string sceneName)
    {
        foreach (var item in wnds)
        {
            item.OnSceneChanged(buildIndex, sceneName);
        }
    }

    public void DrawBackground()
    {
        if (effectType == EffectType.Black)
        {
            DrawUtils.DrawRect(new Rect(0, 0, Screen.width, Screen.height), new Color(0, 0, 0, effectVal * effectIntensity));
        }
        else if (effectType == EffectType.Image)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), effectTexture, ScaleMode.StretchToFill, true, 0, new Color(1, 1, 1, effectVal * effectIntensity), 0, 0);
        }

        GUI.DrawTexture(new Rect(15 * ModMain.scale + ((logoTexture2.width - logoTexture.width) / 2) * ModMain.scale, (Screen.height - logoTexture.height * ModMain.scale - (15 * ModMain.scale)) - ((logoTexture2.height - logoTexture.height) / 2) * ModMain.scale, logoTexture.width * ModMain.scale, logoTexture.height * ModMain.scale), logoTexture, ScaleMode.StretchToFill, true, 0, new Color(1, 1, 1, effectVal), 0, 0);
        GUI.DrawTexture(new Rect(15 * ModMain.scale, Screen.height - logoTexture2.height * ModMain.scale - (15 * ModMain.scale), logoTexture2.width * ModMain.scale, logoTexture2.height * ModMain.scale), logoTexture2, ScaleMode.StretchToFill, true, 0, new Color(DrawUtils.Accent().r, DrawUtils.Accent().g, DrawUtils.Accent().b, effectVal), 0, 0);
    }
}
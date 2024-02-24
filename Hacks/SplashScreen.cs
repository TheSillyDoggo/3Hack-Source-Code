using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SplashScreen
{
    public static Texture2D tex = new Texture2D(64, 64);

    public static void Load()
    {
        foreach (var obj in GameObject.FindObjectsOfType<Transform>())
        {
            if (obj.gameObject.name != "Camera")
            {
                if (obj.parent == null)
                {
                    GameObject.Destroy(obj.gameObject);
                }
            }
            else
            {
                obj.transform.position = new Vector3(0, 0, -100 * 1000);

                GameObject.Destroy(obj.GetComponent<TitleCamera>());
            }
        }

        tex = new Texture2D(64, 64);

        GameObject myGO;
        Canvas myCanvas;
        RectTransform rectTransformA;


        myGO = new GameObject();
        myGO.name = "sus Canvas (Explodingbill)";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.sortingOrder = 0;
        myCanvas.renderMode = RenderMode.WorldSpace;
        myGO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //myGO.AddComponent<GraphicRaycaster>();


        


        GameObject myTextA = new GameObject();
        myTextA.transform.parent = myGO.transform;
        myTextA.name = "Logo";


        // Text position
        rectTransformA = myTextA.AddComponent<RectTransform>();

        rectTransformA.anchoredPosition = new Vector2(0, 0);

        byte[] pngBytes = File.ReadAllBytes(Path.Combine(Application.dataPath, "baller.png"));

        tex.LoadImage(pngBytes);

        myTextA.AddComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one, 0.5f);
        myTextA.GetComponent<Image>().SetNativeSize();

        myTextA.transform.localScale = Vector3.one;
    }
}
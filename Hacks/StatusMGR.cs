using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusMGR
{
    public static TextMeshProUGUI tltext;
    public static TextMeshProUGUI trtext;

    public static bool isInScene;

    public static float totalDelta;

    public static int frames;

    public static void Init()
    {
        GameObject myGO;
        GameObject myText;
        GameObject myTextA;
         Canvas myCanvas;
        TextMeshProUGUI text;
        TextMeshProUGUI textA;
        RectTransform rectTransform;
        RectTransform rectTransformA;


        myGO = new GameObject();
        myGO.name = "sus Canvas (Explodingbill)";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.sortingOrder = 0;
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        //myGO.AddComponent<GraphicRaycaster>();

        // Text
        myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = "TopLeft";

        text = myText.AddComponent<TextMeshProUGUI>();
        text.font = ModMain.fonts[0];
        text.text = "";
        text.fontSize = 12;
        text.alignment = TextAlignmentOptions.TopLeft;
        

        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.up;
        rectTransform.anchorMax = Vector2.up;

        rectTransform.anchoredPosition = new Vector2(20000 + 5, -100 - 5);
        rectTransform.sizeDelta = new Vector2(40000, 200);
        text.raycastTarget = false;

        GameObject.DontDestroyOnLoad(myCanvas.gameObject);


        myTextA = new GameObject();
        myTextA.transform.parent = myGO.transform;
        myTextA.name = "TopRight";

        textA = myTextA.AddComponent<TextMeshProUGUI>();
        textA.font = ModMain.fonts[0];
        textA.text = "";
        textA.fontSize = 12;
        textA.alignment = TextAlignmentOptions.TopRight;


        // Text position
        rectTransformA = textA.GetComponent<RectTransform>();
        rectTransformA.anchorMin = Vector2.one;
        rectTransformA.anchorMax = Vector2.one;

        rectTransformA.anchoredPosition = new Vector2(-20000 - 5, -100 - 5);
        rectTransformA.sizeDelta = new Vector2(40000, 200);
        textA.raycastTarget = false;

        tltext = text;
        trtext = textA;
    }

    public static void Update()
    {
        if (isInScene && !PauseMenuManager.paused)
        {
            totalDelta += Time.deltaTime;
            frames++;
        }
        Windows.Status.UpdateText(tltext);
    }

    public static void OnSceneChanged(int sceneIndex, string sceneName)
    {
        totalDelta = 0;
        frames = 0;

        if (GameObject.FindObjectOfType<PlayerScript>() != null)
        {
            isInScene = true;
        }
        else
        {
            isInScene = false;
        }
    }
}


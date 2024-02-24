using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
    public class InfLevels : Module
    {
        public static int zOrder;

        public static HarmonyLib.Harmony harmony;
        public InfLevels()
        {
            name = "Custom Level Count";
            description = "Set a custom level count (buggy / broken)";

            harmony = new HarmonyLib.Harmony("com.Explodingbill.SaveSelectPage");

            settings.Add(new InfLevelsCount());
        }

        public override void OnClick()
        {
            if (enabled)
            {
                var mOriginal = AccessTools.Method(typeof(SaveSelect), "Start");
                var mPostfix = SymbolExtensions.GetMethodInfo(() => AddButtons());

                harmony.Patch(mOriginal, new HarmonyMethod(mPostfix), null);
            }
            else
            {
                harmony.UnpatchSelf();
            }
        }

        public override void OnLoadedSave()
        {
            OnClick();
        }
        public static void AddButtons()
        {
            //610 603.084 0
            //610 759.5236 0
            var ss = GameObject.FindObjectOfType<SaveSelect>();

            GameObject a = ss.fileTexts[0].transform.parent.gameObject;
            var d = new GameObject("Content");
            d.transform.parent = a.transform.parent;
            d.AddComponent<RectTransform>();

            var subTitle = GameObject.Instantiate(GameObject.Find("Title"), GameObject.Find("Title").transform.parent);
            subTitle.GetComponent<TextMeshProUGUI>().fontSize = 22;
            subTitle.transform.position = new Vector3(959.9999f, 860.9382f, 0);
            subTitle.GetComponent<TextMeshProUGUI>().text = "When creating a new File, it will have the contents of the first level.\nI do not know how to fix this so until I find a fix you need to remove every object.\n(this will not override the first level)";

            int c = 0;
            foreach (var item in ss.fileTexts)
            {
                if (c != 0)
                {
                    GameObject.Destroy(item.transform.parent.gameObject);
                }
                c++;
            }

            a.GetComponent<Button>().onClick.RemoveAllListeners();

            ss.fileTexts = new TextMeshProUGUI[60];

            float yStart = a.transform.position.y;
            float yInc = yStart - 603.084f;

            int x = 0;
            int y = 1;
            for (int i = 0; i < int.Parse(PlayerPrefs.GetString("InfLevelsCount", "50")); i++)
            {
                var b = GameObject.Instantiate(a, d.transform);
                b.GetComponent<Button>().onClick.RemoveAllListeners();
                //FileButton
                int h = i;
                b.GetComponent<Button>().onClick.AddListener(delegate { LevelEditor.currentSave = (h + 1).ToString(); ss.FileButton((h + 1).ToString()); });
                ss.fileTexts[i] = b.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

                if (x == 1)
                {
                    b.transform.position = new Vector3(1310, yStart - (yInc * y), 0);
                    x = 0;
                    y++;
                }
                else
                {
                    b.transform.position = new Vector3(610, yStart - (yInc * y), 0);
                    x++;
                }

                b.transform.position += new Vector3(0, 115, 0);
            }

            y--;

            a.transform.parent.gameObject.AddComponent<Image>().color = new Color(1,1,1, 0.5471698f);
            a.transform.parent.gameObject.AddComponent<Mask>();
            a.transform.parent.GetComponent<Mask>().showMaskGraphic = true;
            a.transform.parent.gameObject.AddComponent<ScrollRect>();
            a.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(1420, 800);
            a.transform.parent.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -127);

            a.transform.parent.GetComponent<ScrollRect>().content = d.GetComponent<RectTransform>();
            a.transform.parent.GetComponent<ScrollRect>().horizontal = false;

            d.transform.position = new Vector3(0, -10 - yInc, 0);
            d.GetComponent<RectTransform>().sizeDelta = new Vector2(1420, yInc * (y + 0));

            GameObject.Destroy(a.gameObject);

            //Size: 1420 800
            //PosOffset: 0 -127
        }
    }
}

public class InfLevelsCount : ModuleType.TextOption
{
    public InfLevelsCount()
    {
        name = "InfLevelsCount";
        text = PlayerPrefs.GetString("InfLevelsCount", "50");
        numberOnly = true;
    }

    public override void Update()
    {
        PlayerPrefs.SetString("InfLevelsCount", text);
    }
}
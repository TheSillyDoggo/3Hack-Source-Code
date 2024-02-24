using HarmonyLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules
{
    [System.Serializable]
    public class DemonList : Module
    {
        public DemonList()
        {
            name = "Demonlist";
            description = "Adds a demonlist button to the menu";

            var harmony = new HarmonyLib.Harmony("com.Explodingbill.DemonlistCreate");

            var mOriginal = AccessTools.Method(typeof(OnlineLevelsHub), "Awake");
            var mPostfix = SymbolExtensions.GetMethodInfo(() => Create());

            //harmony.Patch(mOriginal, new HarmonyMethod(mPostfix), null);
        }

        public static bool showingMenu;
        public static GameObject menu;
        public static GameObject title;
        public static GameObject listBtn;
        public static GameObject levelTitle;
        public static GameObject percentText;
        public static int progress, progressIncreate, currentId;
        public static string value = "";

        public static void Create()
        {
            GameObject btn = new GameObject() { name = "3Hack Demon"};

            btn.transform.parent = GameObject.Find("BeforeClick").transform;

            btn.AddComponent<RectTransform>().anchorMin = Vector2.zero;
            btn.GetComponent<RectTransform>().anchorMax = Vector2.zero;
            btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(-720, -410);
            btn.GetComponent<RectTransform>().sizeDelta = new Vector2(282, 40 * 2);

            btn.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            btn.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            btn.GetComponent<Image>().type = Image.Type.Sliced;
            btn.AddComponent<Button>().onClick.AddListener( delegate { OnButtonClicked(); } );

            GameObject difficulty = new GameObject() 
            { name = "Difficulty" };

            difficulty.transform.parent = btn.transform;

            difficulty.AddComponent<RectTransform>().anchorMin = Vector2.zero;
            difficulty.GetComponent<RectTransform>().anchorMax = Vector2.zero;
            difficulty.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 40);
            difficulty.GetComponent<RectTransform>().sizeDelta = new Vector2(35 * 2, 35 * 2);

            difficulty.AddComponent<Image>().sprite = GameObject.FindObjectOfType<OnlineLevelsHub>().editor.difficultySprites[GameObject.FindObjectOfType<OnlineLevelsHub>().editor.difficultySprites.Length - 1];
            difficulty.GetComponent<Image>().type = Image.Type.Sliced;
            difficulty.GetComponent<Image>().raycastTarget = false;

            GameObject text = new GameObject()
            { name = "Text" };

            text.transform.parent = btn.transform;

            text.AddComponent<RectTransform>().anchorMin = Vector2.zero;
            text.GetComponent<RectTransform>().anchorMax = Vector2.zero;
            text.GetComponent<RectTransform>().anchoredPosition = new Vector2(440, 40);
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 35 * 2);

            text.AddComponent<TextMeshProUGUI>().text = "Demon\nList";
            text.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            text.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            text.GetComponent<TextMeshProUGUI>().fontSize = 30;
            //difficulty.AddComponent<Button>();

            CreateMenu();
        }

        public static void CreateMenu()
        {
            menu = new GameObject() { name = "3Hack Demon Menu" };
            menu.SetActive(showingMenu);


            menu.transform.parent = GameObject.Find("Canvas").transform;

            menu.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            menu.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            menu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            menu.GetComponent<RectTransform>().sizeDelta = new Vector2(1147.612f, 710.1732f);

            menu.AddComponent<Image>().color = new Color(0, 0, 0, 0.6745f);

            //0 -312.1

            title = new GameObject() { name = "Title" };

            title.transform.parent = menu.transform;

            title.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            title.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            title.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            title.GetComponent<RectTransform>().sizeDelta = new Vector2(1147.612f, 710.1732f - 30);

            title.AddComponent<TextMeshProUGUI>().text = "Demon Roulette";
            title.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            title.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Top;
            title.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            title.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;

            title.GetComponent<TextMeshProUGUI>().fontSize = 60;


            GameObject list = new GameObject() { name = "List" };

            list.transform.parent = menu.transform;

            list.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            list.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            list.GetComponent<RectTransform>().anchoredPosition = new Vector2(452.1f, -312.1f);
            list.GetComponent<RectTransform>().sizeDelta = new Vector2(282 * 0.7f, 80 * 0.7f);

            list.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            list.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            list.GetComponent<Image>().type = Image.Type.Sliced;
            list.AddComponent<Button>().onClick.AddListener(delegate { ToggleList(); });

            GameObject listText = new GameObject() { name = "Text" };

            listText.transform.parent = list.transform;

            listText.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            listText.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            listText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            listText.GetComponent<RectTransform>().sizeDelta = new Vector2(2820, 400);

            listText.AddComponent<TextMeshProUGUI>().text = "List";
            listText.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            listText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            listText.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            listText.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;


            GameObject btn = new GameObject() { name = "Close" };

            btn.transform.parent = menu.transform;

            btn.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            btn.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            btn.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -312.1f);
            btn.GetComponent<RectTransform>().sizeDelta = new Vector2(282, 40 * 2);

            btn.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            btn.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            btn.GetComponent<Image>().type = Image.Type.Sliced;
            btn.AddComponent<Button>().onClick.AddListener(delegate { Close(); });

            GameObject text = new GameObject() { name = "Text" };

            text.transform.parent = btn.transform;

            text.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            text.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(2820, 400);

            text.AddComponent<TextMeshProUGUI>().text = "Close";
            text.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            text.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            text.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            text.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;

            text.GetComponent<TextMeshProUGUI>().fontSize = 40;

            listBtn = list;

            GameObject scrmenu = new GameObject() { name = "Scroll" };
            scrmenu.transform.parent = menu.transform;

            scrmenu.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            scrmenu.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            scrmenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            scrmenu.GetComponent<RectTransform>().sizeDelta = new Vector2(1076.228f, 595.0993f * 0.8f);

            scrmenu.AddComponent<Image>().color = new Color(0, 0, 0, 0.5961f);

            levelTitle = new GameObject() { name = "Title" };

            levelTitle.transform.parent = menu.transform;

            levelTitle.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            levelTitle.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            levelTitle.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            levelTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(1076.228f * 0.75f, 595.0993f * 0.75f);

            levelTitle.AddComponent<TextMeshProUGUI>().text = "Level name\n<size=60%>By Level Author";
            levelTitle.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            levelTitle.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Top;
            levelTitle.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            levelTitle.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;

            levelTitle.GetComponent<TextMeshProUGUI>().fontSize = 60;

            //1076.228f, 595.0993f


            GameObject btnPlay = new GameObject() { name = "Play" };

            btnPlay.transform.parent = menu.transform;

            btnPlay.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            btnPlay.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            btnPlay.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -20);
            btnPlay.GetComponent<RectTransform>().sizeDelta = new Vector2(282, 40 * 2);

            btnPlay.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            btnPlay.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            btnPlay.GetComponent<Image>().type = Image.Type.Sliced;
            btnPlay.AddComponent<Button>().onClick.AddListener(delegate { PlayPressed(); Close(); });

            GameObject textPlay = new GameObject() { name = "Text" };

            textPlay.transform.parent = btnPlay.transform;

            textPlay.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            textPlay.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            textPlay.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            textPlay.GetComponent<RectTransform>().sizeDelta = new Vector2(2820, 400);

            textPlay.AddComponent<TextMeshProUGUI>().text = "Play";
            textPlay.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            textPlay.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            textPlay.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            textPlay.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;

            textPlay.GetComponent<TextMeshProUGUI>().fontSize = 40;

            CreateCornerButtons();


            percentText = new GameObject() { name = "Percent" };

            percentText.transform.parent = menu.transform;

            percentText.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            percentText.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            percentText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            percentText.GetComponent<RectTransform>().sizeDelta = new Vector2(1076.228f * 0.75f, 595.0993f * 0.75f);

            percentText.AddComponent<TextMeshProUGUI>().text = progress + progressIncreate + "%";
            percentText.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            percentText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Bottom;
            percentText.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            percentText.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;

            percentText.GetComponent<TextMeshProUGUI>().fontSize = 30;
        }

        public static void Increase(int am)
        {
            progressIncreate += am;

            progressIncreate = Mathf.Clamp(progressIncreate, 0, 100 - progress);

            percentText.GetComponent<TextMeshProUGUI>().text = progress + progressIncreate + "%";
        }

        public static void CreateCornerButtons()
        {
            GameObject list = new GameObject() { name = "Next" };

            list.transform.parent = menu.transform;

            list.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            list.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            list.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -203.9723f);
            list.GetComponent<RectTransform>().sizeDelta = new Vector2(70 * 0.7f, 70 * 0.7f);

            list.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            list.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            list.GetComponent<Image>().type = Image.Type.Sliced;
            list.AddComponent<Button>().onClick.AddListener(delegate { Increase(1); });

            GameObject listText = new GameObject() { name = "Text" };

            listText.transform.parent = list.transform;

            listText.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            listText.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            listText.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            listText.GetComponent<RectTransform>().sizeDelta = new Vector2(70 * 0.7f, 70 * 0.7f);

            listText.AddComponent<TextMeshProUGUI>().text = "+";
            listText.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            listText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            listText.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            listText.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;


            GameObject listB = new GameObject() { name = "Previous" };

            listB.transform.parent = menu.transform;

            listB.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            listB.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            listB.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -203.9723f);
            listB.GetComponent<RectTransform>().sizeDelta = new Vector2(70 * 0.7f, 70 * 0.7f);

            listB.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            listB.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            listB.GetComponent<Image>().type = Image.Type.Sliced;
            listB.AddComponent<Button>().onClick.AddListener(delegate { Increase(-1); });

            GameObject listTextB = new GameObject() { name = "Text" };

            listTextB.transform.parent = listB.transform;

            listTextB.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            listTextB.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            listTextB.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            listTextB.GetComponent<RectTransform>().sizeDelta = new Vector2(70 * 0.7f, 70 * 0.7f);

            listTextB.AddComponent<TextMeshProUGUI>().text = "-";
            listTextB.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            listTextB.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            listTextB.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            listTextB.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;



            GameObject listC = new GameObject() { name = "Next" };

            listC.transform.parent = menu.transform;

            listC.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            listC.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            listC.GetComponent<RectTransform>().anchoredPosition = new Vector2(441.1732f, -203.9723f);
            listC.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 49);

            listC.AddComponent<Image>().sprite = GameObject.Find("Go Button").GetComponent<Image>().sprite;
            listC.GetComponent<Image>().color = GameObject.Find("Go Button").GetComponent<Image>().color;
            listC.GetComponent<Image>().type = Image.Type.Sliced;
            listC.AddComponent<Button>().onClick.AddListener(delegate { Increase(1); });

            GameObject listTextC = new GameObject() { name = "Text" };

            listTextC.transform.parent = listC.transform;

            listTextC.AddComponent<RectTransform>().anchorMin = Vector2.one * 0.5f;
            listTextC.GetComponent<RectTransform>().anchorMax = Vector2.one * 0.5f;
            listTextC.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            listTextC.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 49);

            listTextC.AddComponent<TextMeshProUGUI>().text = "Next";
            listTextC.GetComponent<TextMeshProUGUI>().font = ModMain.fonts[0];
            listTextC.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
            listTextC.GetComponent<TextMeshProUGUI>().raycastTarget = false;
            listTextC.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;
        }

        public static void ToggleList()
        {
            if (listBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "List")
            {
                listBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Roulette";
                title.GetComponent<TextMeshProUGUI>().text = "Demonlist";
            }
            else
            {
                listBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "List";
                title.GetComponent<TextMeshProUGUI>().text = "Demon Roulette";
            }            
        }

        public static void Next()
        {
            progress += progressIncreate;

            progressIncreate = 0;

            progress = 0;

            currentId++;

            JObject rss = JObject.Parse(value);

             //name creator
            levelTitle.GetComponent<TextMeshProUGUI>().text = $"{rss[$"_{currentId}name"]}\n<size=60%>By {rss[$"_{currentId}creator"]}";
        }

        public static void OnButtonClicked()
        {
            showingMenu = true;

            menu.SetActive(showingMenu);

            if (value == "")
            {
                GetData();
            }
        }

        public static void Close()
        {
            showingMenu = false;

            menu.SetActive(showingMenu);
        }

        public static void PlayPressed()
        {
            JObject rss = JObject.Parse(value);

            GameObject.FindObjectOfType<OnlineLevelsHub>().idInput.text = (string)rss["_1"];
            GameObject.FindObjectOfType<OnlineLevelsHub>().GoButtonPressed();
        }

        public static async Task GetData()
        {
            string url = "https://rpgserver-e6a44-default-rtdb.firebaseio.com/List.json";

            Debug.Log("Begin Request");
            levelTitle.GetComponent<TextMeshProUGUI>().text = "Loading...";
            try
            {
                //We will now define your HttpClient with your first using statement which will use a IDisposable.
                using (HttpClient client = new HttpClient())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (data != null)
                            {
                                //Now log your data in the console
                                //Console.WriteLine("data------------{0}", data);
                                value = data;
                                Debug.Log(data);

                                Next();
                            }
                            else
                            {
                                levelTitle.GetComponent<TextMeshProUGUI>().text = "Error Loading";
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.Log(exception.Message);
            }
        }
    }
}

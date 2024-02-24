using MelonLoader;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using System.IO;

[assembly: MelonInfo(typeof(ModMain), "3Hack", "ersion here lol :)", "Explodingbill")]
[assembly: MelonGame(null, null)]

public class ModMain : MelonMod
{
    public static bool initializedFonts;
    public static List<TMP_FontAsset> fonts = new List<TMP_FontAsset>();
    public static Camera camera;

   
    public static float scale = 0.5f;
    public Rect windowRect = new Rect(20, 20, 230.0f * scale, 50 * scale);

    public static ClientWindowManager cwm = new ClientWindowManager();

    public static Scene_Switcher scs = new Scene_Switcher();

    public static bool showClickGUI;

    public static KeyCode clickGUIKeyCode = KeyCode.Tab;

    public static bool splashed, tutorial;
    //public static Replay replay = new Replay();

    public static Version version = new Version("1.2");

    public static string branch = "";
    public static string statusCheck = "";

    public static TextMeshProUGUI tt;

    public override void OnApplicationStart()
    {
        

        statusCheck = "Checking For Updates...";

        AttemptCounter.Initialize();
        NoclipHook.DoPatching();

        _DiscordRPC.Initialize();

        try
        {
            Save.LoadFromFile();
        }
        catch(System.Exception e)
        {
            Debug.Log(e.Message);
        }

        CheckForUpdates();

        tutorial = PlayerPrefs.HasKey("Tutorial");
    }

    public override void OnApplicationQuit()
    {
        Save.SaveToFile();
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tutorial = true;
            PlayerPrefs.SetString("Tutorial", "Hey, VSauce Michael here, I know what you did...");
        }

        StatusMGR.Update();
         
        if (Input.GetKeyDown(clickGUIKeyCode))
        {
            showClickGUI = !showClickGUI;
        }

        cwm.Update();
    }


    public override void OnLateUpdate()
    {
        cwm.LateUpdate();
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        if (!initializedFonts)
        {
            initializedFonts = true;
            foreach (var item in GameObject.FindObjectsOfType<TextMeshProUGUI>())
            {
                if (!fonts.Contains(item.font))
                {
                    fonts.Add(item.font);
                }
            }

            StatusMGR.Init();
        }
        StatusMGR.OnSceneChanged(buildIndex, sceneName);
        NoclipHook.OnSceneChanged();
        camera = GameObject.FindObjectOfType<Camera>();

        _DiscordRPC.UpdatePresence(sceneName);

        PauseMenuManager.paused = false;

        cwm.OnSceneChanged(buildIndex, sceneName);

        if (sceneName == "Menu")
        {
            if (!splashed)
            {
                splashed = true;

                //SplashScreen.Load();
            }

            GameObject.Find("Version Text").GetComponent<TextMeshProUGUI>().text += " (Modded by Explodingbill)";

            //Application.OpenURL("https://discord.com/invite/tC9r89h3zp");
            GameObject.Find("Version Text").GetComponent<RectTransform>().sizeDelta += new Vector2(500, 0);
            GameObject.Find("Version Text").GetComponent<RectTransform>().anchoredPosition += new Vector2(500 / 2, 0);

            GameObject go = GameObject.Instantiate(GameObject.Find("Version Text"), GameObject.Find("Version Text").transform.parent);
            go.name = "3Hack Version Text";

            go.GetComponent<TextMeshProUGUI>().text = $"3Hack v{version.ToString()} {branch} {statusCheck}";

            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(405, 1080);

            tt = go.GetComponent<TextMeshProUGUI>();

            tt.overflowMode = TextOverflowModes.Overflow;

            go.transform.SetSiblingIndex(2);
        }

        Modules.ShowAttemptCount.CreateText();
    }

    public override void OnGUI()
    {
        DrawUtils.Update();

        if (Modules.Keybinds.editing)
        {
            DrawUtils.DrawRect(new Rect(0, 0, Screen.width, Screen.height), new Color(0, 0, 0, 0.75f));
        }

        GUI.skin.textArea.fontSize = Mathf.RoundToInt(32 * scale);
        
        cwm.Draw();

        if (Modules.Keybinds.editing)
        {
            string a = "None Selected\n";
            if (Modules.Keybinds.module != null)
            {
                a = Modules.Keybinds.module.name + " Selected\n";
            }
            GUI.skin.label.fontSize = Mathf.RoundToInt(45 * scale);
            GUI.skin.label.alignment = TextAnchor.LowerRight;
            DrawUtils.DrawText(new Rect(Screen.width - 20 - 500, Screen.height - 20 - 300, 500, 300), a + "Press Escape To Stop Editing\nPress Backspace To Reset Keybind\nRight-Click On A Module To Select It", DrawUtils.Accent());
            GUI.skin.label.fontSize = Mathf.RoundToInt(32 * scale);
        }

        if (!tutorial)
        {
            Rect tutRect = new Rect(10, Screen.height / 2, 310, 60);
            GUI.skin.label.fontSize = Mathf.RoundToInt(32 * scale);
            GUI.skin.label.alignment = TextAnchor.MiddleLeft;

            DrawUtils.DrawRect(tutRect, new Color(0, 0, 0, 0.35f));
            DrawUtils.DrawText(tutRect, " Press 'Tab' to open GUI\n (This can be rebinded in the keybinds menu)", DrawUtils.Accent());
        }

        //DrawCustomize.Draw();

        
    }

    public static async Task CheckForUpdates()
    {
        string url = "https://le3hackserver-default-rtdb.firebaseio.com/mainVer.json";

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
                            if (version.ToString() == data.Substring(1, data.Length - 2))
                            {
                                statusCheck = "Up To Date";
                            }
                            else
                            {
                                statusCheck = $"New Version Available (v{data.Substring(1, data.Length - 2)})";
                            }

                            if (tt != null)
                            {
                                tt.text = $"3Hack v{version.ToString()} {branch} {statusCheck}";
                            }
                            Debug.Log(data);
                        }
                        else
                        {
                            statusCheck = "Error Finding Version";
                            if (tt != null)
                            {
                                tt.text = $"3Hack v{version.ToString()} {branch} {statusCheck}";
                            }
                            
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

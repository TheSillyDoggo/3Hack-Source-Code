using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Windows
{
    public class Status : Window
    {
        private static int mouseclicks = 0;

        public static Window window;
        public Status()
        {
            window = this;
            rect.position = new UnityEngine.Vector2(230 + 50 + 20 + 50 + 20 + 50 + 20, 20);
            name = "Status";

            modules.Add(new Module() {name = "FPS", description = "Right click to change the side on the screen" });
            modules.Add(new Module() { name = "Accuracy", description = "Right click to change the side on the screen" });
            modules.Add(new Module() { name = "Deaths", description = "Right click to change the side on the screen" });
            modules.Add(new Module() { name = "Attempts", description = "Right click to change the side on the screen" });
            modules.Add(new Module() { name = "Clicks", description = "Right click to change the side on the screen" });
            modules.Add(new Module() { name = "Frames", description = "Right click to change the side on the screen" });
            modules.Add(new Module() { name = "Input", description = "Right click to change the side on the screen" });

            modules.Add(new Module() { name = "Message", description = "Right click to change the side on the screen" });


            foreach (var item in modules)
            {
                var option = new ModuleType.DualSidedOption();
                option.name1 = "Left";
                option.name2 = "Right";
                option.name = item.name + "Side";
                item.settings.Add(option);
            }


            modules.Add(new MessageInput());
        }
        
        public static void UpdateText(TextMeshProUGUI text)
        {
            StatusMGR.tltext.text = "";
            StatusMGR.trtext.text = "";

            if (StatusMGR.isInScene)
            {
                if (window.modules[0].enabled)
                {
                    DrawSidedText("FPS: " + Mathf.Round((1.0f / Time.unscaledDeltaTime)) + "\n", window.modules[0]);
                }
                if (window.modules[1].enabled)
                {
                    DrawSidedText("Accuracy: " + Decimal.Round(Decimal.Parse((((float)(StatusMGR.frames - NoclipHook.deathCount) / (float)StatusMGR.frames) * 100).ToString()), 2) + "%\n", window.modules[1]);
                }
                if (window.modules[2].enabled)
                {
                    DrawSidedText("Deaths: " + NoclipHook.deathCount + "\n", window.modules[2]);
                }
                if (window.modules[3].enabled)
                {
                    DrawSidedText("Attempt " + AttemptCounter.attempts + "\n", window.modules[3]);
                }
                if (window.modules[4].enabled)
                {
                    DrawSidedText("Clicks: " + mouseclicks + "\n", window.modules[4]);
                }
                if (Replay.replayMode.rightOn)
                {
                    if (window.modules[5].enabled)
                    {
                        DrawSidedText("Frame: " + Windows.Replay.frame + " / " + Windows.Replay.inputCheck.Count + "\n", window.modules[5]);
                    }
                    if (window.modules[6].enabled)
                    {
                        DrawSidedText("Read Input: " + Windows.Replay.inputCheck[Replay.frame] + "\n", window.modules[6]);
                    }
                }

                if (window.modules[window.modules.Count - 2].enabled)
                {
                    DrawSidedText(PlayerPrefs.GetString("MessageText") + "\n", window.modules[window.modules.Count - 2]);
                }
            }
        }

        public static void DrawSidedText(string text, Module option)
        {
            if (option.settings[option.settings.Count - 1].enabled)
            {
                StatusMGR.trtext.text += text;
            }
            else
            {
                StatusMGR.tltext.text += text;
            }
        }

        public override void OnUpdate()
        {
            if (!PauseMenuManager.paused)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) mouseclicks++;
            }
        }

        public override void OnSceneChanged(int buildIndex, string sceneName)
        {
            mouseclicks = 0;
        }
    }
}

public class MessageInput : ModuleType.TextInput
{
    public MessageInput()
    {
        text = PlayerPrefs.GetString("MessageText", "Type a message here");
        
    }

    public override void Update()
    {
        PlayerPrefs.SetString("MessageText", text);
    }
}
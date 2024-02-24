using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Windows
{
    public class Replay : Window
    {
        public static Modules.SelectedReplay selectedReplay;
        public static Modules.ReplayMode replayMode;
        public static Modules.ReplaySave replaySave;

        public static int frame;
        public static string scene;

        public static List<bool> inputCheck;


        public Replay()
        {
            rect.position = new UnityEngine.Vector2(230 + 230 + 20 + 230 + 20 + 230 + 20 + 230 + 20, 20);
            name = "Replay";

            selectedReplay = new Modules.SelectedReplay();
            replayMode = new Modules.ReplayMode();
            replaySave = new Modules.ReplaySave();

            modules.Add(selectedReplay);
            modules.Add(replayMode);
            modules.Add(replaySave);
        }

        public override void OnLateUpdate()
        {
            if (!replayMode.rightOn)
            {
                if (GameObject.FindObjectOfType<PlayerScript>() != null)
                {
                    if (!PauseMenuManager.paused)
                    {
                        frame++;

                        inputCheck.Add(GameObject.FindObjectOfType<PlayerScript>().jumpInput);
                    }
                }
            }
            else
            {
                if (GameObject.FindObjectOfType<PlayerScript>() != null)
                {
                    if (!PauseMenuManager.paused)
                    {
                        frame++;
                        if (frame < inputCheck.Count - 1)
                        { 
                            GameObject.FindObjectOfType<PlayerScript>().jumpInput = inputCheck[frame];
                        }
                    }
                }
            }
        }

        public override void OnSceneChanged(int buildIndex, string sceneName)
        {
            frame = 0;
            scene = sceneName;

            if (!replayMode.rightOn)
            {
                /*string s = "";

                foreach (var item in Windows.Replay.inputCheck)
                {
                    s += item + ";";
                }

                string path = Application.dataPath;

                if (Application.platform == RuntimePlatform.OSXPlayer)
                {
                    path += "/../../";
                }
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    path += "/../";
                }

                path += "Replays/";
                path += Windows.Replay.selectedReplay.text;
                path += ".replay";

                File.WriteAllText(path, s);*/

                if (GameObject.FindObjectOfType<PlayerScript>() != null)
                    inputCheck = new List<bool>();
            }
            else
            {
                string path = Application.dataPath;

                if (Application.platform == RuntimePlatform.OSXPlayer)
                {
                    path += "/../../";
                }
                else if (Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    path += "/../";
                }

                path += "Replays/";
                path += selectedReplay.text;
                path += ".replay";

                inputCheck = new List<bool>();

                foreach (var item in File.ReadAllText(path).Split(";".ToCharArray()))
                {
                    inputCheck.Add(bool.Parse(item));
                }

                UnityEngine.Debug.Log(inputCheck);
            }
            frame = 0;
            scene = sceneName;
        }
    }
}
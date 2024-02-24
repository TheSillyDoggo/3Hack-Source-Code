using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Windows
{
    public class Speedhack : Window
    {
        public Speedhack()
        {
            rect.position = new UnityEngine.Vector2(230 + 50 + 20, 20);
            name = "Speedhack";

            modules.Add(new SpeedhackInput());
            modules.Add(new SpeedhackButton());
            modules.Add(new SpeedhackMusic());
        }
    }
}

public class SpeedhackInput : ModuleType.TextInput
{
    public SpeedhackInput()
    {
        text = PlayerPrefs.GetString("SpeedhackValue", "1");
        numberOnly = true;
    }

    public override void Update()
    {
        PlayerPrefs.SetString("SpeedhackValue", text);
    }
}

public class SpeedhackButton : Module
{
    public static bool isEnabled;

    public SpeedhackButton()
    {
        name = "Enabled";
    }

    public override void Update()
    {
        isEnabled = enabled;
        if (enabled)
        {
            if (PauseMenuManager.paused)
            {
                Time.timeScale = 0;// = PlayerPrefs.GetString("SpeedhackValue", "1");
            }
            else
            {
                Time.timeScale = float.Parse(PlayerPrefs.GetString("SpeedhackValue", "1"));
            }
        }
        else
        {
            if (PauseMenuManager.paused)
            {
                Time.timeScale = 0;// = PlayerPrefs.GetString("SpeedhackValue", "1");
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}

public class SpeedhackMusic : Module
{
    public SpeedhackMusic()
    {
        name = "Speed Music";
    }

    public override void Update()
    {
        if (enabled && SpeedhackButton.isEnabled)
        {
            foreach (var item in GameObject.FindObjectsOfType<AudioSource>())
            {
                item.pitch = float.Parse(PlayerPrefs.GetString("SpeedhackValue", "1"));
            }
        }
        else
        {
            foreach (var item in GameObject.FindObjectsOfType<AudioSource>())
            {
                item.pitch = 1;
            }
        }
    }
}
using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Discord RPC https://www.nuget.org/packages/DiscordRichPresence/

public class _DiscordRPC
{
    public static DiscordRpcClient client;
    public static bool isInitialized = true;

    public static void Initialize()
    {
        try
        {
            client = new DiscordRpcClient("1017689651378667561");

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "Loading Rich Presence",
                State = "",
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "3dash_big",
                    LargeImageText = "3Dash"
                }
            });
        }
        catch
        {
            isInitialized = true;
        }
    }

    public static void UpdatePresence(string sceneName)
    {
        if (!isInitialized)
            return;

        client.SetPresence(new RichPresence()
        {
            Details = "Playing A Level",
            State = sceneName + " by Deluge Drop",
            Assets = new DiscordRPC.Assets()
            {
                LargeImageKey = "3dash_big",
                LargeImageText = "3Dash"
            }
        });
        client.UpdateStartTime();

        if (sceneName == "Menu")
        {
            client.SetPresence(new RichPresence()
            {
                Details = "Browsing The Menus",
                State = "",
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "3dash_big",
                    LargeImageText = "3Dash"
                }
            });
        }

        if (sceneName == "Online Levels Hub")
        {
            client.SetPresence(new RichPresence()
            {
                Details = "Browsing Online Levels",
                State = "",
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "3dash_big",
                    LargeImageText = "3Dash"
                }
            });
        }

        if (sceneName == "Online Levels Player")
        {
            client.SetPresence(new RichPresence()
            {
                Details = "Playing A Level",
                State = LevelEditor.levelName + " by " + LevelEditor.levelAuthor + " (" + LevelEditor.currentID + ")",
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "3dash_big",
                    LargeImageText = "3Dash"
                }
            });
        }
        if (sceneName == "Playtester")
        {
            client.SetPresence(new RichPresence()
            {
                Details = "Playtesting A Level",
                State = LevelEditor.levelName,
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "3dash_big",
                    LargeImageText = "3Dash"
                }
            });
        }

        if (sceneName == "Save Select" || sceneName == "HUB" || sceneName == "2D Editor" || sceneName == "Path Editor" || sceneName == "Camera Animator Hub" || sceneName == "Camera Animator" || sceneName == "Level Settings" || sceneName == "Submission")
        {
            client.SetPresence(new RichPresence()
            {
                Details = "Making A Level",
                State = "",
                Assets = new DiscordRPC.Assets()
                {
                    LargeImageKey = "3dash_big",
                    LargeImageText = "3Dash"
                }
            });
        }
    }
}


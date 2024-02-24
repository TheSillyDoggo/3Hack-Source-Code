using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;
using HarmonyLib;

public class AttemptCounter
{
    public static int attempts;

    public static void Initialize()
    {
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

        var harmony = new HarmonyLib.Harmony("com.Explodingbill.Attempt");

        var mOriginal = AccessTools.Method(typeof(PlayerScript), "Awake");
        var mPostfix = SymbolExtensions.GetMethodInfo(() => MyPostfix());

        harmony.Patch(mOriginal, null, new HarmonyMethod(mPostfix));
    }

    public static void MyPostfix()
    {
        attempts++;
    }

    private static void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        
        if (GameObject.FindObjectOfType<PlayerScript>() == null)
        {
            attempts = 0;
        }
    }
}

using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class NoclipHook
{
    public static int deathCount;
    public static void DoPatching()
    {
        var harmony = new HarmonyLib.Harmony("com.Explodingbill.NoclipPatch");

        var mOriginal = AccessTools.Method(typeof(PlayerScript), "Die");
        var mPrefix = SymbolExtensions.GetMethodInfo(() => MyPrefix());
        var mPostfix = SymbolExtensions.GetMethodInfo(() => MyPostfix());

        harmony.Patch(mOriginal, new HarmonyMethod(mPrefix), new HarmonyMethod(mPostfix));

        var mOriginalCollision = AccessTools.Method(typeof(PlayerScript), "OnCollisionEnter", new Type[] { typeof(Collision) });
        var mPrefixCollision = SymbolExtensions.GetMethodInfo(() => MyPrefix());
        var mPostfixCollision = SymbolExtensions.GetMethodInfo(() => OnCollisionEnter(null));

        harmony.Patch(mOriginalCollision, new HarmonyMethod(mPrefix), new HarmonyMethod(mPostfixCollision));

        var mOriginalWin = AccessTools.Method(typeof(PlayerScript), "Win");
        var mPostfixWin = SymbolExtensions.GetMethodInfo(() => OnWin());

        harmony.Patch(mOriginalWin, new HarmonyMethod(mPostfixWin), null);
    }

    private static bool OnWin()
    {
        PlayerScript plr = GameObject.FindObjectOfType<PlayerScript>();
        if (!plr.noDeath || Modules.Noclip.isNoclipEnabled)
        {
            plr.dead = true;
            plr.transform.parent.gameObject.SetActive(false);
            UnityEngine.Object.Instantiate<GameObject>(plr.WinFX, plr.transform.position, plr.transform.rotation);
            UnityEngine.Object.Instantiate<GameObject>(plr.cam, plr.cam.transform.position, plr.cam.transform.rotation);
        }

        return false;
    }

    public static void MyPrefix()
    {
        
    }

    public static void OnSceneChanged()
    {
        deathCount = 0;
    }

    public static void MyPostfix()
    {
        deathCount++;
    }

    public static void OnCollisionEnter(Collision other)
    {
        if (Modules.BetterNoclip.isEnabled)
        {
            if (other.gameObject.tag == "Hazard")
            {
                UnityEngine.Object.Destroy(other.collider);
            }
        }
    }
}

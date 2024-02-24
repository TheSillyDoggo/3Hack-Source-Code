using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Modules
{
    public class SwapCamMode : Module
    {
        public int zOrder = 0;
        public static SwapCamMode instance;
        public SwapCamMode()
        {
            name = "Cam Move Mode";
            description = "Switches Between WASD and Arrow Keys for moving the camera in the editor";

            settings.Add(new ModuleType.DualSidedOption() { name = "camMoveModeOption", name1 = "WASD", name2 = "Arrows" });

            instance = this;

            var harmony = new HarmonyLib.Harmony("com.Explodingbill.EditorCamUpdate");

            var mOriginal = AccessTools.Method(typeof(FlatCamera), "Update");
            var mPostfix = SymbolExtensions.GetMethodInfo(() => UpdatePatch(null));
            var preFix = SymbolExtensions.GetMethodInfo(() => UpdatePrePatch(null));

            harmony.Patch(mOriginal, new HarmonyMethod(preFix), new HarmonyMethod(mPostfix));
        }

        public static void UpdatePrePatch(FlatCamera __instance)
        {
            if (instance.enabled)
            {
                __instance.camSpdNormal = 0;
                __instance.camSpdFast = 0;
            }
            else
            {
                __instance.camSpdNormal = 20;
                __instance.camSpdFast = 300;
            }
        }

        public static void UpdatePatch(FlatCamera __instance)
        {
            if (!instance.enabled)
                return;
            //300 fast
            //20 slow

            __instance.camSpdNormal = 20;
            __instance.camSpdFast = 300;

            float d = __instance.camSpdNormal;

            bool key = Input.GetKey(KeyCode.LeftShift);
            if (key)
            {
                d = __instance.camSpdFast;
            }
            bool key2 = Input.GetKey(instance.settings[0].enabled ? KeyCode.LeftArrow : KeyCode.A);
            if (key2)
            {
                __instance.transform.position += Vector3.left * d * Time.deltaTime;
            }
            bool key3 = Input.GetKey(instance.settings[0].enabled ? KeyCode.RightArrow : KeyCode.D);
            if (key3)
            {
                __instance.transform.position += Vector3.right * d * Time.deltaTime;
            }
            bool key4 = Input.GetKey(instance.settings[0].enabled ? KeyCode.UpArrow : KeyCode.W);
            if (key4)
            {
                __instance.transform.position += Vector3.up * d * Time.deltaTime;
            }
            bool key5 = Input.GetKey(instance.settings[0].enabled ? KeyCode.DownArrow : KeyCode.S);
            if (key5)
            {
                __instance.transform.position += Vector3.down * d * Time.deltaTime;
            }
        }

        public static Vector3 StringToVector3(string sVector)
        {
            // Remove the parentheses
            if (sVector.StartsWith("(") && sVector.EndsWith(")"))
            {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }

            // split the items
            string[] sArray = sVector.Split(',');

            // store as a Vector3
            Vector3 result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));

            return result;
        }

        public override void Update()
        {
            if (enabled && Windows.Creator.inEditor)
            {
                if (Windows.Creator.editor != null)
                {
                    /*if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        zOrder--;
                    }
                    if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        zOrder++;
                    }

                    zOrder = Mathf.Clamp(zOrder, -32767, 32767);

                    if (Windows.Creator.editor.zColors.Length < 10)
                    {
                        Windows.Creator.editor.zColors = new Color[32767 + 32676 + 1];
                        for (int i = 0; i < 32767 + 32767 + 1; i++)
                        {
                            Windows.Creator.editor.zColors[i] = new Color(0.6f, 0.8067f, 1f, 0f);
                        }
                    }

                    Windows.Creator.editor.GetType().GetField("currentZ", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Windows.Creator.editor, zOrder);*/
                }
            }
        }
    }
}

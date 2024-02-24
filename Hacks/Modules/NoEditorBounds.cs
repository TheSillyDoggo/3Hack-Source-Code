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
    public class NoEditorBounds : Module
    {
        public int zOrder = 0;
        public static NoEditorBounds instance;
        public NoEditorBounds()
        {
            name = "No Bounds";
            description = "Removes the editor camera bounds";

            instance = this;

            var harmony = new HarmonyLib.Harmony("com.Explodingbill.EditorBounds");

            var mOriginal = AccessTools.Method(typeof(FlatCamera), "ClampPosition");
            var mPostfix = SymbolExtensions.GetMethodInfo(() => ClampFix());

            harmony.Patch(mOriginal, new HarmonyMethod(mPostfix), null);
        }

        public static bool ClampFix()
        {
            return !instance.enabled;
        }

        public override void Update()
        {
            /*if (enabled && Windows.Creator.inEditor)
            {
                if (Windows.Creator.editor != null)
                {
                    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
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

                    Windows.Creator.editor.GetType().GetField("currentZ", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Windows.Creator.editor, zOrder);
                    Windows.Creator.editor.Invoke("RefreshObjects", 0);
                }
            }*/
        }
    }
}

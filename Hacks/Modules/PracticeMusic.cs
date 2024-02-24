using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace Modules
{
    [System.Serializable]
    class PracticeMusic : Module
    {
        public static Module instance;
        public PracticeMusic()
        {
            name = "Practice Music";
            description = "Plays the normal music in practice mode";

            var harmony = new HarmonyLib.Harmony("com.Explodingbill.Music");

            instance = this;
            var mOriginal = AccessTools.Method(typeof(PauseMenuManager), "StartPractice");
            var mPostfix = SymbolExtensions.GetMethodInfo(() => StartPractice());

            harmony.Patch(mOriginal, new HarmonyMethod(mPostfix), null);
        }

        public static bool StartPractice()
        {
            if (instance.enabled)
            {
                var pmm = GameObject.FindObjectOfType<PauseMenuManager>();
                PauseMenuManager.inPracticeMode = true;
                PauseMenuManager.DestroyAllCheckpoints();
                pmm.Resume(true);/*
                pmm.StopAllMusic();
                if (!GameObject.FindGameObjectWithTag("EternalMusic"))
                {
                    UnityEngine.Object.Instantiate<GameObject>(pmm.eternalMusicObject).GetComponent<EternalMusic>().PlayMusic();
                }*/

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
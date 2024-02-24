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
    class Noclip : Module
    {
        public static bool isNoclipEnabled;

        public Noclip()
        {
            name = "Noclip";
            description = "Stops you from dying";

            keybind = KeyCode.K;
            settings.Add(new BetterNoclip(this));
        }
        public override void Update()
        {
            isNoclipEnabled = enabled;
            if (GameObject.FindObjectOfType<PlayerScript>() != null)
            {
                GameObject.FindObjectOfType<PlayerScript>().noDeath = enabled;
                //FinishScript.onHit
            }
        }
    }
}

namespace Modules
{
    [System.Serializable]
    class BetterNoclip : ModuleSetting
    {
        public Module pA;

        public static bool isEnabled;
        public BetterNoclip(Module p)
        {
            name = "Better";
            description = "Disables Spike Hitboxes and allows you to finish";
            enabled = true;

            this.pA = p;
        }
        public override void Update()
        {
            boolValue = enabled;
            isEnabled = enabled;
        }
    }
}

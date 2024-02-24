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
    class InstantComplete : Module
    {
        public InstantComplete()
        {
            name = "Instant Complete";
            description = "Instantly completes the level";

        }

        public override void Update()
        {
            if (enabled)
            {
                if (GameObject.FindObjectOfType<PlayerScript>() != null)
                {
                    GameObject.FindObjectOfType<PlayerScript>().Win();
                }
            }
        }
    }
}
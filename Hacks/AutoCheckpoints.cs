using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class Autocheckpoints : Module
    {
        public Autocheckpoints()
        {
            name = "Autocheckpoints";
            description = "Automatically places checkpoints when you fall";

        }

        public override void Update()
        {
            try
            {
                if (GameObject.FindObjectOfType<PlayerScript>() != null)
                {
                    if (GameObject.FindObjectOfType<PlayerScript>().onGround)
                    {
                        if (PauseMenuManager.inPracticeMode)
                        {
                            GameObject.FindObjectOfType<PracticeButtonScript>().MakeCP();
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
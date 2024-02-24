using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Modules
{
    public class ShowAttemptCount : Module
    {
        public static Module module;
        public ShowAttemptCount()
        {
            name = "Show Attempt Text";
            description = "Add an attempt count where you spawn";

            module = this;
        }

        public static void CreateText()
        {
            if (StatusMGR.isInScene && module.enabled)
            {
                GameObject obj = new GameObject("sus Attempt count");
                obj.AddComponent<MeshRenderer>();

                TextMeshPro text = obj.AddComponent<TextMeshPro>();
                text.overflowMode = TextOverflowModes.Overflow;
                text.alignment = TextAlignmentOptions.Center;
                text.fontSize = 12;
                text.font = ModMain.fonts[0];
                text.enableCulling = true;

                text.text = "Attempt " + AttemptCounter.attempts;

                obj.transform.position = new Vector3(GameObject.FindObjectOfType<PlayerScript>().transform.position.x, 5, GameObject.FindObjectOfType<PlayerScript>().transform.position.z);
                obj.transform.rotation = GameObject.FindObjectOfType<Camera>().transform.rotation;
            }
        }
    }
}

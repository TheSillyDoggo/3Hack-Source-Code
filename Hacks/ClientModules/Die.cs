using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class Die : ModuleType.Button
    {
        public Die()
        {
            name = "Kill";
            description = "Kills The Player";
        }

        public override void OnClick()
        {
            if (GameObject.FindObjectOfType<PlayerScript>() != null)
            {
                GameObject.FindObjectOfType<PlayerScript>().Die(true);
            }
            canClick = true;
        }


    }
}

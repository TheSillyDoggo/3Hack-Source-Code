using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Modules
{
    public class FlipGravity : ModuleType.Button
    {
        public FlipGravity()
        {
            name = "Flip Gravity";
            description = "Flips The Players Gravity";
        }

        public override void OnClick()
        {
            if (GameObject.FindObjectOfType<PlayerScript>() != null)
            {
                GameObject.FindObjectOfType<PlayerScript>().grav *= -1;
                GameObject.FindObjectOfType<PlayerScript>().vsp *= 0.5f;
            }
            canClick = true;
        }


    }
}

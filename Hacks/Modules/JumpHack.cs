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
    class JumpHack : Module
    {
        public JumpHack()
        {
            name = "Jump Hack";
            description = "Allows you to jump in the air";
        }

        public override void Update()
        {
            if (enabled)
            {
                var player = GameObject.FindObjectOfType<PlayerScript>();
                if (player != null)
                {
                    player.onGround = true;
                    if (player.isCube)
                    {
                        if (player.jumpInput)
                        {
                            player.vsp = player.velocityForHeight(2.133f, 1f);
                        }
                    }
                }
            }
        }
    }
}
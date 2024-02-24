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
    class InfiniteDistance : Module
    {
        public InfiniteDistance()
        {
            name = "InfRenDis";
        }
        public override void Update()
        {
            if (GameObject.Find("WorldGenerator") != null)
            {
                GameObject.Find("WorldGenerator").GetComponent<WorldGenerator>().renderDistance = this.enabled ? Mathf.Infinity : 14f;
            }
        }
    }
}

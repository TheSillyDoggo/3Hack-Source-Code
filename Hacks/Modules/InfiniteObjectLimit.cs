using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Modules
{
    public class InfiniteObjectLimit : Module
    {
        public InfiniteObjectLimit()
        {
            name = "No Object Limit";
            description = "Removes the object limit (sets it to " + int.MaxValue + ")";
        }
        public override void Update()
        {
            if (enabled && Windows.Creator.inEditor)
            {
                if (Windows.Creator.editor != null)
                {
                    Windows.Creator.editor.objectLimit = int.MaxValue;
                }
            }
        }
    }
}

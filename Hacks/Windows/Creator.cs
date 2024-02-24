using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Windows
{
    public class Creator : Window
    {
        public static bool inEditor;
        public static FlatEditor editor;
        public Creator()
        {
            rect.position = new UnityEngine.Vector2(230 + 230 + 20 + 230 + 20, 20);
            name = "Creator";
            modules.Add(new Modules.InfiniteObjectLimit());
            modules.Add(new Modules.InfLevels());
            modules.Add(new Modules.NoEditorBounds());
            modules.Add(new Modules.SwapCamMode());
        }


        public override void OnUpdate()
        {
            inEditor = !(GameObject.FindObjectOfType<FlatEditor>() == null);
            if (inEditor)
            {
                editor = GameObject.FindObjectOfType<FlatEditor>();
            }
        }
    }
}
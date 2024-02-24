using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    //
    public class GUI : Window
    {
        public GUI()
        {
            rect.position = new UnityEngine.Vector2(230 + 50 + 20 + 50 + 20, 20);
            name = "GUI";
            render = true;

            modules.Add(new Modules.WorldModule());
            modules.Add(new Modules.PlayerModule());
            modules.Add(new Modules.SpeedhackModule());
            modules.Add(new Modules.StatusModule());
            modules.Add(new Modules.CreatorModule());
            modules.Add(new Modules.DisplayModule());
            modules.Add(new Modules.ReplayModule());
            modules.Add(new Modules.ClientModule());
            //modules.Add(new Modules.DebugModule());
            modules.Add(new Modules.OptionsModule());
            //modules.Add(new Modules.TestingModule());
            //modules.Add(new Modules.ScriptModule());

            //modules.Add(new ModuleType.Button());
            //modules.Add(new ModuleType.Button() { name = "Style" });

            //modules.Add(new ModuleType.Dropdown() { content = { "Instant", "Slide Top", "Slide Bottom", "Slide Left", "Slide Right" }  });
        }
    }
}

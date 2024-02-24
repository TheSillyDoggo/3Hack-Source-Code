using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    public class Client : Window
    {
        public Client()
        {
            rect.position = new UnityEngine.Vector2(230 + 230 + 20, 20);
            name = "Client";

            modules.Add(new Modules.Keybinds());
            modules.Add(new Modules.Discord());
            modules.Add(new Modules.ClickGUI());
            //modules.Add(new Modules.SceneSwitcher());
        }
    }
}

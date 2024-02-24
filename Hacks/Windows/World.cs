using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    public class World : Window
    {
        public World()
        {
            rect.position = new UnityEngine.Vector2(230 + 50 + 20, 20);
            name = "World";

            modules.Add(new Modules.InfiniteDistance());
            //modules.Add(new Modules.Freecam());
            modules.Add(new Modules.PracticeMusic());
            //modules.Add(new Modules.ShowHitbox());
        }
    }
}

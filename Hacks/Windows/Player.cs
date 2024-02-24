using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    public class Player : Window
    {
        public Player()
        {
            rect.position = new UnityEngine.Vector2(230 + 50 + 20 + 50 + 20 + 50 + 20, 20);
            name = "Player";

            modules.Add(new Modules.Noclip());
            modules.Add(new Modules.Die());
            modules.Add(new Modules.JumpHack());
            modules.Add(new Modules.InstantComplete());
            modules.Add(new Modules.FlipGravity());
            modules.Add(new Modules.ShowAttemptCount());
        }
    }
}

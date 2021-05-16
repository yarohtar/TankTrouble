using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tenkici
{
    class ControlSet
    {
        private Dictionary<string, Key> moving;
        private Dictionary<string, Keys> actions;

        public ControlSet(Dictionary<string, Key> moving, Dictionary<string, Keys> actions)
        {
            this.moving = moving;
            this.actions = actions;
        }

        public static ControlSet Arrows
        {
            get => new ControlSet(Key.Up, Key.Down, Key.Left, Key.Right, Keys.M);
        }

        public static ControlSet ESDF
        {
            get => new ControlSet(Key.E, Key.D, Key.S, Key.F, Keys.Q);
        }

        public ControlSet(Key up, Key down, Key left, Key right, Keys shoot)
        { 
            moving = new Dictionary<string, Key>();
            actions = new Dictionary<string, Keys>();

            moving["forward"] = up;
            moving["backward"] = down;
            moving["turnleft"] = left;
            moving["turnright"] = right;

            actions["shoot"] = shoot;
        }

        public Key Up
        {
            get => moving["forward"];
        }
        public Key Down
        {
            get => moving["backward"];
        }
        public Key Left { get => moving["turnleft"]; }
        public Key Right { get => moving["turnright"]; }
        public Keys Shoot { get => actions["shoot"]; }

        public (Key a, Keys b) this[string s]
        {
            get
            {
                if (s == "shoot")
                    return (Key.Enter, actions["shoot"]);
                else
                    return (moving[s], Keys.Enter);
            }
            set
            {
                if (s == "shoot")
                    actions["shoot"] = value.b;
                else
                    moving[s] = value.a;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    class Tenkic : GameObject
    {
        private Color color;
        private PointF position;
        private float rotation;
        private float velocity;
        private float angvelocity;

        public override void Update()
        {
            position.X += velocity * Math.Cos(rotation);
        }

    }
}

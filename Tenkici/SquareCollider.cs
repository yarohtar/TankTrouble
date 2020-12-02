using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    class SquareCollider : Collider
    {
        float rotation;
        PointF O;
        float a, b;
        public SquareCollider(PointF O, float rotation, float a, float b)
        {
            this.O = O;
            this.rotation = rotation;
            this.a = a;
            this.b = b;
        }

        public override void Update(PointF O, float rotation)
        {
            this.O = O;
            this.rotation = rotation;
        }

        public override PointF[] Collision(Collider c)
        {
            return new PointF[1];
        }
    }
}

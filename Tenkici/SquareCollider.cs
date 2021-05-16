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
        /*  
            
            a1            a2
        0-------------|---------1
        |                       |
     b1 |                       | b1
        |                       |
        -             O         -
        |                       |
        |                       |
     b2 |                       | b2
        |                       |
        3-------------|---------2
            a1            a2

         */

        private float a1;
        private float a2;
        private float b1;
        private float b2;

        public SquareCollider(PointF O, float rotation, float a1, float b1, float a2, float b2)
        {
            temena = new PointF[4];

            this.a1 = a1;
            this.a2 = a2;
            this.b1 = b1;
            this.b2 = b2;

            temena[0] = Rotate(-a1, -b1, rotation);
            temena[1] = Rotate(a2, -b1, rotation);
            temena[3] = Rotate(-a1, b2, rotation);
            temena[2] = Rotate(a2, b2, rotation);

            for(int i=0; i<4; i++)
            {
                temena[i].X += O.X;
                temena[i].Y += O.Y;
            }
        }

        private PointF Rotate(float x, float y, float angle)
        {
            return new PointF(x * (float)Math.Cos(angle) + y * (float)Math.Sin(angle), - x * (float)Math.Sin(angle) + y * (float)Math.Cos(angle));
        }

        public override void Update(PointF O, float rotation)
        {
            temena[0] = Rotate(-a1, -b1, rotation);
            temena[1] = Rotate(a2, -b1, rotation);
            temena[3] = Rotate(-a1, b2, rotation);
            temena[2] = Rotate(a2, b2, rotation);

            for (int i = 0; i < 4; i++)
            {
                temena[i].X += O.X;
                temena[i].Y += O.Y;
            }
        }
        public override PointF[] Collides(Duz A)
        {
            List<PointF> preseci = new List<PointF>();
            PointF[] K;
            for(int i=0; i<3; i++)
            {
                K = new Duz(temena[i], temena[i + 1]).Collides(A);
                if (K != null)
                    preseci.Add(K[0]);
            }

            K = new Duz(temena[3], temena[0]).Collides(A);
            if (K != null)
                preseci.Add(K[0]);

            return preseci.ToArray();
        }

    }
}

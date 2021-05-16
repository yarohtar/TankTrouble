using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    public class Duz : Collider
    {
        public Duz(PointF a, PointF b)
        {
            temena = new PointF[2];
            temena[0] = a;
            temena[1] = b;
        }

        private (float p, float q) LineParameters
        {
            get
            {
                float d = temena[0].X * temena[1].Y - temena[0].Y * temena[1].X;
                if(d==0)
                {
                    throw new NotImplementedException();
                }
                return ((temena[1].Y - temena[0].Y) / d, (temena[0].X - temena[1].X) / d);
            }
        }

        public override PointF[] Collides(Duz b)//vraca null ako se ne seku, takodje potreban mi je niz iako je max 1 tacka presek
        {
            /*PointF b1 = b.temena[0];
            PointF b2 = b.temena[1];*/
            float p1, p2, q1, q2;
            (p1, q1) = LineParameters;
            (p2, q2) = b.LineParameters;

            if(p1*q2==q1*p2)
            {
                return null;
            }

            float d = p1 * q2 - q1 * p2;

            float x, y;
            x = (q2 - q1) / d;
            y = (p1 - p2) / d;

            if(NaDuzi(x,y) && b.NaDuzi(x,y))
            {
                PointF[] presek = new PointF[1];
                presek[0] = new PointF(x, y);
                return presek;
            }

            return null;
        }

        public override PointF[] Collision(Collider A)
        {
            return A.Collides(this);
        }

        private bool NaDuzi(float x, float y)
        {
            return Between(x, temena[0].X, temena[1].X) && Between(y, temena[0].Y, temena[1].Y);
        }

        private bool Between(float x, float x1, float x2)
        {
            return (x <= x1 && x >= x2) || (x >= x1 && x <= x2);
        }
    }
}

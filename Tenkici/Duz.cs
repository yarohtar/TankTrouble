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

        public override PointF[] Collides(Duz b)//vraca null ako se ne seku, takodje potreban mi je niz iako je max 1 tacka presek
        {
            throw new NotImplementedException();
        }

        public override PointF[] Collision(Collider A)
        {
            return A.Collides(this);
        }
    }
}

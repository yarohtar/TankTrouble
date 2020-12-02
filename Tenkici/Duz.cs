using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    class Duz
    {
        PointF A, B;

        public Duz(PointF a, PointF b)
        {
            A = a;
            B = b;
        }

        public PointF Preseca(Duz b)//vraca null ako se ne seku
        {
            return new PointF();
        }
    }
}

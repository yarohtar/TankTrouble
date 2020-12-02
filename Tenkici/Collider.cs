using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    abstract class Collider
    {
        public abstract void Update(PointF O, float rotation);
        public abstract PointF[] Collision(Collider A);
    }
}

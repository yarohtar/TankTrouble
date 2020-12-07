using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    public abstract class Collider
    {
        public PointF[] temena;

        public abstract PointF[] Collides(Duz a);

        public virtual void Update(PointF O, float rotation)
        {
            return;
        }

        public virtual PointF[] Collision(Collider A)
        {
            List<PointF> preseci = new List<PointF>();
            PointF[] K;
            for (int i = 0; i < temena.Length - 1; i++)
            {
                K = A.Collides(new Duz(temena[i], temena[i + 1]));
                if (K != null)
                {
                    foreach (PointF k in K)
                    {
                        preseci.Add(k);
                    }
                }
                /*
                for (int j = 0; j < A.temena.Length - 1;) 
                {
                    K = new Duz(temena[i], temena[i + 1]).Preseca(new Duz(A.temena[j], A.temena[j + 1]));
                    if (K != null)
                        preseci.Add(K);
                }
                K=new Duz(temena[i], temena[i + 1]).Preseca(new Duz(A.temena[A.temena.Length-1], A.temena[0]));
                if (K != null)
                    preseci.Add(K);*/
            }
            K = A.Collides(new Duz(temena[temena.Length - 1], temena[0]));
            if (K != null)
            {
                foreach (PointF k in K)
                {
                    preseci.Add(k);
                }
            }
            /*
            for (int j = 0; j < A.temena.Length - 1;)
            {
                K = new Duz(temena[temena.Length-1], temena[0]).Preseca(new Duz(A.temena[j], A.temena[j + 1]));
                if (K != null)
                    preseci.Add(K);
            }
            K = new Duz(temena[temena.Length-1], temena[0]).Preseca(new Duz(A.temena[A.temena.Length - 1], A.temena[0]));
            if (K != null)
                preseci.Add(K);*/
            return preseci.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tenkici
{
    public abstract class GameObject
    {
        public abstract Collider GetCollider { get; }
        public abstract string GetName { get; }
        public abstract bool IsDisposed { get; }
        public abstract bool IsMoveable { get; }

        public abstract void Draw(Graphics g);
        public abstract void Destroy();

        public virtual void Update(float deltaT)
        {
            return;
        }
        public virtual void Command(Keys key)
        {
            return;
        }
    }
}

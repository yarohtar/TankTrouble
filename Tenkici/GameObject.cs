using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    abstract class GameObject
    {
        public abstract Collider GetCollider { get; }
        public abstract string GetName { get; }
        public abstract void Update(float deltaT);
        public abstract void Draw(Graphics g);
    }
}

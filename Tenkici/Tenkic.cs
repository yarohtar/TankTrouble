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
        private Collider collider;
        private string name;

        public Tenkic(Color color, PointF position, float rotation, string name)
        {
            this.color = color;
            this.position = position;
            this.rotation = rotation;
            this.name = name;
            velocity = 0;
            angvelocity = 0;
            //collider = new SquareCollider();
        }

        public override Collider GetCollider => collider;
        public override string GetName => name;

        public override void Update(float t)
        {
            position.X += t * velocity * (float)Math.Cos(rotation);
            position.Y += t * velocity * (float)Math.Sin(rotation);
            rotation += t * angvelocity;
            while (rotation >= 2 * Math.PI)
                rotation -= (float)Math.PI;
            while (rotation < 0)
                rotation += (float)Math.PI;
        }
        public override void Draw(Graphics g)
        {
        }
    }
}

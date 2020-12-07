using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Tenkici
{
    class Metak : GameObject
    {
        private const int R=4;
        private const float VELOCITY = 200;
        private const float BULLET_LIFETIME = 1000;

        private PointF position;
        private float rotation;
        private Stopwatch t;
        private Collider c;
        private bool dispose;

        public Metak(PointF position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;

            t = new Stopwatch();
            t.Start();

            dispose = false;
        }

        public override Collider GetCollider => c;
        public override string GetName => "bullet";
        public override bool IsDisposed => dispose;
        public override bool IsMoveable => true;

        public override void Update(float deltaT)
        {
            if(t.ElapsedMilliseconds>BULLET_LIFETIME)
            {
                dispose = true;
                return;
            }

            position.X += deltaT * VELOCITY * (float)Math.Cos(rotation);
            position.Y -= deltaT * VELOCITY * (float)Math.Sin(rotation);
            while (rotation >= 2 * Math.PI)
                rotation -= 2 * (float)Math.PI;
            while (rotation < 0)
                rotation += 2 * (float)Math.PI;
        }

        public override void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Gray);
            g.FillEllipse(b, position.X - R, position.Y - R, 2 * R, 2 * R);
        }
    }
}

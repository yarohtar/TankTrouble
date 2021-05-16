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
        private const float R=4;
        private const float VELOCITY = 200;
        private const long BULLET_LIFETIME = 1000;

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

            float d = R * (float)Math.Cos(Math.PI / 4);

            c = new SquareCollider(position, (float)Math.PI / 4, d, d, d, d);
        }

        public override Collider GetCollider => c;
        public override string GetName => "bullet";
        public override bool IsDisposed => dispose;
        public override bool IsMoveable => true;

        public override void Destroy()
        {
            dispose = true;
        }

        public override void Update(float deltaT)
        {
            if(t.ElapsedMilliseconds>BULLET_LIFETIME)
            {
                Destroy();
                return;
            }

            (var a, var b) = Scene.DetectCollision(this);
            if (a != null && b != null)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    var gO = a[i];
                    if (gO.GetType().Equals(typeof(Tenkic)))
                    {
                        gO.Destroy();
                        Destroy();
                        return;
                    }

                    if (gO.GetType().Equals(typeof(Walls)))
                    {
                        float x = 0;
                        float y = 0;
                        int n = b[i].Length;
                        for (int j = 0; j < n; j++)
                        {
                            x += b[i][j].X / n;
                            y += b[i][j].Y / n;
                        }
                        double hitAngle1 = Math.Atan2(x, -y);
                        int hitAngle = (int)Math.Round(8 * hitAngle1 / (2 * Math.PI)) % 8;
                        switch (hitAngle)
                        {
                            case 0:
                                if (Math.Cos(rotation) > 0)
                                    rotation = (float)Math.PI - rotation;
                                break;
                            case 1:
                                rotation = (float)Math.PI + rotation;
                                break;
                            case 2:
                                if (Math.Sin(rotation) > 0)
                                    rotation = -rotation;
                                break;
                            case 3:
                                rotation = (float)Math.PI + rotation;
                                break;
                            case 4:
                                if (Math.Cos(rotation) < 0)
                                    rotation = (float)Math.PI - rotation;
                                break;
                            case 5:
                                rotation = (float)Math.PI + rotation;
                                break;
                            case 6:
                                if (Math.Sin(rotation) < 0)
                                    rotation = -rotation;
                                break;
                            case 7:
                                rotation = (float)Math.PI + rotation;
                                break;
                            default:
                                break;
                        }

                        while (rotation >= 2 * Math.PI)
                            rotation -= 2 * (float)Math.PI;
                        while (rotation < 0)
                            rotation += 2 * (float)Math.PI;
                    }
                }
            }

            position.X += deltaT * VELOCITY * (float)Math.Cos(rotation);
            position.Y -= deltaT * VELOCITY * (float)Math.Sin(rotation);
            while (rotation >= 2 * Math.PI)
                rotation -= 2 * (float)Math.PI;
            while (rotation < 0)
                rotation += 2 * (float)Math.PI;
            c.Update(position, (float)Math.PI / 4);
        }

        public override void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Gray);
            g.FillEllipse(b, position.X - R, position.Y - R, 2 * R, 2 * R);
            c.Draw(g);
        }
    }
}

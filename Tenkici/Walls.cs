using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tenkici
{
    class Walls : GameObject
    {
        public const float WALL_LENGHT = 10;
        public const float WALL_THICKNESS = 2;

        private bool disposed;
        private Collider c;
        private List<Wall> walls;

        public Walls()
        {
            throw new NotImplementedException();
        }

        public override string GetName => "walls";
        public override Collider GetCollider => c;
        public override bool IsDisposed => disposed;
        public override bool IsMoveable => false;

        public override void Draw(Graphics g)
        {
            foreach (Wall w in walls)
                w.Draw(g);
        }

        public static Walls Generate(Random random)
        {
            throw new NotImplementedException();
        }

        private class Wall
        {
            private PointF position;
            private int rotation;
            private Color color;

            public Wall(PointF position, int rotation, Color color)
            {
                this.position = position;
                if (rotation == 0)
                    this.rotation = 0;
                else
                    this.rotation = 1;
                this.color = color;
            }

            internal void Draw(Graphics g)
            {
                Pen p = new Pen(color, WALL_THICKNESS);
                if (rotation == 0)
                {
                    g.DrawLine(p, new PointF(position.X - WALL_LENGHT / 2, position.Y), new PointF(position.X + WALL_LENGHT / 2, position.Y));
                }
                else if (rotation == 1)
                {
                    g.DrawLine(p, new PointF(position.X, position.Y - WALL_LENGHT / 2), new PointF(position.X, position.Y + WALL_LENGHT / 2));
                }
            }
        }
    }
}

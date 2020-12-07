using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace Tenkici
{
    class Tenkic : GameObject
    {
        private const int MAX_AMMO = 5;
        private const int FORWARD_VELOCITY = 100;
        private const int BACKWARD_VELOCITY = -50;
        private const int ANGULAR_VELOCITY = 3;
        private const float BULLET_OFFSET = 10;
        private const long BULLET_LIFETIME = 5000;
        private const long TIME_BETWEEN_SHOTS = 150;

        private Color color;
        private PointF position;
        private float rotation;
        private float velocity;
        private float angvelocity;
        private Collider collider;
        private string name;
        private Dictionary<string, Key> moving;
        private Dictionary<string, Keys> actions;
        private Stopwatch[] bullets;
        private Stopwatch lastShot;
        private bool dispose;

        public Tenkic(Color color, PointF position, float rotation, string name)
        {
            this.color = color;
            this.position = position;
            this.rotation = rotation;
            this.name = name;

            velocity = 0;
            angvelocity = 0;

            moving = new Dictionary<string, Key>();
            moving.Add("forward", Key.W);
            moving.Add("backward", Key.S);
            moving.Add("turnleft", Key.A);
            moving.Add("turnright", Key.D);

            actions = new Dictionary<string, Keys>();
            actions.Add("shoot", Keys.Space);

            bullets = new Stopwatch[MAX_AMMO];
            for (int i = 0; i < MAX_AMMO; i++)
                bullets[i] = new Stopwatch();
            lastShot = new Stopwatch();
            lastShot.Start();
            //collider = new SquareCollider();
        }

        public override Collider GetCollider => collider;
        public override string GetName => name;
        public override bool IsDisposed => dispose;
        public override bool IsMoveable => true;

        public override void Command(Keys key)
        {
            if (key == actions["shoot"])
            {
                Shoot();
            }
        }

        private void Move()
        {
            if (Keyboard.IsKeyDown(moving["forward"]) && Keyboard.IsKeyDown(moving["backward"]))
            {
                velocity = 0;
            }
            else if (Keyboard.IsKeyDown(moving["forward"]))
            {
                velocity = FORWARD_VELOCITY;
            }
            else if (Keyboard.IsKeyDown(moving["backward"]))
            {
                velocity = BACKWARD_VELOCITY;
            }
            else
            {
                velocity = 0;
            }

            if (Keyboard.IsKeyDown(moving["turnleft"]) && Keyboard.IsKeyDown(moving["turnright"]))
            {
                angvelocity = 0;
            }
            else if (Keyboard.IsKeyDown(moving["turnleft"]))
            {
                angvelocity = ANGULAR_VELOCITY;
            }
            else if (Keyboard.IsKeyDown(moving["turnright"]))
            {
                angvelocity = -ANGULAR_VELOCITY;
            }
            else
            {
                angvelocity = 0;
            }
        }

        private void Shoot()
        {
            if (lastShot.ElapsedMilliseconds > TIME_BETWEEN_SHOTS)
            {
                for (int i = 0; i < MAX_AMMO; i++)
                {
                    if (!bullets[i].IsRunning)
                    {
                        Scene.NewGameObject(new Metak(new PointF(position.X + (float)Math.Cos(rotation) * BULLET_OFFSET, 
                                                                position.Y - (float)Math.Sin(rotation) * BULLET_OFFSET), 
                                                                rotation));
                        bullets[i].Start();
                        lastShot.Restart();
                        break;
                    }
                }
            }
        }

        private void Refill()
        {
            for (int i = 0; i < MAX_AMMO; i++)
            {
                if (bullets[i].ElapsedMilliseconds > BULLET_LIFETIME)
                {
                    bullets[i].Reset();
                }
            }
        }

        public override void Update(float t)
        {
            Refill();
            Move();
            position.X += t * velocity * (float)Math.Cos(rotation);
            position.Y -= t * velocity * (float)Math.Sin(rotation);
            rotation += t * angvelocity;
            while (rotation >= 2 * Math.PI)
                rotation -= 2 * (float)Math.PI;
            while (rotation < 0)
                rotation += 2 * (float)Math.PI;
        }

        public override void Draw(Graphics g)
        {
            Pen b = new Pen(color, 2);
            g.DrawEllipse(b, position.X - 5, position.Y - 5, 10, 10);
            g.DrawLine(b, position, new PointF(position.X + 15 * (float)Math.Cos(rotation), position.Y - 15 * (float)Math.Sin(rotation)));
        }
    }
}

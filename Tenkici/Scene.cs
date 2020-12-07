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
    public static class Scene
    {
        private static List<GameObject> gameObjects;
        private static Stopwatch time;
        private static long t;


        public static void Init()
        {
            gameObjects = new List<GameObject>();

            time = new Stopwatch();
            time.Start();

            NewGameObject(new Tenkic(Color.Red, new PointF(50, 50), 0f, "player"));
        }
        public static void NewGameObject(GameObject a)
        {
            gameObjects.Add(a);
        }
        public static void Remove()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject a = gameObjects[i];
                if (a.IsDisposed)
                    gameObjects.Remove(a);
            }
        }
        public static void Commands(Keys k)
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].Command(k);
        }

        public static void Update()
        {
            long t1 = time.ElapsedMilliseconds;
            for (int i = 0; i < gameObjects.Count; i++)
                if (gameObjects[i].IsMoveable)
                    gameObjects[i].Update((t1 - t) / 1000f);
            t = t1;
        }
        public static void Paint(Graphics g)
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].Draw(g);
        }
    }
}

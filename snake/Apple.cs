using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake
{
    static class Apple
    {
        static public Texture2D apple;
        static public Random random = new Random();
        static public int X { get; set; }
        static public int Y { get; set; }
        static public int Center(string coordinate)
        {
            if (coordinate == "X") return (X + 15);
            else
                if (coordinate == "Y") return (Y + 15);
            else return (-100);
        }
        static public bool IsEaten { get; set; }
        static public void Spawn()
        {
            if (IsEaten)
            {
                IsEaten = false;
                int x = random.Next(100, 1180);
                int y = random.Next(100, 620);
                bool bad = true;
                int eps = 64;
                while(bad)
                {
                    bool flag =false;
                    for(int i=0;i<Snake.Length;i++)
                    {
                        if((Snake.bodies[i].X-x<eps)&&
                                (Snake.bodies[i].X-x>-eps)&&
                            (Snake.bodies[i].Y-y<eps)&&
                            (Snake.bodies[i].Y-y>-eps))
                        {
                            flag = true;
                        }
                        if(flag) { i = Snake.Length; }
                    }
                    if ((Head.X - x < eps) &&
                              (Head.X - x > -eps) &&
                          (Head.Y - y < eps) &&
                          (Head.Y - y > -eps))
                    {
                        flag = true;
                    }
                        if (flag)
                    {
                        x = random.Next(100, 1180);
                        y = random.Next(100, 620);
                    }
                    else
                    {
                        X = x;
                        Y = y;
                        bad = flag;
                    }
                    flag = false;
                }
            }
        }
        static public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector;
            vector.X = X;
            vector.Y = Y;
            spriteBatch.Draw(apple, vector, Color.White);
        }
    }
}

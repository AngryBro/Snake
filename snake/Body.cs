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
    class Body
    {
        public int X {get; set;}
        public int Y { get; set; }
        static public Texture2D body;
        public Direction Direction { get; set; }

        public void Move(int speed)
        {
            if(Snake.turns.Count!=0)
            {
                for(int i=0;i<Snake.Length;i++)
                {
                    for(int j=0;j<Snake.turns.Count;j++)
                    {
                        if((Snake.bodies[i].X==Snake.turns[j].X)&& (Snake.bodies[i].Y == Snake.turns[j].Y))
                        {
                            Snake.bodies[i].Direction = Snake.turns[j].Direction;
                            if(i==Snake.Length-1)
                            {
                                Snake.turns.RemoveAt(0);
                            }
                        }
                    }
                }
            }
            if (Direction == Direction.Up) Y -= speed;
            if (Direction == Direction.Down) Y += speed;
            if (Direction == Direction.Left) X -= speed;
            if (Direction == Direction.Right) X += speed;
            if (X > 1280) X = -64;
            if (X < -64) X = 1280;
            if (Y > 720) Y = -14;
            if (Y < -14) Y = 720;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector;
            vector.X = X;
            vector.Y = Y;
            spriteBatch.Draw(body, vector, Color.White);
        }
    }
}

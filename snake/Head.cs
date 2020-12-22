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
    static class Head
    {
        static public Texture2D head;
        static public Texture2D headd;
        static public Texture2D headu;
        static public Texture2D headl;
        static public int X {get; set;}
        static public int Y { get; set; }
        static public Direction Direction { get; set; }
        static public int Center(string coordinate)
        {
            if (coordinate == "X") return (X + 32);
            else
                if (coordinate == "Y") return (Y + 32);
            else return (-100);
        }
        static public void Move(int speed)
        {
            bool flag;
            if (Snake.turns.Count != 0)
            {
                flag = (Snake.turns[Snake.turns.Count - 1].X - X > 64) || (Snake.turns[Snake.turns.Count - 1].X - X < -64) ||
                    (Snake.turns[Snake.turns.Count - 1].Y - Y > 64) || (Snake.turns[Snake.turns.Count - 1].Y - Y < -64);
            }
            else flag = true;
                if (flag&&(Keyboard.GetState().IsKeyDown(Keys.Up)) && (Direction != Direction.Down)  && (Direction != Direction.Up))
            {
                Direction = Direction.Up;
                Snake.turns.Add(new Turn(X, Y, Direction));
            }
            if (flag && (Keyboard.GetState().IsKeyDown(Keys.Down)) && (Direction != Direction.Up) && (Direction != Direction.Down))
            {
                Direction = Direction.Down;
                Snake.turns.Add(new Turn(X, Y, Direction));
            }
            if (flag && (Keyboard.GetState().IsKeyDown(Keys.Left)) && (Direction != Direction.Right)  && (Direction != Direction.Left))
            {
                Direction = Direction.Left;
                Snake.turns.Add(new Turn(X, Y, Direction));
            }
            if (flag && (Keyboard.GetState().IsKeyDown(Keys.Right)) && (Direction != Direction.Left)  && (Direction != Direction.Right))
            {
                Direction = Direction.Right;
                Snake.turns.Add(new Turn(X, Y, Direction));
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
        static public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector;
            vector.X = X;
            vector.Y = Y;
            if(Direction==Direction.Right) spriteBatch.Draw(head, vector, Color.White);
            if(Direction==Direction.Left) spriteBatch.Draw(headl, vector, Color.White);
            if (Direction == Direction.Up) spriteBatch.Draw(headu, vector, Color.White);
            if (Direction == Direction.Down) spriteBatch.Draw(headd, vector, Color.White);
        }
    }
}

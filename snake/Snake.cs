using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace snake
{
    static class Snake
    {
        static public List<Body> bodies = new List<Body>();
        static public List<Turn> turns = new List<Turn>();
        static public int Length { get; set; }
        static public void Draw(SpriteBatch spriteBatch)
        {
            Head.Draw(spriteBatch);
            for(int i=0;i<Length;i++)
            {
                bodies[i].Draw(spriteBatch);
            }
        }
        static public void Move(int speed)
        {
            Head.Move(speed);
            for(int i=0;i<Length;i++)
            {
                bodies[i].Move(speed);
            }
        }
        static public void Add()
        {
            Length = Length + 1;
            Body body = new Body();
            Body bodypeek;
            bodypeek = bodies[Length-2];
            if (bodypeek.Direction==Direction.Up)
            {
               body.X = bodypeek.X;
                body.Y = bodypeek.Y+64;
                body.Direction = bodypeek.Direction;
            }
            if (bodypeek.Direction == Direction.Down)
            {
                body.X = bodypeek.X;
                body.Y = bodypeek.Y - 64;
                body.Direction = bodypeek.Direction;
            }
            if (bodypeek.Direction == Direction.Left)
            {
                body.X = bodypeek.X+64;
                body.Y = bodypeek.Y;
                body.Direction = bodypeek.Direction;
            }
            if (bodypeek.Direction == Direction.Right)
            {
                body.X = bodypeek.X-64;
                body.Y = bodypeek.Y;
                body.Direction = bodypeek.Direction;
            }
            bodies.Add(body);
        }
        static public void Eat()
        {
                    int Rh=32, Ra=15,Xh=Head.Center("X"),Yh=Head.Center("Y");
            int Xa = Apple.Center("X"), Ya = Apple.Center("Y");
            int distance = (Xa - Xh) * (Xa - Xh) + (Ya - Yh) * (Ya - Yh);
                    if(distance<(Rh+Ra)*(Rh+Ra))
            {
                Apple.IsEaten = true;
                Upmenu.Score++;
            }
        }
        static public void Loop()
        {
            if(Length<Upmenu.Score+2)
            {
                Add();
            }
        }
        static public bool Rip()
        {
            int Xh = Head.Center("X");
            int Yh = Head.Center("Y");
            for(int i=1;i<Length;i++)
            {
                int Xb = bodies[i].X+32;
                int Yb = bodies[i].Y + 32;
                int distance = (Xh - Xb) * (Xh - Xb) + (Yh - Yb) * (Yh - Yb);
                if (distance < 64 * 64)
                {
                    return (true);
                }
            }
            return (false);
        }
    }
}

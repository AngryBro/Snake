using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace snake
{
    static class Ripmenu
    {
        static public Texture2D rip;
        static public Texture2D ripnew;
        static public Texture2D ripexit;
        static public SpriteFont font;
        static public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector;
            vector.X = 655;
            vector.Y = 215;
            Snake.Draw(spriteBatch);
            Apple.Draw(spriteBatch);
            if ((Mouse.GetState().X > 431) && (Mouse.GetState().X < 785) && (Mouse.GetState().Y > 434) && (Mouse.GetState().Y < 486))
            {
                spriteBatch.Draw(ripnew, Vector2.Zero, Color.White);
            }
            else
            if ((Mouse.GetState().X > 431) && (Mouse.GetState().X < 637) && (Mouse.GetState().Y > 524) && (Mouse.GetState().Y < 568))
            {
                spriteBatch.Draw(ripexit, Vector2.Zero, Color.White);
            }
            else
            { spriteBatch.Draw(rip, Vector2.Zero, Color.White); }
            spriteBatch.DrawString(font, Upmenu.Score.ToString(), vector, Color.White);
        }
        static public string Buttons()
        {
            if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (Mouse.GetState().X > 431) && (Mouse.GetState().X < 785) && (Mouse.GetState().Y > 434) && (Mouse.GetState().Y < 486))
            {
                return ("new");
            }
            else if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (Mouse.GetState().X > 431) && (Mouse.GetState().X < 637) && (Mouse.GetState().Y > 524) && (Mouse.GetState().Y < 568))
                return ("exit");
            else return ("null");
        }
        

    }
}

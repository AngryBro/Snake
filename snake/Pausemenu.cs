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
    static class Pausemenu
    {
        static public Texture2D pausemenu;
        static public Texture2D pausecontinue;
        static public Texture2D pauseexit;
        static public Texture2D pausenew;
        static public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector;
            vector.X = 130;
            vector.Y = 5;
            Snake.Draw(spriteBatch);
            Apple.Draw(spriteBatch);
            spriteBatch.Draw(Upmenu.score, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Upmenu.font, Upmenu.Score.ToString(), vector, Color.White);
            if((Mouse.GetState().X >408) && (Mouse.GetState().X <872) && (Mouse.GetState().Y >377) && (Mouse.GetState().Y <433 ))
            {
                spriteBatch.Draw(pausecontinue, Vector2.Zero, Color.White);
            }
            else if ((Mouse.GetState().X >485) && (Mouse.GetState().X <791) && (Mouse.GetState().Y >488) && (Mouse.GetState().Y < 538))
            {
               spriteBatch.Draw(pausenew, Vector2.Zero, Color.White);
            }
            else if ((Mouse.GetState().X >515) && (Mouse.GetState().X <759) && (Mouse.GetState().Y >585) && (Mouse.GetState().Y < 637))
            {
                spriteBatch.Draw(pauseexit, Vector2.Zero, Color.White);
            }
            else
            {
                spriteBatch.Draw(pausemenu, Vector2.Zero, Color.White);
            }
        }

        static public string Buttons()
        {
            if (((Mouse.GetState().LeftButton == ButtonState.Pressed) && (Mouse.GetState().X > 408) && (Mouse.GetState().X < 872) && (Mouse.GetState().Y > 377) && (Mouse.GetState().Y < 433)))
            {
               return("continue") ;
            }

            if((Keyboard.GetState().IsKeyDown(Keys.Escape))&&(!IsEscPressed))
            {
                IsEscPressedGame = true;
                return ("continue");
            }
            else if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (Mouse.GetState().X > 485) && (Mouse.GetState().X < 791) && (Mouse.GetState().Y > 488) && (Mouse.GetState().Y < 538))
            {
               return("new") ;
            }
            else if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (Mouse.GetState().X > 515) && (Mouse.GetState().X < 759) && (Mouse.GetState().Y > 585) && (Mouse.GetState().Y < 637))
            {
                return("exit");
            }
            else
            {
                return("null");
            }
        }
        static public bool IsEscPressed { get; set; }
        static public bool IsEscPressedGame { get; set; }
    }
}

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
    static class Upmenu
    {
        static public SpriteFont font;
        static public Texture2D score;
        static public Texture2D pausepressed;
        static public int Score { get; set; }
        static public void Draw(SpriteBatch spriteBatch)
       {
            Vector2 vector;
            vector.X = 130;
            vector.Y = 5;
            spriteBatch.Draw(score, Vector2.Zero, Color.White);
            spriteBatch.DrawString(font, Score.ToString(), vector, Color.White);
            if((Mouse.GetState().X>1237)&& (Mouse.GetState().X <1274)&&(Mouse.GetState().Y > 6)&&(Mouse.GetState().Y <43))
            {
                spriteBatch.Draw(pausepressed, Vector2.Zero, Color.White);
            }
        }
        static public bool Paused()
        {
            if ((Mouse.GetState().LeftButton == ButtonState.Pressed) && (Mouse.GetState().X > 1237) && (Mouse.GetState().X < 1274) && (Mouse.GetState().Y > 6) && (Mouse.GetState().Y < 43))
            {
                return (true);
            }
            else return (false);
        }
    }
}

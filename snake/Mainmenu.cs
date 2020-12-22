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
    static class Mainmenu
    {
        static public Texture2D mainmenu;
        static public Texture2D play;
        static public Texture2D exit;
        static public void Draw(SpriteBatch spriteBatch)
        {
            if ((Mouse.GetState().X > 877) && (Mouse.GetState().X < 1101) && (Mouse.GetState().Y > 250) && (Mouse.GetState().Y < 301))
            {
                spriteBatch.Draw(mainmenu, Vector2.Zero, Color.White);
                spriteBatch.Draw(play, Vector2.Zero, Color.White);
            }
            else
            if ((Mouse.GetState().X > 877) && (Mouse.GetState().X < 1101) && (Mouse.GetState().Y > 425) && (Mouse.GetState().Y < 479))
            {
                spriteBatch.Draw(mainmenu, Vector2.Zero, Color.White);
                spriteBatch.Draw(exit, Vector2.Zero, Color.White);
            }
            else
            { spriteBatch.Draw(mainmenu, Vector2.Zero, Color.White); }
        }

    }
}

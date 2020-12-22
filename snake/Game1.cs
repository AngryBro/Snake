using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameTime gametime;
        Gamestate gamestate;
        int speed=2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Window.Title = "Snake";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            gamestate = Gamestate.Mainmenu;
            IsMouseVisible = true;
            Random random = new Random();
            Head.X = random.Next(300,600);
            Head.Y = random.Next(100,620);
            Head.Direction = Direction.Right;
            Snake.Length = 1;
            Snake.bodies.Add(new Body());
            Snake.bodies[0].X = Head.X-64;
            Snake.bodies[0].Y = Head.Y;
            Snake.bodies[0].Direction = Head.Direction;
            Apple.IsEaten = true;
            Snake.Add();
            Upmenu.Score = 0;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Mainmenu.mainmenu = Content.Load<Texture2D>("mainmenu");
            Mainmenu.play = Content.Load<Texture2D>("play");
            Mainmenu.exit = Content.Load<Texture2D>("exit");
            Head.head = Content.Load<Texture2D>("head");
            Head.headl = Content.Load<Texture2D>("headl");
            Head.headu = Content.Load<Texture2D>("headu");
            Head.headd = Content.Load<Texture2D>("headd");
            Body.body = Content.Load<Texture2D>("body");
            Apple.apple = Content.Load<Texture2D>("apple");
            Ripmenu.rip = Content.Load<Texture2D>("rip");
            Ripmenu.ripnew = Content.Load<Texture2D>("ripnew");
            Ripmenu.ripexit = Content.Load<Texture2D>("ripexit");
            Upmenu.font = Content.Load<SpriteFont>("font");
            Upmenu.score = Content.Load<Texture2D>("score");
            Ripmenu.font = Content.Load<SpriteFont>("fontrip");
            Upmenu.pausepressed = Content.Load<Texture2D>("pausepressed");
            Pausemenu.pausemenu = Content.Load<Texture2D>("pausemenu");
            Pausemenu.pausecontinue = Content.Load<Texture2D>("pausecontinue");
            Pausemenu.pausenew = Content.Load<Texture2D>("pausenew");
            Pausemenu.pauseexit = Content.Load<Texture2D>("pauseexit");
        }


        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {  
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || ((Keyboard.GetState().IsKeyDown(Keys.Escape))&&(gamestate==Gamestate.Mainmenu)))
                Exit();
            if ((gamestate == Gamestate.Mainmenu) && (Mouse.GetState().X > 877) && (Mouse.GetState().X < 1101) && (Mouse.GetState().Y > 425) && (Mouse.GetState().Y < 479) && (Mouse.GetState().LeftButton == ButtonState.Pressed))
                Exit();
            if ((Mouse.GetState().X > 877) && (Mouse.GetState().X < 1101) && (Mouse.GetState().Y > 250) && (Mouse.GetState().Y < 301) && (Mouse.GetState().LeftButton == ButtonState.Pressed))
                gamestate = Gamestate.Game;
                base.Update(gameTime);
            if (gamestate==Gamestate.Game)
            {
                Snake.Move(speed);
               Snake.Eat();
                Apple.Spawn();
                Snake.Loop();
                Snake.Rip();
                if(Upmenu.Paused())
                {
                    gamestate = Gamestate.Pausemenu;
                }
                if((Keyboard.GetState().IsKeyDown(Keys.Escape))&&(!Pausemenu.IsEscPressedGame))
                {
                    gamestate = Gamestate.Pausemenu;
                    Pausemenu.IsEscPressed = true;
                }
                if(Keyboard.GetState().IsKeyUp(Keys.Escape))
                {
                    Pausemenu.IsEscPressedGame = false;
                }
            }
            if((Snake.Rip())&&(gamestate==Gamestate.Game))
            {
                gamestate = Gamestate.Rip;
            }
            if(gamestate==Gamestate.Rip)
            {
                if(Ripmenu.Buttons()=="new")
                {
                    Random random = new Random();
                    gamestate = Gamestate.Game;
                    Snake.turns.Clear();
                    Snake.bodies.Clear();
                    Head.X = random.Next(300, 600);
                    Head.Y = random.Next(100, 620);
                    Head.Direction = Direction.Right;
                    Snake.Length = 1;
                    Snake.bodies.Add(new Body());
                    Snake.bodies[0].X = Head.X - 64;
                    Snake.bodies[0].Y = Head.Y;
                    Snake.bodies[0].Direction = Head.Direction;
                    Apple.IsEaten = true;
                    Snake.Add();
                    Upmenu.Score = 0;
                }
                if(Ripmenu.Buttons()=="exit")
                {
                    Exit();
                }
            }
            if(gamestate==Gamestate.Pausemenu)
            {
                if(Pausemenu.Buttons()=="continue")
                {
                    gamestate = Gamestate.Game;
                }
                if(Pausemenu.Buttons()=="new")
                {
                    Random random = new Random();
                    gamestate = Gamestate.Game;
                    Snake.turns.Clear();
                    Snake.bodies.Clear();
                    Head.X = random.Next(300, 600);
                    Head.Y = random.Next(100, 620);
                    Head.Direction = Direction.Right;
                    Snake.Length = 1;
                    Snake.bodies.Add(new Body());
                    Snake.bodies[0].X = Head.X - 64;
                    Snake.bodies[0].Y = Head.Y;
                    Snake.bodies[0].Direction = Head.Direction;
                    Apple.IsEaten = true;
                    Snake.Add();
                    Upmenu.Score = 0;
                }
                if(Pausemenu.Buttons()=="exit")
                {
                    Exit();
                }
                if(Keyboard.GetState().IsKeyUp(Keys.Escape))
                {
                    Pausemenu.IsEscPressed = false;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (gamestate == Gamestate.Mainmenu)
            {
                spriteBatch.Begin();
                Mainmenu.Draw(spriteBatch);
                spriteBatch.End();
            }
            if(gamestate == Gamestate.Game)
            {
                spriteBatch.Begin();
                Snake.Draw(spriteBatch);
                Apple.Draw(spriteBatch);
               Upmenu.Draw(spriteBatch);
                spriteBatch.End();
            }

            if(gamestate==Gamestate.Rip)
            {
                spriteBatch.Begin();
                Ripmenu.Draw(spriteBatch);
                spriteBatch.End();
            }
            if(gamestate==Gamestate.Pausemenu)
            {
                spriteBatch.Begin();
                Pausemenu.Draw(spriteBatch);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}

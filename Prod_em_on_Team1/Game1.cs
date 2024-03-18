using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Prod_em_on_Team1.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private gamename gamename;
        private bentendo bentendo;
        private play play;
        private loading loading;
        private Rectangle mousebox, playbox;
        private MouseState myMouse;
        private bool buttonpressed, buttonreleased, startplay = false, startedplay = false, playnow = false;
        private timer timer;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.PreferredBackBufferHeight = 750;
            _graphics.PreferredBackBufferWidth = 1200;
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gamename = new gamename(null, new Vector2(_graphics.PreferredBackBufferWidth / 2 -500, _graphics.PreferredBackBufferHeight - 700), new Rectangle(), Color.White);
            bentendo = new bentendo(null, new Vector2(_graphics.PreferredBackBufferWidth / 2 - 500, _graphics.PreferredBackBufferHeight - 100), new Rectangle(), Color.White);
            play = new play(null, new Vector2(375, 425), new Rectangle(375, 425, 450, 182), Color.White);
            loading = new loading(null, new Vector2(0, 0), new Rectangle(0, 0, 1200, 750), Color.White);
            timer = new timer();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gamename.LoadContent(Content);
            bentendo.LoadContent(Content);
            play.LoadContent(Content);
            loading.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            this.IsMouseVisible = true;
            
            myMouse =  Mouse.GetState();
            
            mousebox = new Rectangle(myMouse.X, myMouse.Y, 1, 1);
            playbox = new Rectangle(375, 425, 450, 182);
            
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            _spriteBatch.Begin();

            gamename.Draw(_spriteBatch);
            bentendo.Draw(_spriteBatch);
            play.Draw(_spriteBatch);
            _spriteBatch.End();
            if (myMouse.LeftButton == ButtonState.Pressed && mousebox.Intersects(playbox))
            {
                buttonpressed = true;
            }
            if(myMouse.LeftButton == ButtonState.Released) 
            {
                buttonreleased = true;
            }

            // TODO: Add your drawing code here
            if (buttonpressed == true)
                if(buttonreleased == true)
                {
                    GraphicsDevice.Clear(Color.DarkBlue);
                        _spriteBatch.Begin();
                        loading.Draw(_spriteBatch);
                        _spriteBatch.End();
                    startplay = true;
                }
            if(startplay == true)
            {
                timer.StartTimer(gameTime);
                timer.Active = true;
                timer.Update(gameTime);
                startedplay = true;
            }
            if(startedplay == true)
            {
                timer.GetTime();
                timer.Update(gameTime);
                playnow = true;
            }
            if (playnow = true && timer.TimePassed == 3)
            {
                GraphicsDevice.Clear(Color.DarkBlue);
                _spriteBatch.Begin();

                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
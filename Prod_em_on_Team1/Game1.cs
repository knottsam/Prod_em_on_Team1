using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prod_em_on_Team1
{
    public class Game1 : Game
    {
        public static bool gameStarted, raceStarted;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Timer _timer;
        private Player _player;
        private Camera _camera;
        public static int ScreenHeight, ScreenWidth, MaxSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 750;
            _graphics.PreferredBackBufferWidth = 1200;
        }
        protected override void Initialize() 
        {
            // TODO: Add your initialization logic here
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
           
            MaxSpeed = 10;

            
            _timer = new Timer();
            _camera = new Camera();
            _player = new Player(new Vector2(468, 468), new Rectangle(468, 468, 32, 32), 0, new Vector2(0, 0));
            UI_Manager.CreateUI(Content, _player);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player.LoadContent(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UI_Manager.Update(gameTime);

            if(gameStarted)
            {
                _camera.Follow(_player);
                _timer.Update(gameTime);
                _player.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            if (gameStarted)
            {
                _spriteBatch.Begin(transformMatrix: _camera.Transform);
                UI_Manager.Draw(gameTime, _spriteBatch);
                _player.Draw(gameTime, _spriteBatch);
            }
            else
            {
                _spriteBatch.Begin();
                UI_Manager.Draw(gameTime, _spriteBatch);
            }


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
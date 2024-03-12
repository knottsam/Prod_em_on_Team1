using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prod_em_on_Team1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Timer _timer;
        private Player _player;
        private Camera _camera;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static int MaxSpeed;


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

            UI_Manager.CreateUI(Content);
            _timer = new Timer();
            _camera = new Camera();
            _player = new Player(new Vector2(468, 200), new Rectangle(468, 200, 32, 32), 0, new Vector2(0, 0));
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
            _camera.Follow(_player);
            _timer.Update(gameTime);
            _player.Update(gameTime);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            if(UI_Manager.gameStarted)
            {
                _spriteBatch.Begin(transformMatrix: _camera.Transform);
            }
            else
            {
                _spriteBatch.Begin();
            }

            UI_Manager.Draw(gameTime, _spriteBatch);
            _player.Draw(gameTime, _spriteBatch);


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
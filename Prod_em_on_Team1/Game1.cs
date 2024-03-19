using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Data;
using System.Threading;

namespace Prod_em_on_Team1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TrackMap map1;
        private Timer _timer;
        private TempBoard tempBoard;
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
            map1 = new TrackMap(Content);
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
           
            MaxSpeed = 10;


            map1 = new TrackMap(Content);
            _timer = new Timer();
            _camera = new Camera();
            tempBoard = new TempBoard(Content);
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

            _camera.Follow(_player);
            _timer.Update(gameTime);
            _player.Update();
          
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: _camera.Transform);
            //_spriteBatch.Begin();

            _player.Draw(gameTime, _spriteBatch);
            map1.Draw(_spriteBatch);
            tempBoard.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
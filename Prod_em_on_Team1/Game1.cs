using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;


namespace Prod_em_on_Team1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;
        private Timer _timer;
        private double _time;
        private double _recordTime = 10;
        public static int ScreenHeight;
        public static int ScreenWidth;
        private GameStats gStats;
        private const string PATH = "gamestats.json";
        private SpriteFont basicFont;

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
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            _timer = new Timer();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            gStats = new GameStats()
            {
                RecordTime = _recordTime,
                TestStatistic = "test",
            };
            Save(gStats);

            gStats = Load();
            Trace.WriteLine($"{gStats.TestStatistic} {gStats.RecordTime}");

            basicFont = Content.Load<SpriteFont>("basicFont");

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = _spriteBatch;
            Globals.Content = Content;

            _gameManager = new();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _timer.Update(gameTime);
            gStats.Update(gameTime);


            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _time = gameTime.TotalGameTime.TotalSeconds;

                if (_time < _recordTime)
                {
                    _recordTime = _time;
                }

                Save(gStats);
            }

            gStats = new GameStats()
            {
                RecordTime = _recordTime,
                TestStatistic = "test",
            };
            Save(gStats);

            Globals.Update(gameTime);
            _gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();

            _gameManager.Draw();
            _spriteBatch.DrawString(basicFont, _time.ToString(), new Vector2(100, 500), Color.White);
            _spriteBatch.DrawString(basicFont, _recordTime.ToString(), new Vector2(100, 550), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void Save(GameStats stats)
        {
            string serialisedText = JsonSerializer.Serialize<GameStats>(stats);
            Trace.WriteLine(serialisedText);
            File.WriteAllText(PATH, serialisedText);
        }

        private GameStats Load()
        {
            var fileContents = File.ReadAllText(PATH);
            return JsonSerializer.Deserialize<GameStats>(fileContents);
        }
    }
}
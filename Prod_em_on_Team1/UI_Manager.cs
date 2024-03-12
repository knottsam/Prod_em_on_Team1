using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Prod_em_on_Team1
{
    internal static class UI_Manager
    {
        private static List<User_Interface> _listOfUserInterfaces;
        private static User_Interface _gamename, _bentendo, _playButton, _loading;
        private static Rectangle _mousebox, _playbox;
        private static MouseState _myMouse;
        private static bool buttonpressed, buttonreleased;
        private static Timer _timer;
        private static TrackMap map1;

        public static void CreateUI(ContentManager myContent)
        {
            _listOfUserInterfaces = new List<User_Interface>();

            _gamename = new User_Interface(myContent, true, "Capture", new Vector2(Game1.ScreenWidth / 2 - 500, Game1.ScreenHeight - 700));
            _bentendo = new User_Interface(myContent, true, "nintendo", new Vector2(Game1.ScreenWidth / 2 - 500, Game1.ScreenHeight - 100));
            _playButton = new User_Interface(myContent, true, "play_button", new Vector2(375, 425));
            _loading = new User_Interface(myContent, false, "loading1", new Vector2(0, 0));
            map1 = new TrackMap(myContent);

            _listOfUserInterfaces.Add(_gamename);
            _listOfUserInterfaces.Add(_bentendo);
            _listOfUserInterfaces.Add(_playButton);
            _listOfUserInterfaces.Add(_loading);

            _mousebox = new Rectangle(_myMouse.X, _myMouse.Y, 1, 1);
            _playbox = new Rectangle(375, 425, 450, 182);
            _timer = new Timer();
        }

        public static void Update(GameTime gameTime)
        {
            _myMouse = Mouse.GetState();
            _timer.Update(gameTime);
            _mousebox.X = _myMouse.X;
            _mousebox.Y = _myMouse.Y;

            if (_myMouse.LeftButton == ButtonState.Pressed && _mousebox.Intersects(_playbox))
            {
                buttonpressed = true;
                _gamename.IsDrawn = false;
                _bentendo.IsDrawn = false;
                _playButton.IsDrawn = false;
                _loading.IsDrawn = true;

                _timer.StartTimer(gameTime);
            }
            if(_timer.TimePassed > 3)
            {
                Game1.gameStarted = true;
                _timer.Active = false;
            }
        }
        public static void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            
            
            if(Game1.gameStarted)
            {
                map1.Draw(spriteBatch);
            }
            else
            {
                foreach (User_Interface UI in _listOfUserInterfaces)
                {
                    if (UI.IsDrawn)
                    {
                        UI.Draw(gametime, spriteBatch);
                    }
                }
            }
        }
    }
}

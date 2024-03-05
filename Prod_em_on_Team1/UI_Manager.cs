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
        private static Rectangle mousebox, playbox;
        private static MouseState myMouse;
        private static bool buttonpressed, buttonreleased;
        private static Timer timer;

        public static void CreateUI(ContentManager myContent)
        {
            _gamename = new User_Interface(myContent, false, "Capture", new Vector2(Game1.ScreenWidth / 2 - 500, Game1.ScreenHeight - 700));
            _bentendo = new User_Interface(myContent, false, "nintendo", new Vector2(Game1.ScreenWidth / 2 - 500, Game1.ScreenHeight - 100));
            _playButton = new User_Interface(myContent, false, "play_button", new Vector2(375, 425));
            _loading = new User_Interface(myContent, false, "loading1", new Vector2(0, 0));

            _listOfUserInterfaces.Add(_gamename);
            _listOfUserInterfaces.Add(_bentendo);
            _listOfUserInterfaces.Add(_playButton);
            _listOfUserInterfaces.Add(_loading);

            mousebox = new Rectangle(myMouse.X, myMouse.Y, 1, 1);
            playbox = new Rectangle(375, 425, 450, 182);
            timer = new Timer();
        }

        public static void Update()
        {
            if (myMouse.LeftButton == ButtonState.Pressed && mousebox.Intersects(playbox))
            {
                buttonpressed = true;
            }
        }
        public static void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            foreach(User_Interface UI in _listOfUserInterfaces)
            {
                if(UI.IsDrawn)
                {
                    UI.Draw(gametime, spriteBatch);
                }
            }
        }
    }
}

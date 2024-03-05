using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Prod_em_on_Team1
{
    internal class User_Interface : Sprite
    {
        private bool _isDrawn;
        public User_Interface(ContentManager myContent, bool isDrawn, string nameOfTexture, Vector2 inPosition)
        {
            _isDrawn = isDrawn;
            LoadContent(myContent, nameOfTexture);
        }
        private void LoadContent(ContentManager myContent, string nameOfTexture)
        {
            myContent.RootDirectory = "content";
            _texture = myContent.Load<Texture2D>(nameOfTexture);//ADD YARA'S FILES
        }

        public bool IsDrawn
        {
            get { return _isDrawn; }
            set { _isDrawn = value; }
        }
    }
}

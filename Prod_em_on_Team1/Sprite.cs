using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prod_em_on_Team1
{
    internal class Sprite
    {
        protected Texture2D _texture;
        public Sprite()
        { }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update()
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public Vector2 Position
        {
            get; set;
        }

        public Rectangle Rectangle
        {
            get; set;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
        public int Lane
        {
            get; set;
        }
    }
}

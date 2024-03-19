using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Prod_em_on_Team1
{
    internal class Gate
    {
        private Texture2D _texture, _textureClosed;
        private Vector2 _position;
        public Gate(Vector2 inPosition, ContentManager Content)
        {
            _position = inPosition;
            _texture = Content.Load<Texture2D>("open start gate");
            _textureClosed = Content.Load<Texture2D>("closed start gate");
        }
        public void Open()
        {
            _texture = _textureClosed;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}

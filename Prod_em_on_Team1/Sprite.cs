using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Prod_em_on_Team1
{
    internal class Sprite
    {
        private Texture2D _texture;
        private Vector2 _position;
        private Rectangle _box;
        private int _lane = 0;
        private int _speed = 0;
        
        
        public Sprite()
        { }
        
        public Sprite(Vector2 inPosition, Rectangle inBox, int inLane, int inSpeed)
        {
            _position = inPosition;
            _box = inBox;
            _lane = inLane;
            _speed = inSpeed;
        }

        public virtual void LoadContent(ContentManager myContent)
        {

        }
        public virtual void Update()
        {
            _position.X += _speed;
            _box.X = (int)_position.X;
            _box.Y = (int)_position.Y;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Rectangle Box
        {
            get { return _box; }
            set { _box = value; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }
        public int Lane
        {
            get { return _lane;}
            set { _lane = value; }
        }

        public int Speed
        {
            get { return _speed;}
            set { _speed = value; }
        }
    }
}

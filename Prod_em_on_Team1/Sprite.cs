using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Prod_em_on_Team1
{
    public class Sprite
    {
        protected Texture2D _texture;
        protected Vector2 _position;
        protected Rectangle _box;
        protected int _lane = 0;
        protected Vector2 _speed = new Vector2(0, 0);
        protected float _angleOfRotation = 0;
        protected int _scale = 1;
        

        public Sprite()
        { }

        public Sprite(Vector2 inPosition, Rectangle inBox, int inLane, Vector2 inSpeed)
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
            _position += _speed;
            _box.X = (int)_position.X;
            _box.Y = (int)_position.Y;
            _box.Width = (int)this.Texture.Width;
            _box.Height = (int)this.Texture.Height;
            _position.Y = 468 + (32 * _lane);

        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_texture, _position, Color.White);
            spriteBatch.Draw(_texture, _position, new Rectangle(), Color.White, _angleOfRotation, Origin, _scale, SpriteEffects.None, 0);
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Origin
        {
            get; set;
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
            get { return _lane; }
            set { _lane = value; }
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
    }
}

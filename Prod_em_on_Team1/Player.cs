using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prod_em_on_Team1
{
    public class Player : Sprite
    {
        private Texture2D _textureForward;
        private Texture2D _textureTurningRight;
        private Texture2D _textureTurningLeft;
        private Texture2D _textureVibrate;
        private int _temperature;
        private int _groundPosition;
        private bool WReleased = true, SReleased = true, isTouchingPothole = false;



        public Player() : base()
        { }

        public Player(Vector2 inPosition, Rectangle inBox, int inLane, Vector2 inSpeed)
            : base(inPosition, inBox, inLane, inSpeed)
        {
            _position = inPosition;
            _box = inBox;
            _lane = inLane;
            _speed = inSpeed;
        }

        public override void LoadContent(ContentManager myContent)
        {
            myContent.RootDirectory = "Content";
            // add textures
            _textureForward = myContent.Load<Texture2D>("bike");
            //_textureTurningRight = myContent.Load<Texture2D>("");//ADD TEXTURES
            //_textureTurningLeft = myContent.Load<Texture2D>("");//ADD TEXTURES
            //_textureVibrate = myContent.Load<Texture2D>("");//ADD TEXTURES

            Origin = new Vector2(_textureForward.Width / 2, _textureForward.Height / 2);
        }

        public override void Update()
        {
            _texture = _textureForward;
            _groundPosition = 468 + (32 * _lane);
            _box.X = (int)_position.X;
            _box.Y = (int)_position.Y;
            _box.Width = (int)this.Texture.Width;
            _box.Height = (int)this.Texture.Height;

            Physics();
            Controls();
            
        }

        public void Collision()
        {
            _speed.X = 0;
        }

        private void Physics()
        {
            _speed.Y += 0.2f;//gravity
            if (_position.Y + _speed.Y > _groundPosition)
            {
                _position.Y = _groundPosition;
            }
            else
            {
                _position.Y += _speed.Y;
            }

            if (_speed.X > 0 && _position.Y == _groundPosition)//friction
            {
                _speed.X -= 0.08f; // slowing down
            }
            else if (_speed.X < 0)
            {
                _speed.X = 0;
            }
            _position.X += _speed.X;
        }
        private void Controls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Lane > 0 && WReleased)
            {
                WReleased = false;
                Lane--;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                WReleased = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Lane < 5 && SReleased)
            {
                SReleased = false;
                Lane++;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.S))
            {
                SReleased = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _speed.X < Game1.MaxSpeed && _position.Y == _groundPosition) //acceleration: the bike is back wheel drive so reverse wheelies stop acceleration
            {
                if (_angleOfRotation < 0)//wheelies are cool and therefore fast
                {
                    _speed.X += 0.3f;
                }
                else if (_angleOfRotation == 0)
                {
                    _speed.X += 0.15f;
                }

                //increase temperature
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _angleOfRotation = -1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _angleOfRotation = 1;
            }
            else
            {
                _angleOfRotation = 0;
            }
        }

        public int Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prod_em_on_Team1
{
    internal class Player : Sprite
    {
        private Texture2D _textureForward;
        private Texture2D _textureTurningRight;
        private Texture2D _textureTurningLeft;
        private Texture2D _textureVibrate;
        private float _temperature;
        private int _groundPosition;
        private bool _wReleased = true, _sReleased = true, _engineFailed;
        


        public Player() : base() // fix temperature not increasing
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
            _textureForward = myContent.Load<Texture2D>("BikeForward");
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


            Physics();
            Controls();
            TemperatureChecks();
        }

        private void Physics()
        {
            if(_position.Y < _groundPosition)//gravity
            {
                _speed.Y += 0.2f;
            }
            else
            {
                _speed.Y = 0;
            }
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
                _speed.X -= 0.02f;
            }
            else if (_speed.X < 0)
            {
                _speed.X = 0;
            }
            _position.X += _speed.X;



            
        }

        private void TemperatureChecks()
        {
            if (_temperature > 0)//checking temperature. If it reaches 100, acceleration stops until temp goes back to 0
            {
                _temperature -= 1.03f;
            }
            if (_temperature < 0)
            {
                _temperature = 0;
            }

            if (_temperature >= 100)
            {
                _engineFailed = true;
            }
            else if (_temperature <= 0)
            {
                _engineFailed = false;
            }
        }
        private void Controls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Lane > 0 && _wReleased)
            {
                _wReleased = false;
                Lane--;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                _wReleased = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && Lane < 5 && _sReleased)
            {
                _sReleased = false;
                Lane++;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.S))
            {
                _sReleased = true;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _position.Y == _groundPosition && !_engineFailed) //acceleration: the bike is back wheel drive so reverse wheelies stop acceleration
            {
                //increase temperature
                _temperature += 1.2f;

                if(_speed.X < Game1.MaxSpeed)
                {
                    if (_angleOfRotation < 0)//wheelies are cool and therefore fast
                    {
                        _speed.X += 0.3f;
                    }
                    else if (_angleOfRotation == 0)
                    {
                        _speed.X += 0.1f;
                    }
                }
                

                
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

        public float Temperature 
        {
            get {  return _temperature; }
            set { _temperature = value; }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prod_em_on_Team1
{
    internal class Player : Sprite
    {
        private GameTime _gameTime;
        private Texture2D _textureForward;
        private Texture2D _textureTurningRight;
        private Texture2D _textureTurningLeft;
        private Texture2D _textureVibrate;
        private Shadow _playerShadow;
        private float _temperature;
        private int _groundPosition, _laneTransition, _maximumRotation = 1;
        private bool _wReleased = true, _sReleased = true, _engineFailed;
        private long _updateCounter = 0;
        


        public Player() : base() // fix temperature not increasing
        {}

        public Player(Vector2 inPosition, Rectangle inBox, int inLane, Vector2 inSpeed)
            : base(inPosition, inBox, inLane, inSpeed)
        {
            _position = inPosition;
            _box = inBox;
            _lane = inLane;
            _speed = inSpeed;
            _playerShadow = new Shadow(this);
            
        }

        public override void LoadContent(ContentManager myContent)
        {
            myContent.RootDirectory = "Content";

            _textureForward = myContent.Load<Texture2D>("BikeForward");
            _textureTurningRight = myContent.Load<Texture2D>("bikeTurnRight");//ADD TEXTURES
            _textureTurningLeft = myContent.Load<Texture2D>("bikeTurnLeft");//ADD TEXTURES
            //_textureVibrate = myContent.Load<Texture2D>("");//ADD TEXTURES

            _playerShadow.LoadContent(myContent);

            Origin = new Vector2(_textureForward.Width / 2, _textureForward.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            _gameTime = gameTime;
            _texture = _textureForward;

            _groundPosition = 468 + (32 * _lane);
            _box.X = (int)_position.X;
            _box.Y = (int)_position.Y;


            Physics();
            ChangingLane();
            Controls();
            TemperatureChecks();
            //Vibration();
            _playerShadow.Update(gameTime);
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, _angleOfRotation, Origin, _scale, SpriteEffects.None, 0);
            _playerShadow.Draw(gameTime, spriteBatch);
        }

        private void Vibration()
        {
            _updateCounter++;
            if(_laneTransition == 0 && _position.Y == _groundPosition)
            {
                if(_updateCounter % 30 == 0 && _texture == _textureForward)
                {
                    _texture = _textureVibrate;
                }
                else if(_updateCounter % 30 == 0 && _texture == _textureVibrate)
                {
                    _texture = _textureForward;
                }
            }
            else if(_laneTransition == 0)
            {
                _texture = _textureForward;
            }
        }

        private void Physics()
        {
            if(_position.Y < _groundPosition && _laneTransition == 0)//gravity
            {
                _speed.Y += 0.2f;
            }


            if (_position.Y + _speed.Y > _groundPosition && _laneTransition == 0)
            {
                _position.Y = _groundPosition;
            }
            else
            {
                _position.Y += _speed.Y;
            }


            if (_speed.X > 0)//friction / air resistance
            {
                _speed.X -= 0.02f;
            }
            else if (_speed.X < 0)
            {
                _speed.X = 0;
            }
            _position.X += _speed.X;


           
        }

        private void ChangingLane()
        {
            if (_position.Y == _groundPosition)
            {
                _laneTransition = 0;
                _speed.Y = 0;
            }


            if (_laneTransition == 1)
            {
                //change texture
                if (_position.Y < _groundPosition)
                {
                    _speed.Y = 2;
                    _texture = _textureTurningRight;
                }
                else if (_position.Y > _groundPosition)
                {
                    _position.Y = _groundPosition;
                }
            }

            else if (_laneTransition == -1)
            {
                //change texture
                if (_position.Y > _groundPosition)
                {
                    _texture = _textureTurningLeft;
                    _speed.Y = -2;
                }
                else if (_position.Y < _groundPosition)
                {
                    _position.Y = _groundPosition;
                }
            }
        }
        private void TemperatureChecks()
        {
            if (_temperature > 0)//checking temperature. If it reaches 100, acceleration stops until temp goes back to 0
            {
                _temperature -= 0.2f;
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
            if(!_engineFailed)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && Lane > 0 && _wReleased)//changing lanes
                {
                    _wReleased = false;
                    Lane--;
                    _laneTransition = -1;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.W))
                {
                    _wReleased = true;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S) && Lane < 5 && _sReleased)
                {
                    _sReleased = false;
                    Lane++;
                    _laneTransition = 1;
                }

                if (Keyboard.GetState().IsKeyUp(Keys.S))
                {
                    _sReleased = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && (_position.Y == _groundPosition || _laneTransition != 0)) //acceleration: the bike is back wheel drive so reverse wheelies stop acceleration
                {
                    _temperature += 0.37f;

                    if (_speed.X < Game1.MaxSpeed)
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

                if (Keyboard.GetState().IsKeyDown(Keys.A) && _angleOfRotation > -_maximumRotation)//rotating / wheelies
                {
                    _angleOfRotation -= 0.1f;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D) && _angleOfRotation < _maximumRotation)
                {
                    _angleOfRotation += 0.1f;
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.D) && Keyboard.GetState().IsKeyUp(Keys.A))
                {
                    if(_angleOfRotation < 0)
                    {
                        _angleOfRotation += 0.1f;
                    }
                    else if(_angleOfRotation > 0)
                    {
                        _angleOfRotation -= 0.1f;
                    }
                    if ((_angleOfRotation < 0.1 && _angleOfRotation > 0) || (_angleOfRotation > -0.1 && _angleOfRotation < 0))
                    {
                        _angleOfRotation = 0;
                    }

                }
            }
            

            
        }

        public float Temperature 
        {
            get {  return _temperature; }
            set { _temperature = value; }
        }
        public int GroundPosition
        {
            get { return _groundPosition; }
            set { _groundPosition = value; }
        }
        public int LaneTransition
        {
            get { return _laneTransition; }
            set { _laneTransition = value; }
        }
        public Shadow Shadow
        {
            get { return _playerShadow; }
        }
    }
}

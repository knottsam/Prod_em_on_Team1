using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Prod_em_on_Team1
{
    internal class Player : Sprite
    {
        private Texture2D _textureForward;
        private Texture2D _textureTurningRight;
        private Texture2D _textureTurningLeft;
        private Texture2D _textureVibrate;
        private int _temperature;
        private bool WReleased = true, SReleased = true;
        


        public Player() : base()
        { }

        public Player(Vector2 inPosition, Rectangle inBox, int inLane, int inSpeed)
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

            _position.X += _speed;
            SetLane();
            


            

            if(Keyboard.GetState().IsKeyDown(Keys.W) && Lane > 0 && WReleased)
            {
                WReleased = false;
                Lane--;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.W))
            {
                WReleased = true;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.S) && Lane < 3 && SReleased)
            {
                SReleased = false;
                Lane++;
            }

            if(Keyboard.GetState().IsKeyUp(Keys.S))
            {
                SReleased = true;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Speed = 5;
                //increase speed
                //increase temperature
            }

            //add a and d rotation in air
            if(Keyboard.GetState().IsKeyDown(Keys.A))
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


            _box.X = (int)_position.X;
            _box.Y = (int)_position.Y;
        }

        public int Temperature 
        {
            get {  return _temperature; }
            set { _temperature = value; }
        }
    }
}

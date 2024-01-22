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
        private int _temperature;
        


        public Player() : base()
        { }

        public Player(Vector2 inPosition, Rectangle inBox, int inLane, int inSpeed)
            : base(inPosition, inBox, inLane, inSpeed)
        {
            Position = inPosition;
            Box = inBox;
            Lane = inLane;
            Speed = inSpeed;

        }

        public override void LoadContent(ContentManager myContent)
        {
            myContent.RootDirectory = "Content";
            // add textures
            _textureForward = myContent.Load<Texture2D>("BikeForward");
            //_textureTurningRight = myContent.Load<Texture2D>("");//ADD TEXTURES
            //_textureTurningLeft = myContent.Load<Texture2D>("");//ADD TEXTURES
            //_textureVibrate = myContent.Load<Texture2D>("");//ADD TEXTURES

        }

        public override void Update()
        {
            Position = new Vector2(Position.X + Speed, Position.Y);
            _texture = _textureForward;

            if(Keyboard.GetState().IsKeyDown(Keys.W) && Lane < 3)
            {
                Lane++;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.S) && Lane > 0)
            {
                Lane--;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Speed = 5;
                //increase speed
                //increase temperature
            }
            //add a and d rotation in air
            

        }

        public int Temperature 
        {
            get {  return _temperature; }
            set { _temperature = value; }
        }
    }
}

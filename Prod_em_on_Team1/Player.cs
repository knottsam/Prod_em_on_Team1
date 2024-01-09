using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Prod_em_on_Team1
{
    internal class Player : Sprite
    {
        private Texture2D _textureForward;
        private Texture2D _textureTurningRight;
        private Texture2D _textureTurningLeft;


        public Player()
        { }

        public void LoadContent(ContentManager myContent)
        {
            myContent.RootDirectory = "Content";
            // add 3 textures
            _textureForward = myContent.Load<Texture2D>("");//
            _textureTurningRight = myContent.Load<Texture2D>("");//
            _textureTurningLeft = myContent.Load<Texture2D>("");//

        }

        public override void Update()
        {
            Position = new Vector2(Position.X + Speed, Position.Y);
        }

        public int Speed
        {
            get; set;
        }
        public int Temperature 
        {
            get; set;
        }
    }
}

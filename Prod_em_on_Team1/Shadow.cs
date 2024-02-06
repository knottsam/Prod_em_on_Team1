using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Prod_em_on_Team1
{
    internal class Shadow : Sprite
    {
        private Player _player;
        public Shadow() { }

        public Shadow(Player inPlayer)
        {
            _player = inPlayer;
        }

        public override void Update(GameTime gameTime)
        {
            _position.X = _player.Position.X;
            _position.Y = _player.GroundPosition;
            _speed.X = _player.Speed.X;
        }

        public void LoadContent(ContentManager myContent)
        {
            myContent.RootDirectory = "Content";

            _texture = myContent.Load<Texture2D>("");//add texture
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(_player.Position.Y > _player.GroundPosition && _player.LaneTransition == 0)
            {
                spriteBatch.Draw(_texture, _position, null, Color.White, _angleOfRotation, Origin, _scale, SpriteEffects.None, 0);
            }
        }
    }
}

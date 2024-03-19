using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Prod_em_on_Team1
{
    internal class BikeTempBar
    {
        private readonly float _maxTemp;
        private float _temp;
        private Texture2D back, front;
        private Vector2 _backPosition, _frontPosition;
        private Rectangle _part;
        //private readonly ProgressBar _healthBar;

        public BikeTempBar(ContentManager content, Vector2 backPosition, Vector2 frontPosition)
        {
            back = content.Load<Texture2D>("stats board");
            front = content.Load<Texture2D>("front");

            _maxTemp = 100f;
            _temp = 0;
            _backPosition = backPosition;
            _frontPosition = frontPosition;
            _part = new Rectangle(0,0,front.Width, front.Height);
            //_healthBar = new(back, front, _maxHealth, new(100, 100));
        }

        public void Update(Player player)
        {
            _backPosition.X += player.Speed.X;
            _frontPosition.X += player.Speed.X;
            _temp = player.Temperature;
            _part.Width = (int)(_temp / _maxTemp * front.Width);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(back, _backPosition, null, Color.White, 0, Vector2.Zero, 3f, SpriteEffects.None, 1f);
            spriteBatch.Draw(front, _frontPosition, _part, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}



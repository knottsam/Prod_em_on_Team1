using Microsoft.Xna.Framework;

namespace Prod_em_on_Team1
{
    internal class Camera
    {
        public void Follow(Sprite target)
        {
            Matrix Position = Matrix.CreateTranslation(
                -target.Position.X - (target.Box.Width / 2),
                -target.Position.Y - (target.Box.Width / 2), //change this so the height doesn't change
                0);

            Matrix offset = Matrix.CreateTranslation(
                Game1.ScreenWidth / 2,
                Game1.ScreenHeight / 2,
                0);

            Transform = Position * offset;
        }
        public Matrix Transform { get; private set; }
    }
}

using Microsoft.Xna.Framework;

namespace Prod_em_on_Team1
{
    internal class Camera
    {
        public void Follow(Sprite target)
        {
            Matrix Position = Matrix.CreateTranslation(
                -target.Position.X - (target.Box.Width / 2),
                0, 
                0);

            Matrix offset = Matrix.CreateTranslation(
                300,
                0,
                0);


            Transform = Position * offset;
        }
        public Matrix Transform { get; private set; }
    }
}

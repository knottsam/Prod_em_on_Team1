using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Prod_em_on_Team1
{
    public class TempBoard : Sprite
    {
        public TempBoard(ContentManager content) {
            _position = new Vector2(200, 600);
            _texture = content.Load<Texture2D>($"TEMPNORMAL");
        }  

    }
}

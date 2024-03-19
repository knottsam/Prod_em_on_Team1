using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Prod_em_on_Team1
{
    public class Ramp : Sprite
    {

        private Texture2D _texture;
        public Ramp() : base()
        { }

        public Ramp(Vector2 inPosition, Rectangle inBox, Texture2D texture)  
        {
            _position = inPosition;
            _box = inBox;
            _texture = texture;

        }

        


    }
}

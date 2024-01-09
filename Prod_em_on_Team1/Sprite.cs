using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    internal class Sprite
    {
        protected Texture2D _texture;
        public Sprite()
        { }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update()
        {

        }
    }
}

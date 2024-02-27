using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prod_em_on_Team1
{
    internal class sprite
    {
        protected Texture2D spriteTexture;
        public Vector2 spritePosition;
        protected Rectangle spriteBox;
        protected Color spriteColour;

        public sprite()
        { }

        public sprite(Texture2D spriteTexture, Vector2 spritePosition, Rectangle spriteBox, Color spriteColour)
        {
            this.spriteTexture = spriteTexture;
            this.spritePosition = spritePosition;
            this.spriteBox = spriteBox;
            this.spriteColour = spriteColour;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, spritePosition, spriteColour);

        }

        public Vector2 Position
        {
            get { return spritePosition; }
            set { spritePosition = value; }
        }
        public Rectangle BoundingBox
        {
            get { return spriteBox; }
            set { spriteBox = value; }
        }

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }

        }
    }
}

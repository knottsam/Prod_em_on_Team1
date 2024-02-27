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
    internal class loading : sprite
    {
        public loading(Texture2D spriteTexture, Vector2 spritePosition, Rectangle spriteBox, Color spriteColour)
        {
            this.spriteTexture = spriteTexture;
            this.spritePosition = spritePosition;
            this.spriteBox = spriteBox;
            this.spriteColour = spriteColour;
        }
        public void LoadContent(ContentManager myContent)
        {
            myContent.RootDirectory = "content";
            spriteTexture = myContent.Load<Texture2D>("loading1");
        }
    }
}

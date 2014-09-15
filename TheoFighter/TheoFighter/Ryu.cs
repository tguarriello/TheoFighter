using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheoFighter
{
    class Ryu : Character
    {
        Animation idle ;
        Animation jump ;
        Animation punch;

        public Ryu()
            : base()
        {

        }

        public void Load(ContentManager Content)
        {
            sheet = Content.Load<Texture2D>("RyuSheet");

            if (sheet != null)
            {
                idle = new Animation(0, 92, 48, 82, 5, sheet);
                jump = new Animation(0, 266, 40, 90, 7, sheet);
                punch = new Animation(0, 456, 50, 80, 6, sheet);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animation current = idle;

            current.Draw(spriteBatch);
        }


    }
}

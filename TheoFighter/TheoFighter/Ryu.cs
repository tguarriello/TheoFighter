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
        

        public Ryu()
            : base()
        {

        }

        public void Load(ContentManager Content)
        {
            sheet = Content.Load<Texture2D>("RyuSheet");

            Animation idle = new Animation(0, 92, 48, 82, 5, sheet);
            Animation jump = new Animation(0, 266,40, 90, 7, sheet);
            Animation punch = new Animation(0, 456, 50, 80, 6, sheet);
        }


    }
}

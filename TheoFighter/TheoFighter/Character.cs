using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheoFighter
{
    abstract class Character
    {        
        protected Vector2 position;
        protected float speed;

        protected Texture2D sheet;

        protected List<Animation> animations;

        protected const int IDLE = 0;
        protected const int WALK = 1;
        protected const int JUMP = 2;
        protected const int PUNCH = 3;
        protected const int KICK = 4;

        protected Character()
        {

        }
    }
}

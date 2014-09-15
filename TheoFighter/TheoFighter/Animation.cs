using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheoFighter
{
    class Animation
    {
        int frameX;
        int frameY;
        int width;
        int height;

        GameTime elapsedTime = new GameTime();
        int frameCount;
        int speed;


        Rectangle rect;
        Texture2D sheet;

        public Animation(int x, int y, int newWidth, int newHeight, int length, Texture2D newSheet)
        {
            frameX = x;
            frameY = y;
            width = newWidth;
            height = newHeight;
            frameCount = length;
            sheet = newSheet;

            rect = new Rectangle(x, y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rect.X = ((int)elapsedTime.TotalGameTime.Seconds % frameCount) * frameX;
            spriteBatch.Draw(sheet, rect, Color.White);
        }


    }
}

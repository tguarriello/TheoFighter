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
        int speed = 24;
        bool stop;
        float deltaTime;


        Rectangle sourceRect;
        Rectangle destRect;
        Texture2D sheet;

        public Animation(int x, int y, int newWidth, int newHeight, int length, Texture2D newSheet)
        {
            frameX = x;
            frameY = y;
            width = newWidth;
            height = newHeight;
            frameCount = length;
            sheet = newSheet;
            destRect.Width = width;
            destRect.Height = height;

            sourceRect = new Rectangle(x, y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(sourceRect != null)
                spriteBatch.Draw(sheet, destRect, sourceRect, Color.White);
        }

        public void Update(GameTime gameTime, int x, int y)
        {
            deltaTime += gameTime.ElapsedGameTime.Milliseconds;
            if(!stop)
                sourceRect.X = (int)((deltaTime / 200)  % frameCount) * width;

            destRect.X = x;
            destRect.Y = y;
       
        }

        public void Stop()
        {
            stop = true;
            
            
        }

        public void Start()
        {
            deltaTime = 0;
            stop = false;
            sourceRect.X = frameX;
            sourceRect.Y = frameY;
        }


    }
}

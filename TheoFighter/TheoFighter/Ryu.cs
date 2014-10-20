using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheoFighter
{
    class Ryu : Character
    {
        PlayerInput input;
        bool landed = true;
        Animation current = null;
        Animation idle ;
        Animation jump ;
        Animation punch;

        Vector2 velocity;

         
        float deltaTime = 0.0f;

        public Ryu()
            : base()
        {
            velocity = new Vector2(0, 0);
            position = new Vector2(100, 200);
            speed = 10;
        }

        public void Load(ContentManager Content)
        {
            sheet = Content.Load<Texture2D>("RyuSheet");

            if (sheet != null)
            {
                idle = new Animation(0, 5, 48, 82, 9, sheet);
                jump = new Animation(0, 266, 40, 90, 7, sheet);
                punch = new Animation(0, 456, 50, 80, 6, sheet);
            }

            input = new PlayerInput(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Space);
            current = idle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            if(current != null)
                current.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            deltaTime += gameTime.ElapsedGameTime.Milliseconds;

            if (current == null)
                return;
            current.Update(gameTime, (int)position.X, (int)position.Y);

            HandleInput();

            if (position.Y > 200)
            {
                position.Y = 200;
                landed = true;
                current = idle;
            }
            deltaTime = 0;
        }

        private void Jump()
        {
            landed = false;
            velocity.Y  = (deltaTime / 100) * -200;
            current = jump;

        }

        private void HandleInput()
        {
            input.Update();


            if (input.isDownLeft)
            {
                velocity.X = (-deltaTime/100) * speed;
                //TODO: animation face left
            }

            else if (input.isDownRight)
            {
                velocity.X = (deltaTime/100) * speed;
                //TODO: animation face right
            }
            else { velocity.X = 0; }


            if (input.isDownUp)
            {
                if (landed)
                    Jump();
            }

            position += velocity;
 
            velocity.Y += 2;
        }

    }
}

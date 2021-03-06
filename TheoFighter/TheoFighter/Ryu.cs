﻿using Microsoft.Xna.Framework;
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
        bool jumping = false;
        bool landed = true;
        bool punching = false;
        Animation current = null;
        Animation idle ;
        Animation jump ;
        Animation punch;

        Vector2 velocity;

         
        float deltaTime = 0.0f;
        float animationPlayTime = 0.0f;

        public Ryu()
            : base()
        {
            velocity = new Vector2(0, 0);
            position = new Vector2(100, 380);
            speed = 10;
        }

        public void Load(ContentManager Content)
        {
            sheet = Content.Load<Texture2D>("RyuSheet");

            if (sheet != null)
            {
                idle = new Animation(0, 5, 48, 82, 9, sheet);
                jump = new Animation(0, 267, 40, 90, 6, sheet);
                punch = new Animation(0, 89, 50, 80, 6, sheet);
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
            if (current == null)
                return;
            deltaTime = gameTime.ElapsedGameTime.Milliseconds;

            if(punching)
            {
                animationPlayTime += deltaTime;
                if (animationPlayTime > 0.46f)
                    current = idle;
            }


            velocity.Y += (deltaTime / 100) * 2;

            HandleInput();


            position += velocity;
            Landed();

            current.Update(gameTime, (int)position.X, (int)position.Y);

            deltaTime = 0;
        }

        private void HandleInput()
        {
            input.Update();

            if (input.isDownLeft)
            {
                velocity.X = (-deltaTime / 100) * speed;
                //TODO: animation face left
            }

            else if (input.isDownRight)
            {
                velocity.X = (deltaTime / 100) * speed;
                //TODO: animation face right
            }
            else { velocity.X = 0; }

            //handle jump button
            if (input.isDownUp)
            {
                if (landed)
                    Jump();
            } 
            //handle punch button
           if(input.isDownPunch)
           {
               Punch();
           }
        }
        //velocity.Y += (deltaTime / 100) * 2;
        private void Jump()
        {
            jumping = true;
            landed = false;
            velocity.Y  = (deltaTime / 100) * -50;
            if(current != jump)
            {
                //current.Stop();
                current = jump;
                current.Start();
            }
        }

        private void Landed()
        {
            if (position.Y > 400)
            {
                if (landed == false)
                {
                    landed = true;
                    //current.Stop();
                    current = idle;
                    current.Start();
                }
                position.Y = 400;
                
                jumping = false;
            }
        }

        public void Punch()
        {
            punching = true;
            current = punch;
        }



    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace TheoFighter
{
    class PlayerInput
    {
        //Keys[] pressedkeys;
        public KeyboardState keyState = new KeyboardState();
        Keys up;
        Keys down;
        Keys left;
        Keys right;
        Keys punch;

        public bool isDownUp = false;
        public bool isDownDown = false;
        public bool isDownLeft = false;
        public bool isDownRight = false;
        public bool isDownPunch = false;

        public PlayerInput(Keys newUp, Keys newDown, Keys newLeft, Keys newRight, Keys newPunch)
        {
            //pressedkeys = keyboard.GetPressedKeys();
            up = newUp;
            down = newDown;
            left = newLeft;
            right = newRight;
            punch = newPunch;
        }

        public void Update()
        {
            keyState = Keyboard.GetState();
            isDownUp = keyState.IsKeyDown(up);
            isDownDown = keyState.IsKeyDown(down);
            isDownLeft = keyState.IsKeyDown(left);
            isDownRight = keyState.IsKeyDown(right);
            isDownPunch = keyState.IsKeyDown(punch);
        }
        
    }
}

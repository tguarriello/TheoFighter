using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace TheoFighter
{
    class PlayerInput
    {
        //Keys[] pressedkeys;
        public KeyboardState keyState = new KeyboardState();
        Keys[] keys = new Keys[5];
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

            keys[0] = up;
            keys[1] = down;
            keys[2] = left;
            keys[3] = right;
            keys[4] = punch;
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD41.Util
{
    
    public static class Input
    {

        public enum MouseButton { LEFT, MIDDLE, RIGHT };

        private static KeyboardState oldKeyState;
        private static KeyboardState newKeyState;

        private static MouseState oldMouseState;
        private static MouseState newMouseState;

        public static void Update()
        {
            oldKeyState = newKeyState;
            newKeyState = Keyboard.GetState();

            oldMouseState = newMouseState;
            newMouseState = Mouse.GetState();
        }

        #region Keyboard
        public static bool IsKeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
                {
                    oldKeyState = newKeyState;
                    return true;
                }
            }
            return false;
        }

        public static bool IsKeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyUp(key) && oldKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsKeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsKeyUp(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Mouse

        public static bool IsMouseBtnClicked(MouseButton mouseBtn)
        {

            switch (mouseBtn)
            {
                case MouseButton.LEFT:
                    if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton != ButtonState.Pressed)
                    {
                        return true;
                    }
                    break;
                case MouseButton.MIDDLE:
                    if (newMouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton != ButtonState.Pressed)
                    {
                        return true;
                    }
                    break;
                case MouseButton.RIGHT:
                    if (newMouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton != ButtonState.Pressed)
                    {
                        return true;
                    }
                    break;
            }

            
            return false;
        }

        public static Vector2 GetMousePosition()
        {
            return newMouseState.Position.ToVector2();
        }

        #endregion

    }
}

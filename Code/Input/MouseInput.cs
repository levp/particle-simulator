using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ParticleEngine.Input
{
    static class MouseInput
    {
        private static MouseState prevState;
        private static MouseState currentState;

        public static void UpdateState()
        {
            prevState = currentState;
            currentState = Mouse.GetState();
        }

        public static Vector2 Position
        {
            get { return new Vector2(currentState.X, currentState.Y); }
        }

        public static bool LmbIsDown()
        {
            return currentState.LeftButton == ButtonState.Pressed;
        }

        public static bool LmbJustClicked()
        {
            return currentState.LeftButton == ButtonState.Pressed
                   && prevState.LeftButton == ButtonState.Released;
        }
    }
}
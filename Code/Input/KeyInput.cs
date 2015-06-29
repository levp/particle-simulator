using Microsoft.Xna.Framework.Input;

namespace ParticleEngine.Input
{
    static class KeyInput
    {
        private static KeyboardState prevState;
        private static KeyboardState currentState;

        public static void UpdateState()
        {
            prevState = currentState;
            currentState = Keyboard.GetState();
        }

        public static bool IsDown(Keys key)
        {
            return currentState.IsKeyDown(key);
        }

        public static bool JustPressed(Keys key)
        {
            return currentState.IsKeyDown(key) && prevState.IsKeyUp(key);
        }
    }
}
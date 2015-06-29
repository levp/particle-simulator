using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleEngine
{
    static class Resources
    {
        public static Texture2D Pixel { get; private set; }

        public static void Load(GraphicsDevice device)
        {
            Pixel = new Texture2D(device, 1, 1, false, SurfaceFormat.Color);
            Pixel.SetData(new[] {Color.White});
        }
    }
}
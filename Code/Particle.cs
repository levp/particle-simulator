using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleEngine
{
    sealed class Particle
    {
        private static readonly Random Rnd = new Random(41567);

        private Vector2 position;
        private Vector2 direction;

        public Particle()
        {
            position.X = Rnd.Next(Sys.Width);
            position.Y = Rnd.Next(Sys.Height);
        }

        public void RandomizeMomentum(float maxMagnitude)
        {
            direction.X = (float) (Rnd.NextDouble());
            direction.Y = (float) (Rnd.NextDouble());
            float randMag = (float) (Rnd.NextDouble())*maxMagnitude;
            direction = Vector2.Normalize(direction)*randMag;
        }

        public void StopMomentum()
        {
            direction = Vector2.Zero;
        }

        public void Update(Vector2 gravityCenter, float gravityMagnitude)
        {
            Vector2 delta = Vector2.Normalize(gravityCenter - position)*gravityMagnitude;
            direction += delta;
            position += direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.Pixel, position, Color.DarkGray);
        }
    }
}
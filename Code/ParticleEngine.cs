using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ParticleEngine.Input;

namespace ParticleEngine
{
    public class ParticleEngine : Game
    {
        private const int ParticleCount = 100000;
        private const float GravityMagnitude = 0.05f;

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<Particle> particles;

        public ParticleEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Sys.Width;
            graphics.PreferredBackBufferHeight = Sys.Height;
            graphics.IsFullScreen = false;
            graphics.PreferMultiSampling = false;
            graphics.ApplyChanges();

            IsFixedTimeStep = true;
            IsMouseVisible = true;
            Window.Title = "Particle Engine";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Resources.Load(GraphicsDevice);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            particles = new List<Particle>(ParticleCount);
            for (int i = 0; i < ParticleCount; i++)
            {
                particles.Add(new Particle());
            }
        }

        protected override void Update(GameTime gameTime)
        {
            MouseInput.UpdateState();
            KeyInput.UpdateState();

            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Update(MouseInput.Position, GravityMagnitude);
            }

            if (KeyInput.JustPressed(Keys.Space))
            {
                for (int i = 0; i < particles.Count; i++)
                    particles[i].StopMomentum();
            }

            if (KeyInput.JustPressed(Keys.Enter))
            {
                for (int i = 0; i < particles.Count; i++)
                    particles[i].RandomizeMomentum(4);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
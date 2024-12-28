using FinialProject.Framework.Scenes;
using Microsoft.Xna.Framework;
using System;


namespace FinialProject.Framework.Transitions
{
    public class DelayTransition : Transition
    {
        private TimeSpan counter = TimeSpan.Zero;
        private readonly TimeSpan delay;

        public DelayTransition(IScene scene, TimeSpan delay) : base(scene)
        {
            this.delay = delay;
        }

        public override void Update(GameTime gameTime)
        {
            counter += gameTime.ElapsedGameTime;
            if (counter >= delay)
            {
                Ended = true;
            }
        }
    }
}

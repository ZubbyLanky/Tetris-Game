﻿using FinialProject.Framework.Messaging;
using FinialProject.Framework.Scenes;
using Microsoft.Xna.Framework;
using System;


namespace FinialProject.Framework.Services
{
    public sealed class FpsService : GameService
    {
        private TimeSpan elapsed = TimeSpan.Zero;
        private readonly TimeSpan updateInterval;
        private readonly int updateSeconds;
        private float counter;

        public FpsService(IScene scene, int updateSeconds = 5) : base(scene)
        {
            this.updateSeconds = updateSeconds;
            updateInterval = TimeSpan.FromSeconds(updateSeconds);
        }

        public override void Update(GameTime gameTime)
        {
            counter += 1.0F;
            elapsed += gameTime.ElapsedGameTime;
            if (elapsed >= updateInterval)
            {
                var fps = counter / updateSeconds;
                Publish(new FpsMessage(fps));
                counter = 0;
                elapsed = TimeSpan.Zero;
            }
        }
    }
}

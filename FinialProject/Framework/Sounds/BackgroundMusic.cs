﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinialProject.Framework.Sounds
{
    /// <summary>
    /// Represents the background music to be played in the game.
    /// </summary>
    /// <seealso cref="TetrisSharp.Framework.Component" />
    public sealed class BackgroundMusic : Component
    {
        #region Private Fields

        private readonly SoundEffect[] musicEffects;
        private readonly TimeSpan soundStatusCheckInterval = TimeSpan.FromSeconds(5);
        private readonly float volume;
        private int currentIndex = 0;
        private TimeSpan elapsedGameTime;
        private bool looped;
        private SoundEffectInstance musicEffectInstance;
        private bool stopped = true;
        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundMusic"/> class.
        /// </summary>
        /// <param name="musicEffects">The sound effects for each of the background music.</param>
        /// <param name="volume">The volume to play.</param>
        /// <param name="looped">The boolean value which indicates whether the background music should be looped.</param>
        public BackgroundMusic(IEnumerable<SoundEffect> musicEffects, float volume = 1.0F, bool looped = true)
        {
            this.musicEffects = musicEffects.ToArray();
            this.volume = volume;
            this.looped = looped;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Plays the background music.
        /// </summary>
        public void Play()
        {
            if (stopped)
            {
                currentIndex = 0;
                Play(currentIndex);
                stopped = false;
            }
        }

        /// <summary>
        /// Stops playing the background music.
        /// </summary>
        public void Stop()
        {
            Stop(true);
        }

        public override void Update(GameTime gameTime)
        {
            if (!stopped)
            {
                elapsedGameTime += gameTime.ElapsedGameTime;
                if (elapsedGameTime >= soundStatusCheckInterval)
                {
                    if (musicEffectInstance.State == SoundState.Stopped)
                    {
                        currentIndex = (currentIndex + 1) % musicEffects.Length;
                        if (currentIndex == 0 && !looped)
                        {
                            Stop();
                            return;
                        }

                        Play(currentIndex);
                    }
                    elapsedGameTime = TimeSpan.Zero;
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        public SoundState State
        {
            get
            {
                if (musicEffectInstance != null && !musicEffectInstance.IsDisposed)
                {
                    return musicEffectInstance.State;
                }

                return SoundState.Stopped;
            }
        }

        public float Volume
        {
            get
            {
                return musicEffectInstance.Volume;
            }
            set
            {
                if (!musicEffectInstance.IsDisposed)
                {
                    musicEffectInstance.Volume = value;
                }
            }
        }

        public void Pause()
        {
            if (!musicEffectInstance.IsDisposed)
            {
                musicEffectInstance.Pause();
            }
        }

        public void Resume()
        {
            if (!musicEffectInstance.IsDisposed)
            {
                musicEffectInstance.Resume();
            }
        }

        private void Play(int index)
        {
            Stop(false);
            musicEffectInstance = musicEffects[index].CreateInstance();
            musicEffectInstance.IsLooped = false;
            musicEffectInstance.Volume = this.volume;
            musicEffectInstance.Play();
        }
        private void Stop(bool stopAll)
        {
            if (musicEffectInstance != null &&
                !musicEffectInstance.IsDisposed)
            {
                musicEffectInstance.Stop(true);
                musicEffectInstance.Dispose();
            }

            if (stopAll && !stopped)
            {
                stopped = true;
                currentIndex = 0;
            }
        }
        #endregion Private Methods
    }
}

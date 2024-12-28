using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;


namespace FinialProject.Framework.Sounds
{
    /// <summary>
    /// Represents a sound effect in the game.
    /// </summary>
    /// <seealso cref="TetrisSharp.Framework.Component" />
    public sealed class Sound : Component
    {
        #region Private Fields

        private static readonly object lockObj = new object();
        private readonly SoundEffect soundEffect;
        private readonly float volume;
        private SoundEffectInstance soundEffectInstance;
        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sound"/> class.
        /// </summary>
        /// <param name="soundEffect">The sound effect asset for playing the sound.</param>
        /// <param name="volume">The volume of the sound.</param>
        public Sound(SoundEffect soundEffect, float volume = 1.0F)
        {
            this.soundEffect = soundEffect;
            this.volume = volume;
        }

        #endregion Public Constructors

        #region Public Methods

        public SoundState State
        {
            get
            {
                if (soundEffectInstance != null && !soundEffectInstance.IsDisposed)
                {
                    return soundEffectInstance.State;
                }

                return SoundState.Stopped;
            }
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
        public void Play()
        {
            Stop();

            lock (lockObj)
            {
                soundEffectInstance = soundEffect.CreateInstance();
                soundEffectInstance.Volume = this.volume;
                soundEffectInstance.Play();
            }
        }
        /// <summary>
        /// Stops playing the sound.
        /// </summary>
        public void Stop()
        {
            lock (lockObj)
            {
                if (soundEffectInstance != null &&
                    !soundEffectInstance.IsDisposed)
                {
                    try
                    {
                        soundEffectInstance.Stop(true);
                        soundEffectInstance.Dispose();
                    }
                    catch { }
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        #endregion Public Methods
    }
}

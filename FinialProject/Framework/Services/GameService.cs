using FinialProject.Framework.Messaging;
using FinialProject.Framework.Scenes;


namespace FinialProject.Framework.Services
{
    /// <summary>
    /// Represents the base class for the game services.
    /// </summary>
    /// <seealso cref="TetrisSharp.Framework.Component" />
    /// <seealso cref="TetrisSharp.Framework.Services.IGameService" />
    public abstract class GameService : Component, IGameService
    {
        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GameService"/> class.
        /// </summary>
        /// <param name="scene">The scene to which the current game service belongs.</param>
        protected GameService(IScene scene)
        {
            this.Scene = scene;
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>
        /// Gets the instance of the scene in which current service
        /// has involved.
        /// </summary>
        /// <value>
        /// The instance of the scene.
        /// </value>
        public IScene Scene { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            Scene.Game.MessageDispatcher.DispatchMessageAsync(this, message);
        }

        #endregion Public Methods
    }
}

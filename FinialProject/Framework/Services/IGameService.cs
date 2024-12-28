using FinialProject.Framework.Messaging;
using FinialProject.Framework.Scenes;

namespace FinialProject.Framework.Services
{
    /// <summary>
    /// Represents that the implemented classes are game services.
    /// </summary>
    /// <remarks>
    /// Game service is a game component that performs calculations
    /// and emits game messages. Game services might be resource-comsuming,
    /// as a result, developers can choose whether a game service needs
    /// to be included in a game scene.
    /// </remarks>
    /// <seealso cref="TetrisSharp.Framework.IComponent" />
    /// <seealso cref="TetrisSharp.Framework.Messaging.IMessagePublisher" />
    public interface IGameService : IComponent, IMessagePublisher
    {
        #region Public Properties

        /// <summary>
        /// Gets the instance of the scene in which current service
        /// has involved..
        /// </summary>
        /// <value>
        /// The instance of the scene.
        /// </value>
        IScene Scene { get; }
        #endregion Public Properties
    }
}

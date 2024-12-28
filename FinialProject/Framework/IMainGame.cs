using FinialProject.Framework.Messaging;
using FinialProject.Framework.Scenes;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace FinialProject.Framework
{
    /// <summary>
    /// Represents that the implemented classes are the games created by Ovow Framework.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{TetrisSharp.Framework.Scenes.IScene}" />
    /// <seealso cref="System.IDisposable" />
    
    public interface IMainGame : IDisposable
    {
        IScene ActiveScene { get; }

        IScene GetSceneByName(string sceneName);

        IMessageDispatcher MessageDispatcher { get; }

        GraphicsDevice GraphicsDevice { get; }

        void Exit();
    }

}

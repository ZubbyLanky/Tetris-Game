using FinialProject.Framework.Transitions;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace FinialProject.Framework.Scenes
{
    /// <summary>
    /// Represents that the implemented classes are game scenes which manage the lifetime
    /// of the contained objects.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{TetrisSharp.Framework.IComponent}" />
    /// <seealso cref="TetrisSharp.Framework.IVisibleComponent" />
    /// <seealso cref="System.IDisposable" />
    public interface IScene : ICollection<IComponent>, IVisibleComponent, IDisposable
    {
        #region Public Properties

        Color BackgroundColor { get; }
        bool Ended { get; }
        IMainGame Game { get; }

        ITransition In { get; }

        IScene Next { get; }
        ITransition Out { get; }

        #endregion Public Properties

        #region Public Methods

        void End();

        void Enter();

        void Leave();

        void Load(ContentManager contentManager);

        #endregion Public Methods
    }
}

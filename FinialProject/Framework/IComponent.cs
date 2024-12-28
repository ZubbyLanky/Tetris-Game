using Microsoft.Xna.Framework;
using System;


namespace FinialProject.Framework
{
    /// <summary>
    /// Represents that the implemented classes are game components.
    /// </summary>
    public interface IComponent : IEquatable<IComponent>
    {
        Guid Id { get; }

        bool IsActive { get; set; }

        void Update(GameTime gameTime);

    }
}

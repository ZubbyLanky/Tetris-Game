using Microsoft.Xna.Framework;
using System;


namespace FinialProject.Framework
{
    public abstract class Component : IComponent
    {
        public Guid Id { get; } = Guid.NewGuid();

        public bool IsActive { get; set; } = true;

        public bool Equals(IComponent other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is null)
            {
                return false;
            }

            return other.Id.Equals(this.Id);
        }

        public abstract void Update(GameTime gameTime);
    }
}

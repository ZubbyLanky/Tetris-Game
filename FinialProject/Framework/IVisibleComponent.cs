using FinialProject.Framework.Messaging;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FinialProject.Framework
{
    public interface IVisibleComponent : IComponent, IMessagePublisher, IMessageSubscriber
    {
        Rectangle BoundingBox { get; }

        Vector2 Position { get; }

        Texture2D Texture { get; }

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        bool CollisionDetective { get; }

        int Layer { get; set; }
    }
}

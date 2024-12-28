using FinialProject.Framework.Scenes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FinialProject.Framework.Sprites
{
    public class Sprite : VisibleComponent
    {
        public Sprite(IScene scene, Texture2D texture, Vector2 position)
            : base(scene, texture, position)
        {
        }

        protected override void DoDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.Wheat);
        }
    }
}

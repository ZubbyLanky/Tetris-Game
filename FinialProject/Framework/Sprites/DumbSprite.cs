using FinialProject.Framework.Scenes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace FinialProject.Framework.Sprites
{
    public sealed class DumbSprite : Sprite
    {
        public DumbSprite(IScene scene, Texture2D texture, Vector2 position) : base(scene, texture, position)
        {
        }

        public override bool CollisionDetective { get => false; set { } }
    }
}

using FinialProject.Framework.Messaging;


namespace FinialProject.Framework.Sprites
{
    public sealed class AnimationCompletedMessage : Message
    {
        public AnimationCompletedMessage(AnimatedSprite sprite) => Sprite = sprite;

        public AnimatedSprite Sprite { get; }
    }
}

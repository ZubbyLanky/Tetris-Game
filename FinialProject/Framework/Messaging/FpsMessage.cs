

namespace FinialProject.Framework.Messaging
{
    public sealed class FpsMessage : Message
    {
        public FpsMessage(float fps) => Fps = fps;

        public float Fps { get; }
    }
}

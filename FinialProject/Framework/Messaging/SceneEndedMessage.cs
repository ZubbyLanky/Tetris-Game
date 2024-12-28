using FinialProject.Framework.Scenes;


namespace FinialProject.Framework.Messaging
{
    public sealed class SceneEndedMessage : Message
    {
        public SceneEndedMessage(IScene scene)
        {
            this.Scene = scene;
        }
        public IScene Scene { get; }
    }
}

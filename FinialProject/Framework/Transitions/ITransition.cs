using FinialProject.Framework.Scenes;

namespace FinialProject.Framework.Transitions
{
    public interface ITransition : IVisibleComponent
    {
        IScene Scene { get; }

        bool Ended { get; }
    }
}

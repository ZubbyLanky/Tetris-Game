

namespace FinialProject.Framework.Messaging
{
    public sealed class ReachBoundaryMessage : Message
    {
        public ReachBoundaryMessage(Boundary boundary)
        {
            this.ReachedBoundary = boundary;
        }
        public Boundary ReachedBoundary { get; }
    }
}

using FinialProject.Framework.Services;

namespace FinialProject.Framework.Messaging
{
    public sealed class CollisionDetectedMessage : Message
    {
        public CollisionDetectedMessage(IVisibleComponent a,
            IVisibleComponent b,
            CollisionInfo collisionInformationA,
            CollisionInfo collisionInformationB)
        {
            this.A = a;
            this.B = b;
            this.CollisionInformationA = collisionInformationA;
            this.CollisionInformationB = collisionInformationB;
        }

        public IVisibleComponent A { get; }

        public IVisibleComponent B { get; }

        public CollisionInfo CollisionInformationA { get; }

        public CollisionInfo CollisionInformationB { get; }
    }
}

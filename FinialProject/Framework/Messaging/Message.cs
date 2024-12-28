using System;

namespace FinialProject.Framework.Messaging
{
    public abstract class Message : IMessage
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime Timestamp { get; } = DateTime.UtcNow;
    }
}

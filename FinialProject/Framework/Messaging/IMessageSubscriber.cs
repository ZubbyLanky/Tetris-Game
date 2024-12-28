using System;

namespace FinialProject.Framework.Messaging
{
    public interface IMessageSubscriber
    {
        void Subscribe<TMessage>(Action<object, TMessage> handler)
            where TMessage : IMessage;
    }
}

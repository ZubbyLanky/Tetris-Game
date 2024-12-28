using System;
using System.Threading.Tasks;

namespace FinialProject.Framework.Messaging
{
    public interface IMessageDispatcher
    {
        void RegisterHandler<TMessage>(Action<object, TMessage> handler)
            where TMessage : IMessage;

        Task DispatchMessageAsync<TMessage>(object publisher, TMessage message)
            where TMessage : IMessage;
    }
}

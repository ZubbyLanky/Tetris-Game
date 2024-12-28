using System;


namespace FinialProject.Framework.Messaging
{
    public interface IMessage
    {
        Guid Id { get; }

        DateTime Timestamp { get; }


    }
}

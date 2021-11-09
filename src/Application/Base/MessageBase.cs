using System;

namespace Application.Base
{
    public abstract class MessageBase
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }

        public MessageBase()
        {
            MessageType = GetType().Name;
        }
    }
}

using System.Text.Json.Serialization;

namespace Framework.Domain
{
    public abstract class DomainEvent : IEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        [JsonInclude] 
        public Guid Id { get; private set; }
        [JsonInclude]
        public DateTime CreationDate { get; private set; }
    }
}
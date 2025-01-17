using MassTransit;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;

namespace Framework.OutboxPublisher
{
    public class OutboxManager
    {
        private readonly IDbConnection _dbConnection;
       private readonly IBusControl _eventBus;

        public OutboxManager(IDbConnection dbConnectionm, IBusControl eventBus)
        {
            _dbConnection = dbConnectionm;
         _eventBus = eventBus;
        }

        public void Start(Assembly[] eventAssemblies)
        {
            var notSyncedOutbox = _dbConnection.GetOutboxes();
            if (notSyncedOutbox != null)
            {
                foreach (var item in notSyncedOutbox)
                {
                   _eventBus.Publish(ToEvent(item));
                    Console.WriteLine($"Publish Outbox :{item.EventBody}");
                }
                _dbConnection.UpdatePublishedDate(notSyncedOutbox.Select(x => x.Id));
            }
        }

        private object ToEvent(OutboxItem outboxItem)
        {
            Type type = Type.GetType(outboxItem.EventType);
            var @event = JsonConvert.DeserializeObject(outboxItem.EventBody, type, new JsonSerializerSettings
            {
                ContractResolver = new NonPublicPropertiesResolver()
            });
            return @event;
        }
    }
}
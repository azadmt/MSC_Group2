using Framework.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace Framework.Persistence
{
    public class TransactionalOutboxInterceptor : SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            var dbcontext = (eventData.Context );
            var outbox = dbcontext
                   .ChangeTracker
                   .Entries<IAggregateRoot>()
                   .Select(entry => entry.Entity)
                       .SelectMany(entity =>
                       {
                           var domainEvents = entity.GetChanges();
                           return domainEvents;
                       })
                       .ToList();

            var sb = new StringBuilder();
            sb.Append($"INSERT INTO outbox (EventId,EventType,EventBody) VALUES ");
            var paramItems = new List<SqlParameter>();
            for (int i = 0; i < outbox.Count; i++)
            {
                paramItems.Add(new SqlParameter($"@EventId{i}", outbox[i].Id.ToString()));
                paramItems.Add(new SqlParameter($"@EventType{i}", outbox[i].GetType().AssemblyQualifiedName));
                paramItems.Add(new SqlParameter($"@EventBody{i}", JsonConvert.SerializeObject(outbox[i])));

                sb.AppendLine($" (@EventId{i},@EventType{i},@EventBody{i}) ");
                if (i != outbox.Count - 1)
                    sb.Append($" , ");
            }

            dbcontext.Database
                     .ExecuteSqlRaw(sb.ToString(), paramItems.ToArray());

            return base.SavedChanges(eventData, result);
        }
    }
}
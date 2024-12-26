namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<DomainEvent> GetChanges();
    }
}
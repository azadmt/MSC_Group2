namespace Framework.Domain
{
    public abstract class Entity<TKey>
    {
        protected Entity()
        {

        }
        public Entity(TKey key)
        {
            Id = key;
        }
        public TKey Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            var other = obj as Entity<TKey>;
            if (other == null) return false;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
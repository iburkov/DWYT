namespace Tms.Domain.Base
{
    public abstract class EntityBase : IEntity<string>
    {
        public string Id { get; set; }
    }
}
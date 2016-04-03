using System;

namespace Tms.Domain.Base
{
    public abstract class EntityBaseWithStringKey : IEntity<string>
    {
        public string Id { get; protected set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
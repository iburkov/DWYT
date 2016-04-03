using System;

namespace Tms.Domain.Base
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }

        DateTime CreatedAt { get; set; }

        DateTime ModifiedAt { get; set; }
    }
}
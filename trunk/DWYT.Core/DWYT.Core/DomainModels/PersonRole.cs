using System;

namespace DWYT.Core.DomainModels
{
    public class PersonRole : DomainModel<Guid>
    {
        public virtual Person Person { get; set; }

        public virtual Role Role { get; set; }  
    }
}

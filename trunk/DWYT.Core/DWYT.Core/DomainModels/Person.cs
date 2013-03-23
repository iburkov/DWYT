using System;
using System.Collections.Generic;

namespace DWYT.Core.DomainModels
{
    public class Person : DomainModel<Guid>
    {
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual IList<PersonRole> PersonRoles { get; set; }
    }
}

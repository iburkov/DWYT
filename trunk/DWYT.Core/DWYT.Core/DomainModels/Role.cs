using System;
using System.Collections.Generic;

namespace DWYT.Core.DomainModels
{
    public class Role : DomainModel<Guid>
    {
        public virtual string Name { get; set; }

        public virtual IList<PersonRole> PersonRoles { get; set; }

        public virtual IList<RolePermission> RolePermissions { get; set; }
    }
}

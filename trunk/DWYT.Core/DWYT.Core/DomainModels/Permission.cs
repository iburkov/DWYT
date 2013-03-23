using System.Collections.Generic;

namespace DWYT.Core.DomainModels
{
    public class Permission : DomainModel<int>
    {
        public virtual string Name { get; set; }

        public virtual IList<RolePermission> RolePermissions { get; set; }
    }
}

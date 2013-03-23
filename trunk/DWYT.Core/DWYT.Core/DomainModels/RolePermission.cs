using System;

namespace DWYT.Core.DomainModels
{
    public class RolePermission : DomainModel<Guid>
    {
        public Role Role { get; set; }

        public Permission Permission { get; set; }
    }
}

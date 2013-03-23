using System;
using System.Collections.Generic;
using DWYT.Core.DomainModels;

namespace DWYT.Core.Interfaces.RepositoryInterfaces
{
    public interface IRoleRepository : IGenericRepository<Role, Guid>
    {
        void AssingPersonToRoles(Person person, IList<Role> roles);
    }
}

using System;
using DWYT.Core.DomainModels;
using System.Collections.Generic;
using DWYT.Core.ProjectBase.RepositoryRequestParams;

namespace DWYT.Core.Interfaces.RepositoryInterfaces
{
    public interface IPersonRepository : IGenericRepository<Person, Guid>
    {
        IList<Role> GetRoles(Person person);

        IList<Role> GetRoles(RolesGetRequest request);
    }
}

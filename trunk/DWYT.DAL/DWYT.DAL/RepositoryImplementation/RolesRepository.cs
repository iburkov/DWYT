using System;
using System.Collections.Generic;
using DWYT.Core.DomainModels;
using DWYT.Core.Interfaces.RepositoryInterfaces;
using DWYT.DAL.Infrastructure;

namespace DWYT.DAL.RepositoryImplementation
{
    public class RoleRepository : GenericRepository<Role, Guid>, IRoleRepository 
    {
        public void AssingPersonToRoles(Person person, IList<Role> roles)
        {
            //foreach (Role role in roles)
            //{
            //    role.Person = person;
            //}
            BatchUpdate(roles);
        }
    }
}
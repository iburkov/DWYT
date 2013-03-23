using System;
using System.Collections.Generic;
using DWYT.Core.Interfaces.RepositoryInterfaces;
using DWYT.Core.DomainModels;
using DWYT.Core.ProjectBase.RepositoryRequestParams;
using DWYT.DAL.Infrastructure;
using NHibernate;

namespace DWYT.DAL.RepositoryImplementation
{
    public class PersonRepository : GenericRepository<Person, Guid>, IPersonRepository
    {
        public IList<Role> GetRoles(Person person)
        {
            RolesGetRequest request = new RolesGetRequest { PersonId = person.Id };
            return GetRoles(request);
        }

        public IList<Role> GetRoles(RolesGetRequest request)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var query = session.QueryOver<PersonRole>();
                IList<Role> roles = query.Where(r => r.Person.Id == request.PersonId).Select(r => r.Role).List<Role>();
                return roles;
            }
        }
    }
}

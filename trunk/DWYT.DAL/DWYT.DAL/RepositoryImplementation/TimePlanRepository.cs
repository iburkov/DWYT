using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWYT.Core.DomainModels;
using DWYT.Core.Interfaces.RepositoryInterfaces;
using DWYT.DAL.Infrastructure;
using NHibernate;

namespace DWYT.DAL.RepositoryImplementation
{
    public class TimePlanRepository : GenericRepository<TimePlan, Guid>, ITimePlanRepository 
    {

    }
}

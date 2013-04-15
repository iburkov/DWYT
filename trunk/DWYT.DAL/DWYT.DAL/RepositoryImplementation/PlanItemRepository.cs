using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWYT.Core.DomainModels;
using DWYT.Core.Interfaces.RepositoryInterfaces;
using DWYT.DAL.Infrastructure;

namespace DWYT.DAL.RepositoryImplementation
{
    public class PlanItemRepository : GenericRepository<PlanItem, Guid>, IPlanItemRepository
    {

    }
}

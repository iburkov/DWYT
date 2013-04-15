using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWYT.Core.DomainModels;

namespace DWYT.Core.Interfaces.RepositoryInterfaces
{
    public interface IPlanItemRepository : IGenericRepository<PlanItem, Guid>
    {
    }
}

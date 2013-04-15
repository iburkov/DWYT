using System;

namespace DWYT.Core.DomainModels
{
    public class PlanItem : DomainModel<Guid>
    {
        public virtual TimePlan TimePlan { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DWYT.Core.DomainModels
{
    public class TimePlan : DomainModel<Guid>
    {
        public bool IsTemplate { get; set; }

        public TimePlan Template { get; set; }

        public IList<PlanItem> Tasks { get; set; }
    }
}
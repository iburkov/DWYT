using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWYT.Core.DomainModels
{
    public class TimePlan : DomainModel<Guid>
    {
        public TimePlanTemplate Template { get; set; }

        public IList<Task> Tasks { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

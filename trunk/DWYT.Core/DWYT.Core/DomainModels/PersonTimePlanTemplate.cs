using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWYT.Core.DomainModels
{
    public class PersonTimePlanTemplate : DomainModel<TimePlanTemplate>
    {
        public Person Person { get; set; }

        public TimePlanTemplate TimePlanTemplate { get; set; }
    }
}

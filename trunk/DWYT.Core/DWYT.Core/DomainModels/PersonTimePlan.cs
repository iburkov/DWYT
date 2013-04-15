using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWYT.Core.DomainModels
{
    public class PersonTimePlan
    {
        public Person Person { get; set; }

        public TimePlan TimePlan { get; set; }
    }
}

using System;

namespace DWYT.Core.DomainModels
{
    public class PersonTimePlan : DomainModel<Guid>
    {
        public Person Person { get; set; }

        public TimePlan TimePlan { get; set; }
    }
}
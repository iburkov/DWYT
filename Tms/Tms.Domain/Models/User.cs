using Tms.Domain.Base;

namespace Tms.Domain.Models
{
    public class User : EntityBaseWithStringKey
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
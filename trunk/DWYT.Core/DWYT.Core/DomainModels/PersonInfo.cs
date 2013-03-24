using System;

namespace DWYT.Core.DomainModels
{
    public class PersonInfo : DomainModel<Guid>
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual string CellPhoneNumber { get; set; }
    }
}

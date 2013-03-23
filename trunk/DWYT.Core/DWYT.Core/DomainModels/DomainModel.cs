using System;

namespace DWYT.Core.DomainModels
{
	public abstract class DomainModel<TKey>
	{
        public virtual TKey Id { get; protected set; }

        public virtual DateTime CreatedDate { get; set; }

	    public virtual Person CreatedBy { get; set; }

        public virtual DateTime ModifiedDate { get; set; }

        public virtual Person ModifiedBy { get; set; }
	}
}

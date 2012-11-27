using System;
using System.Collections;
using System.Collections.Generic;

namespace Southsand.Model
{
	public class Customer
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual DateTime Birthday { get; set; }

		public virtual Address HomeAddress { get; set; }
		public virtual Address WorkAddress { get; set; }
		public virtual Address BillingAddress { get; set; }

	}

	public class Visit
	{
		public virtual long Id { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual Location Location { get; set; }
		public virtual DateTime At { get; set; }
		public virtual TimeSpan Duration { get; set; }
	}

	public class Location
	{
		public virtual long Id { get; set; }
		public virtual string Name { get; set; }
		public virtual ICollection<Customer> Customers { get; set; }
	}
}
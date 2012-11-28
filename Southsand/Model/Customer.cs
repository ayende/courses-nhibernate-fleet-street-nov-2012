using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using Newtonsoft.Json;

namespace Southsand.Model
{
	public class Customer
	{
		public virtual long CustomerId { get; set; }
		public virtual string Email { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}

	public class Order
	{
		public virtual Customer Customer { get; set; }
	}
}
using System.Collections.Generic;

namespace Southsand.Model
{
	public class Email
	{
		public virtual int Id { get; set; }
		public virtual ICollection<object> Targets { get; set; }
	}

	public class Supplier
	{
		public virtual int Id { get; set; }
		public virtual string SupplierEmail { get; set; }
	}

	public class Employee
	{
		public virtual int Id { get; set; }
		public virtual string BusinessEmail { get; set; }
	}

}
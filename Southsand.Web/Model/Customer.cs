using System.Collections.Generic;

namespace Southsand.Web.Model
{
	public class Customer 
	{
		public virtual long CustomerId { get; set; }
		public virtual string Name{ get; set; }
		public virtual Person Person { get; set; }

		public virtual ICollection<Person> Related{ get; set; }
	}

	public class Person
	{
		public virtual long Id { get; set; }
		public virtual string Email { get; set; }
	}
}
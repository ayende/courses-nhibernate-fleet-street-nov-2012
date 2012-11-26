using System;

namespace Southsand.Model
{
	public class Customer
	{
		public virtual long Id { get; set; } 
		public virtual string Name { get; set; }
		public virtual DateTime Birthday { get; set; }
		public virtual Address HomeAddress { get; set; }
	}
}
namespace Southsand.Model
{
	public class Customer 
	{
		public virtual long CustomerId { get; set; }
		public virtual string Email { get; set; }
		public virtual Person Person { get; set; }
	}


	public class Person
	{
		public virtual long PersonId { get; set; }
		public virtual string Name { get; set; }
		public virtual Customer Customer { get; set; }
	}
}
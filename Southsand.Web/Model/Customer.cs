namespace Southsand.Web.Model
{
	public class Customer 
	{
		public virtual long CustomerId { get; set; }
		public virtual string Email { get; set; }
		public virtual int Version { get; set; }
	}
}
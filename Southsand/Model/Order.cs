namespace Southsand.Model
{
	public class Order
	{
		public virtual long Id { get; set; }
		public virtual  Customer Customer { get; set; }
	}
}
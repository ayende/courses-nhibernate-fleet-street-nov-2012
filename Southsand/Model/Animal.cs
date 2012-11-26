namespace Southsand.Model
{
	public abstract class Animal
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; } 
	}

	public class Dog : Animal
	{
		public virtual bool Barks { get; set; }
	}

	public class Cat : Animal
	{
		public virtual bool Purrs { get; set; }
	}
}
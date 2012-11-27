using System;
using NHibernate;
using NHibernate.Cfg;
using Southsand.Model;
using Environment = System.Environment;

namespace Southsand.Infrastructure
{
	public static class Global
	{
		private static readonly Lazy<ISessionFactory> theSessionFactory = new Lazy<ISessionFactory>(() =>
			{
				var cfg = new Configuration()
			   .DataBaseIntegration(properties =>
			   {
				   properties.SchemaAction = SchemaAutoAction.Update;
				   properties.Dialect<NHibernate.Dialect.MsSql2008Dialect>();
				   properties.ConnectionStringName = Environment.MachineName;
			   })
			   .AddAssembly(typeof(Customer).Assembly);

				//var persistentClass = cfg.GetClassMapping(typeof (Address));
				//var property = persistentClass.GetProperty("CustomerCount");
				//var selectable = property.ColumnIterator.First() as Formula;
				//selectable.FormulaString = "(select count(*) from [Customers] /* whoo hoo*/ c where c.HomeAddress = Id)";
				return cfg.BuildSessionFactory();
			});

		public static ISessionFactory SessionFactory
		{
			get { return theSessionFactory.Value; }
		}
	}

}
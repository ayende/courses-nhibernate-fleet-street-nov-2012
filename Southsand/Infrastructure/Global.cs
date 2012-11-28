using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Event.Default;
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

				return cfg.BuildSessionFactory();
			});

		public static ISessionFactory SessionFactory
		{
			get { return theSessionFactory.Value; }
		}
	}

}
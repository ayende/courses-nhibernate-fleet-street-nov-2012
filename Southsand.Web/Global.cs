using System;
using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using Southsand.Web.Model;
using Environment = System.Environment;

namespace Southsand.Web
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
			   .SetInterceptor(new ScreamDamnYou())
			   .Cache(properties =>
				   {
					   properties.Provider<HashtableCacheProvider>();
					   properties.UseQueryCache = true;
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
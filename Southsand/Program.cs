using System;
using Southsand.Infrastructure;
using Southsand.Model;

namespace Southsand
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			App_Start.NHibernateProfilerBootstrapper.PreStart();

			using (var session = Global.SessionFactory.OpenSession())
			using (session.BeginTransaction())
			{
				var customer = session.Get<Customer>(1L);
				Console.WriteLine(customer.HomeAddress.City);
			}

			//using (var session = Global.SessionFactory.OpenSession())
			//using (session.BeginTransaction())
			//{
			//	var customer = session.Get<Customer>(1L);
			//	Console.WriteLine(customer.Name);
			//	foreach (var location in customer.Locations)
			//	{
			//		Console.WriteLine("\t{0}", location.Name);
			//	}
			//}

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
		}
	}
}


using System;
using System.Collections;
using System.Collections.Generic;
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

			object id;
			using (var session = Global.SessionFactory.OpenSession())
			using (session.BeginTransaction())
			{
				var items = new List<object>();

				for (int i = 0; i < 10; i++)
				{
					var s = new Supplier
					{
						SupplierEmail = "s@s.com"
					};
					session.Save(s);
					
					items.Add(s);

					var e = new Employee
					{
						BusinessEmail = "e@e.com"
					};
					session.Save(e);
					items.Add(e);
				}

				id  = session.Save(new Email
					{
						Targets = items
					});

				session.Transaction.Commit();
			}

			//using (var session = Global.SessionFactory.OpenSession())
			//using (session.BeginTransaction())
			//{
			//	var email = session.Get<Email>(id);

			//	foreach (var target in email.Targets)
			//	{
			//		Console.WriteLine(target);
			//	}
				
			//	session.Transaction.Commit();
			//}

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


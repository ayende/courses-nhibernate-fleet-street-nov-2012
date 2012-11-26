using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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
			using(session.BeginTransaction())
			{
				var customer = new Customer()
					{
						Name = "Oren",
						Birthday = DateTime.Now
					};
				session.Save(customer);

				var location = new Location
					{
						Name = "London",
					};
				session.Save(location);

				session.Save(new Visit
					{
						Location = location,
						Customer = customer,
						At = DateTime.Today.AddDays(-1),
						Duration = TimeSpan.FromDays(7)
					});
				session.Transaction.Commit();
			}

			using (var session = Global.SessionFactory.OpenSession())
			using (session.BeginTransaction())
			{
				var customer = session.Get<Customer>(1L);
				Console.WriteLine(customer.Name);
				foreach (var location in customer.Locations)
				{
					Console.WriteLine("\t{0}", location.Name);
				}
			}

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
		}
	}
}


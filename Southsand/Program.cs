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
				session.Save(new Dog
					{
						Name = "Arava",
						Barks = true, // OMG HOW MUCH
					});

				session.Save(new Cat
					{
						Name = "Lady",
						Purrs = false
					});
				
				session.Transaction.Commit();
			}

			using (var session = Global.SessionFactory.OpenSession())
			using (session.BeginTransaction())
			{
				foreach (var animal in session.QueryOver<Animal>().List())
				{
					Console.WriteLine(animal.Name);
				}
				session.Transaction.Commit();
			}

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
		}
	}
}


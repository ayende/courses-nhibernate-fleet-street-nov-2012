using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
				session.Transaction.Commit();
			}

			

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
		}
	}
}


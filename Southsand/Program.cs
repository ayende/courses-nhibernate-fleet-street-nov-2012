using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using NHibernate;
using Southsand.Infrastructure;
using Southsand.Model;
using NHibernate.Linq;
using System.Linq;


namespace Southsand
{

	public static class NHExtensions
	{
		public static IFutureValue<TResult> ToFutureValue<TSource, TResult>(
			this IQueryable<TSource> source,
			Expression<Func<IQueryable<TSource>, TResult>> selector)
			where TResult : struct
		{

			var provider = (INhQueryProvider) source.Provider;
			var method = ((MethodCallExpression) selector.Body).Method;
			var expression = Expression.Call(null, method, source.Expression);
			return (IFutureValue<TResult>) provider.ExecuteFuture(expression);
		}
	}

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
				var list = session.Query<Customer>()
					   .Take(5)
					   .Skip(10)
					   .ToFuture();

				var cnt = session.Query<Customer>()
				                 .ToFutureValue(x=>x.Count());


				Console.WriteLine(cnt.Value);
				foreach (var customer in list)
				{
					Console.WriteLine(customer.Email);
				}
			}



			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
		}
	}
}


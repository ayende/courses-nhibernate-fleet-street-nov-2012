using System;
using System.Web.Mvc;
using NHibernate;
using Southsand.Web.Model;
using NHibernate.Linq;
using System.Linq;

namespace Southsand.Web.Controllers
{
	public class HomeController : NHibernateController
	{
		public ActionResult Orders()
		{
			var orders = Session.Query<Order>().ToList();

			var results = from o in orders
			              select new
				              {
								o.Id,
								o.Customer.Email
				              };

			return Json(results.ToArray());
		}
	}
}
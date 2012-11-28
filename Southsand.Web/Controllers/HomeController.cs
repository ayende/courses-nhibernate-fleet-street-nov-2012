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
		public ActionResult Index()
		{
			var customers = Session.Query<Customer>()
							.Cacheable()
			               .ToList();


			var r = from customer in customers
			        select new
				        {
					        customer.Name,
					        customer.Person.Email,
							Related = customer.Related.Select(x=>x.Email).ToList()
				        };
			return Json(r.ToList());

		}

		public ActionResult Update()
		{
			var c = Session.Get<Customer>(1L);
			c.Name = DateTime.Now.ToShortTimeString();
			return Json(c.Name);

		}

		public ActionResult Update2()
		{
			var c = Session.Get<Person>(1L);
			c.Email = DateTime.Now.ToShortTimeString();
			return Json(c.Email);

		}
	}
}
using System;
using System.Web.Mvc;
using NHibernate;
using Southsand.Web.Model;

namespace Southsand.Web.Controllers
{
	public class HomeController : NHibernateController
	{
		 public ActionResult Index(long id)
		 {
			 return Json(Session.Get<Customer>(id));
		 }

		 public ActionResult Update(long id, string email, int version)
		 {
			 var customer = Session.Get<Customer>(id);
			 if(customer.Version != version)
				throw new StaleObjectStateException("Customer", id);

			 customer.Email = email;
			
			 return Json("OK");
		 }
	}
}
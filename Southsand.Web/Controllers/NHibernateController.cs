using System.Web.Mvc;
using NHibernate;

namespace Southsand.Web.Controllers
{
	public class NHibernateController : Controller
	{
		 public new ISession Session { get; set; }

		 protected override void OnActionExecuting(ActionExecutingContext filterContext)
		 {
			 Session = Global.SessionFactory.OpenSession();
			 Session.BeginTransaction();
			 base.OnActionExecuting(filterContext);
		 }

		 protected override void OnActionExecuted(ActionExecutedContext filterContext)
		 {
			 using (Session)
			 {
				 if (filterContext.Exception != null)
					 return;
				 if (Session == null)
					 return;
				Session.Transaction.Commit();
			 }
			 base.OnActionExecuted(filterContext);
		 }

		 protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
		 {
			 return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
		 }
	}
}
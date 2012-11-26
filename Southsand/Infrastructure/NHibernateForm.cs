using System.Windows.Forms;
using NHibernate;

namespace Southsand.Infrastructure
{
	public class NHibernateForm : Form
	{
		public ISession Session { get; set; }

		protected override void OnLoad(System.EventArgs e)
		{
			Session = Global.SessionFactory.OpenSession();
			base.OnLoad(e);
		}

		protected override void OnClosed(System.EventArgs e)
		{
			if (Session != null)
				Session.Dispose();
			base.OnClosed(e);
		}

		protected void Commit()
		{
			using (var tx = Session.BeginTransaction())
			{
				tx.Commit();
			}
		}
	}
}
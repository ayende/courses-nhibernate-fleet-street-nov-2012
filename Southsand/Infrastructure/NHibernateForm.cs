using System.Windows.Forms;
using NHibernate;

namespace Southsand.Infrastructure
{
	public class NHibernateForm : Form
	{
		public ISession Session { get; set; }

		public NHibernateForm()
		{
			if (DesignMode)
				return;

			Session = Global.SessionFactory.OpenSession();
		}

		protected override void OnClosed(System.EventArgs e)
		{
			if (DesignMode)
				return;

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
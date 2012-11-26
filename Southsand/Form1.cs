using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Cfg;
using Southsand.Infrastructure;
using Southsand.Model;
using Environment = System.Environment;

namespace Southsand
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void SaveCustomerButton_Click(object sender, EventArgs e)
		{
			using (var session = Global.SessionFactory.OpenSession())
			using (var tx = session.BeginTransaction())
			{
				session.Save(new Customer
					{
						Name = "Oren",
						Birthday = new DateTime(1981,12,20)
					});
				tx.Commit();
			}
		}
	}
}

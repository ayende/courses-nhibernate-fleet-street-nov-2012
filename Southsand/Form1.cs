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
using Southsand.Forms;
using Southsand.Infrastructure;
using Southsand.Model;
using Environment = System.Environment;
using NHibernate.Linq;

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
				var homeAddress = session.Load<Address>(1);
				session.Save(new Customer
					{
						Name = "Oren",
						Birthday = new DateTime(1981, 12, 20),
						HomeAddress = homeAddress
					});
				tx.Commit();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			using (var session = Global.SessionFactory.OpenSession())
			{
				CustomersGrid.AutoGenerateColumns = true;
				CustomersGrid.DataSource = session.Query<Customer>().ToList();
			}
		}

		private void CustomersGrid_DoubleClick(object sender, EventArgs e)
		{
			var customerId = (long)CustomersGrid.SelectedRows[0].Cells[0].Value;
			using (var x = new CustomerEdit(customerId))
			{
				x.ShowDialog(this);
			}
		}
	}
}

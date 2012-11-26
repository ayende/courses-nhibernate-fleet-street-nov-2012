using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using Southsand.Infrastructure;
using Southsand.Model;
using NHibernate.Linq;

namespace Southsand.Forms
{
	public partial class CustomerEdit : NHibernateForm
	{
		public CustomerEdit(long id) : this()
		{
			var customer = (
				               from c in Session.Query<Customer>()
				               where c.Id == id
				               select new
					               {
						               c.Name,
						               c.Birthday,
						               c.HomeAddress.City
					               }
			               ).Single();

			textBox1.Text = customer.Name;
			dateTimePicker1.Value = customer.Birthday;
			label1.Text = customer.City;
		}

		public CustomerEdit()
		{
			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			//customer.Name = textBox1.Text;
			//customer.Birthday = dateTimePicker1.Value;

			Commit();
			Close();
		}
	}
}

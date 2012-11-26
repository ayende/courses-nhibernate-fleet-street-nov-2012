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

namespace Southsand.Forms
{
	public partial class CustomerEdit : NHibernateForm
	{
		private Customer customer;

		public CustomerEdit(long id) : this()
		{
			customer = Session.Get<Customer>(id);
			textBox1.Text = customer.Name;
			dateTimePicker1.Value = customer.Birthday;
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
			customer.Name = textBox1.Text;
			customer.Birthday = dateTimePicker1.Value;

			Commit();
			Close();
		}
	}
}

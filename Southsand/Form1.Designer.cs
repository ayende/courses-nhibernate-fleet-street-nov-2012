namespace Southsand
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SaveCustomerButton = new System.Windows.Forms.Button();
			this.CustomersGrid = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.CustomersGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// SaveCustomerButton
			// 
			this.SaveCustomerButton.Location = new System.Drawing.Point(12, 249);
			this.SaveCustomerButton.Name = "SaveCustomerButton";
			this.SaveCustomerButton.Size = new System.Drawing.Size(162, 23);
			this.SaveCustomerButton.TabIndex = 0;
			this.SaveCustomerButton.Text = "New Customer";
			this.SaveCustomerButton.UseVisualStyleBackColor = true;
			this.SaveCustomerButton.Click += new System.EventHandler(this.SaveCustomerButton_Click);
			// 
			// CustomersGrid
			// 
			this.CustomersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.CustomersGrid.Location = new System.Drawing.Point(27, 24);
			this.CustomersGrid.Name = "CustomersGrid";
			this.CustomersGrid.Size = new System.Drawing.Size(463, 150);
			this.CustomersGrid.TabIndex = 1;
			this.CustomersGrid.DoubleClick += new System.EventHandler(this.CustomersGrid_DoubleClick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 284);
			this.Controls.Add(this.CustomersGrid);
			this.Controls.Add(this.SaveCustomerButton);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.CustomersGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button SaveCustomerButton;
		private System.Windows.Forms.DataGridView CustomersGrid;
	}
}


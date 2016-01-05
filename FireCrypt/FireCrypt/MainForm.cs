
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FireCrypt.NewVolumeWizard;

namespace FireCrypt
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button2Click(object sender, EventArgs e)
		{
			MessageBox.Show("Are you sure you want to remove the selected item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void MainFormLoad(object sender, EventArgs e)
		{
	
		}
		void Label2Click(object sender, EventArgs e)
		{
	
		}
		void Button3Click(object sender, EventArgs e)
		{
			pictureBox1.Visible = true;
		}
		void Button1Click(object sender, EventArgs e)
		{
			new FireCrypt.Wizards.NewVolumeWizard().ShowDialog();
		}
	}
}


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
		FireCryptVolume currentVolume;
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
			var nvw = new FireCrypt.Wizards.NewVolumeWizard();
			nvw.ShowDialog();
			FireCryptVolume nv = nvw.FinalVolume;
			cryptList.Items.Add(new CryptListItem(nv));
		}
		void Button5Click(object sender, EventArgs e)
		{
			textBox1.Text = Clipboard.GetText();
		}
		void CryptListSelectedIndexChanged(object sender, EventArgs e)
		{
			CryptListItem listItem = (CryptListItem)cryptList.Items[cryptList.SelectedIndex];
			currentVolume = listItem.CryptVolume;
			label4.Text = currentVolume.Label;
		}
	}
	class CryptListItem
	{
		private FireCryptVolume _internalVolume;
		
		public FireCryptVolume CryptVolume
		{
			get
			{
				return _internalVolume;
			}
		}
		
		public CryptListItem(FireCryptVolume volume)
		{
			_internalVolume = volume;
		}
		
		public override string ToString()
		{
			return _internalVolume.Label;
		}
	}
}


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using OmniBean.PowerCrypt4;

namespace FireCrypt.NewVolumeWizard.UserControls
{
	/// <summary>
	/// Description of WelcomePage.
	/// </summary>
	public partial class WelcomePage : UserControl
	{
		public string VolumeName;
		public string Password;
		public WelcomePage()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void WelcomePageLoad(object sender, EventArgs e)
		{
	
		}
		void TextBox2PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			ValidateNextButton();
		}
		void TextBox3Leave(object sender, EventArgs e)
		{
			ValidateNextButton();
		}
		void TextBox3Validated(object sender, EventArgs e)
		{
			ValidateNextButton();
		}
		void TextBox3KeyUp(object sender, KeyEventArgs e)
		{
			ValidateNextButton();
		}
		void TextBox2KeyUp(object sender, KeyEventArgs e)
		{
			ValidateNextButton();
		}
		void NextBtnClick(object sender, EventArgs e)
		{
			VolumeName = textBox1.Text;
			bool rk = checkBox1.Checked;
			if (!rk)
			{
				Password = textBox2.Text;
			}
			if (rk)
			{
				Password = textBox4.Text;
			}
		}
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			bool rk = checkBox1.Checked;
			if (rk)
			{
				foreach (Control c in panel1.Controls)
				{
					c.Enabled = true;
				}
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				textBox3.Text = textBox2.Text = "";
				textBox4.Enabled = true;
				textBox4.Text = PowerAES.GenerateRandomString(1024);
				ValidateNextButton();
			}
			else
			{
				textBox2.Enabled = true;
				textBox3.Enabled = true;
				foreach (Control c in panel1.Controls)
				{
					c.Enabled = false;
				}
				textBox4.Text = "";
				checkBox1.Enabled = true;
				ValidateNextButton();
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			Clipboard.SetText(textBox4.Text);
		}
		void Button3Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "Key Files (*.key)|*.key|All files (*.*)|*.*"  ;
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				System.IO.File.WriteAllText(sfd.FileName, textBox4.Text);
			}
		}
		void ValidateNextButton()
		{
			bool rk = checkBox1.Checked;
			if (rk)
			{
				nextBtn.Enabled= textBox1.Text!="";
			}
			else
			{
				nextBtn.Enabled = (textBox2.Text==textBox3.Text)&&textBox1.Text!=""&&textBox2.Text!="";
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			textBox4.Text = PowerAES.GenerateRandomString(1024);
		}
		void TextBox1KeyUp(object sender, KeyEventArgs e)
		{
			ValidateNextButton();
		}
		
	}
}


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
			nextBtn.Enabled = textBox2.Text==textBox3.Text;
		}
		void TextBox3Leave(object sender, EventArgs e)
		{
			nextBtn.Enabled = textBox2.Text==textBox3.Text;
		}
		void TextBox3Validated(object sender, EventArgs e)
		{
			nextBtn.Enabled = textBox2.Text==textBox3.Text;
		}
		void TextBox3KeyUp(object sender, KeyEventArgs e)
		{
			nextBtn.Enabled = textBox2.Text==textBox3.Text;
		}
		void TextBox2KeyUp(object sender, KeyEventArgs e)
		{
			nextBtn.Enabled = textBox2.Text==textBox3.Text;
		}
		void NextBtnClick(object sender, EventArgs e)
		{
			VolumeName = textBox1.Text;
			Password = textBox2.Text;
		}
	}
}

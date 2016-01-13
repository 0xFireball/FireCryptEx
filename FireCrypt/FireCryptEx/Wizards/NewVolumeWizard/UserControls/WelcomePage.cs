/*
 * THIS PROGRAM AND ITS SOURCE CODE ARE PROVIDED TO YOU FREE OF CHARGE.
 * YOU ARE PROHIBITED FROM REMOVING THIS NOTICE FROM THIS SOURCE DOCUMENT
 * OR OTHERWISE MODIFYING IT.
 * 
 * FireCryptEx is a free (and by now, open-source) program that allows
 * the user to create encrypted volumes to store files.
 * 
 * FireCryptEx was and continues to be developed by 0xFireball, and is
 * the successor to another free program, FireCrypt.
 * 
 * About the Author:
 * Pseudonym: 0xFireball, ExaPhaser
 * Websites:
 * http://acetylene.x10.bz
 * http://omnibean.x10.bz
 * http://exaphaser.x10.bz
 * 
 * Contact:
 * 0xFireball on GitHub
 * 0xFireball on GitLab
 * exaphaser on GitLab
 * 
 * omnibean@outlook.com
 * 
 *   
 * You are hereby allowed to make changes to the below source code and
 * improve this program. In doing so, you are bound by the terms and 
 * conditions of the AGPLv3 License.
 * 
 */


using System;
using System.Collections.Generic;
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
		public string VolumeVersion;
		
		List<string> volumeVersions = new List<string>{"1.0","1.0+"};
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
			//comboBox1.Enabled = !MainForm.isTrial;
			comboBox1.Items.AddRange(volumeVersions.ToArray());
			comboBox1.SelectedIndex=0;
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
			try
			{
				VolumeVersion = volumeVersions[comboBox1.SelectedIndex];
			}
			catch
			{
				VolumeVersion="1.0";
			}
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
		bool react = true;
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			react = !react;
			if (MainForm.licenseLevel<=1&&react)
			{
				MessageBox.Show("Creating more advanced volumes requires a full license.");
				comboBox1.SelectedIndex=0;
			}
		}
		
	}
}

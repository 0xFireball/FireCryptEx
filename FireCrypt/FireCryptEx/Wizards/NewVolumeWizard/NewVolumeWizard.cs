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
using System.Drawing;
using System.Windows.Forms;
using FireCrypt.NewVolumeWizard.UserControls;
using MetroFramework.Forms;

namespace FireCrypt.Wizards
{
	/// <summary>
	/// Description of NewVolumeWizard.
	/// </summary>
	public partial class NewVolumeWizard : MetroForm
	{
		bool existingVolume;
		public NewVolumeWizard(bool existing)
		{
			existingVolume=existing;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		private void ShowContent(Control content)
		{
		    panel1.Controls.Clear(); // clear current content
		    panel1.Controls.Add(content); // add new
		    content.Dock = DockStyle.Fill; // fill placeholder area
		}
		void NewVolumeWizardLoad(object sender, EventArgs e1)
		{
			if (!existingVolume)
			{
				WelcomePage wp = new WelcomePage();
				ShowContent(wp);
				panel1.Controls.Find("nextBtn", true)[0].Click += (s,e)=> OnNextPage1Click(sender, e1, wp);
			}
			else
			{
				VolumeLocation vlp = new VolumeLocation(VolumeName, Password, VolumeVersion);
				ShowContent(vlp);
				panel1.Controls.Find("finishBtn", true)[0].Click += (s,e)=> OnNextPage2Click(sender, e1, vlp);
				panel1.Controls.Find("button2", true)[0].Visible = false;
				panel1.Controls.Find("label2", true)[0].Visible = false;
			}
		}
		string VolumeName;
		string Password;
		string VolumeVersion;
		void OnNextPage1Click(object sender, EventArgs e1, WelcomePage wp)
		{
			VolumeName = wp.VolumeName;
			Password = wp.Password;
			VolumeVersion = wp.VolumeVersion;
			VolumeLocation vlp = new VolumeLocation(VolumeName, Password, VolumeVersion);
			ShowContent(vlp);
			panel1.Controls.Find("finishBtn", true)[0].Click += (s,e)=> OnNextPage2Click(sender, e1, vlp);
		}
		public FireCryptVolume FinalVolume;
		void OnNextPage2Click(object sender, EventArgs e1, VolumeLocation vlp)
		{
			FireCryptVolume fcv = vlp.FinalVolume;
			this.FinalVolume = fcv;
			this.Close();
		}
		
	}
}

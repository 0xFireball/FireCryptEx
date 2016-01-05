﻿
using System;
using System.Drawing;
using System.Windows.Forms;
using FireCrypt.NewVolumeWizard.UserControls;

namespace FireCrypt.Wizards
{
	/// <summary>
	/// Description of NewVolumeWizard.
	/// </summary>
	public partial class NewVolumeWizard : Form
	{
		public NewVolumeWizard()
		{
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
			WelcomePage wp = new WelcomePage();
			ShowContent(wp);
			panel1.Controls.Find("nextBtn", true)[0].Click += (s,e)=> OnNextPage1Click(sender, e1, wp);
		}
		string VolumeName;
		string Password;
		void OnNextPage1Click(object sender, EventArgs e, WelcomePage wp)
		{
			VolumeName = wp.VolumeName;
			Password = wp.Password;
			VolumeLocation vlp = new VolumeLocation();
			ShowContent(vlp);
		}
	}
}

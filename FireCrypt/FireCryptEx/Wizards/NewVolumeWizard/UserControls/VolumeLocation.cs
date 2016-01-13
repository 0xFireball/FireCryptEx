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
 * /



using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace FireCrypt.NewVolumeWizard.UserControls
{
	/// <summary>
	/// Description of VolumeLocation.
	/// </summary>
	public partial class VolumeLocation : UserControl
	{
		public string VolumeFileLocation;
		bool ValidVolume;
		string VolumeName;
		string Password;
		string VolumeVersion;
		
		public FireCryptVolume FinalVolume;
		
		public VolumeLocation(string volumeName, string password, string volumeVersion)
		{
			VolumeName = volumeName;
			Password = password;
			VolumeVersion = volumeVersion;
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
			//create new
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "FireCrypt Volumes (*.FireCrypt)|*.FireCrypt|All files (*.*)|*.*"  ;
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				VolumeFileLocation = sfd.FileName;
				label4.Text = VolumeFileLocation;
				string fnwoext = Path.GetFileNameWithoutExtension(VolumeFileLocation); //filenamewithout extension
				string volN = Path.GetDirectoryName(VolumeFileLocation)+"\\"+fnwoext+".vault\\"+fnwoext+".FireCrypt";
				FireCryptVolume.CreateNewVolume(VolumeFileLocation, VolumeName, Password, VolumeVersion);
				//dont change it before createvolume because it uses the older standard.
				VolumeFileLocation = volN; //point it to the actual .FireCrypt file.
				try
				{
					FireCryptVolume fcv  = new FireCryptVolume(VolumeFileLocation);
					ValidVolume = true;
					finishBtn.Enabled = ValidVolume;
					FinalVolume = fcv;
				}
				catch
				{
					ValidVolume = false;
					finishBtn.Enabled = ValidVolume;
					MessageBox.Show("Volume creation error.");
				}
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			//Choose existing
			OpenFileDialog sfd = new OpenFileDialog();
			sfd.Multiselect = false;
			sfd.Filter = "FireCrypt Volumes (*.FireCrypt)|*.FireCrypt|All files (*.*)|*.*"  ;
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				string tvfl = sfd.FileName; //test volume file location
				VolumeFileLocation = tvfl;
				if (tvfl.EndsWith(".FireCrypt"))
				{
					tvfl = Path.GetDirectoryName(tvfl);
				}
				string vaultLoc = tvfl;
				label4.Text = VolumeFileLocation;
				try
				{
					FireCryptVolume fcv  = new FireCryptVolume(VolumeFileLocation);
					ValidVolume = true;
					finishBtn.Enabled = ValidVolume;
					FinalVolume = fcv;
				}
				catch
				{
					ValidVolume = false;
					finishBtn.Enabled = ValidVolume;
					MessageBox.Show("Invalid Volume selected.");
				}
			}
		}
		void FinishBtnClick(object sender, EventArgs e)
		{
			
		}
	}
}

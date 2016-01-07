
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
		
		public FireCryptVolume FinalVolume;
		
		public VolumeLocation(string volumeName, string password)
		{
			VolumeName = volumeName;
			Password = password;
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
				FireCryptVolume.CreateNewVolume(VolumeFileLocation, VolumeName, Password);
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
				if (tvfl.EndsWith(".FireCrypt"))
				{
					tvfl = Path.GetDirectoryName(tvfl);
				}
				VolumeFileLocation = tvfl;
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


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
		public VolumeLocation()
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
			//create new
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "FireCrypt Volumes (*.firecrypt)|*.firecrypt|All files (*.*)|*.*"  ;
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				VolumeFileLocation = sfd.FileName;
				label4.Text = VolumeFileLocation;
				string fnwoext = Path.GetFileNameWithoutExtension(VolumeFileLocation); //filenamewithout extension
				string volN = Path.GetDirectoryName(VolumeFileLocation)+"\\"+fnwoext+".vault\\"+fnwoext+".firecrypt";
				Directory.CreateDirectory(Path.GetDirectoryName(volN));
				
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			//Choose existing
			OpenFileDialog sfd = new OpenFileDialog();
			sfd.Multiselect = false;
			sfd.Filter = "FireCrypt Volumes (*.firecrypt)|*.firecrypt|All files (*.*)|*.*"  ;
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				VolumeFileLocation = sfd.FileName;
				label4.Text = VolumeFileLocation;
			}
		}
	}
}

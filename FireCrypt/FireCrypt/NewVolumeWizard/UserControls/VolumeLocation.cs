
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "FireCrypt Volumes (*.firecrypt)|*.firecrypt|All files (*.*)|*.*"  ;
		}
	}
}

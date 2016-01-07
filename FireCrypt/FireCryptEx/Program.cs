
using System;
using System.Windows.Forms;

namespace FireCrypt
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			if (Properties.Settings.Default.UpgradeRequired)
			{
			  Properties.Settings.Default.Upgrade();
			  Properties.Settings.Default.UpgradeRequired = false;
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}

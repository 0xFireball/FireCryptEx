
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Xml;

using Portable.Licensing;
using Portable.Licensing.Validation;

using MetroFramework.Forms;

namespace FireCrypt
{
	/// <summary>
	/// Description of RegistrationForm.
	/// </summary>
	public partial class RegistrationForm : MetroForm
	{
		public RegistrationForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		static bool TryParseXml(string xml){
		    try{
				new XmlDocument().LoadXml(xml);
		      return true;
		    }catch(XmlException e){
		      return false;
			}
	    }
		public static bool VerifyLicense()
		{
			if (!TryParseXml(Properties.Settings.Default.License))
				Properties.Settings.Default.License = "<License>NoLicense</License>";
			string publicKey = "MIIBKjCB4wYHKoZIzj0CATCB1wIBATAsBgcqhkjOPQEBAiEA/////wAAAAEAAAAAAAAAAAAAAAD///////////////8wWwQg/////wAAAAEAAAAAAAAAAAAAAAD///////////////wEIFrGNdiqOpPns+u9VXaYhrxlHQawzFOw9jvOPD4n0mBLAxUAxJ02CIbnBJNqZnjhE50mt4GffpAEIQNrF9Hy4SxCR/i85uVjpEDydwN9gS3rM6D0oTlF2JjClgIhAP////8AAAAA//////////+85vqtpxeehPO5ysL8YyVRAgEBA0IABIgqEwj4QDKhmA8wF8dpkgAp6cSS21eqzjpY0AsdvpLftjUi6M/OG5trUjZCmzhx/M1UxVnanhN/NI6t+4p7R7Y=";
			var license = License.Load(Properties.Settings.Default.License);
			var validationFailures = license.Validate()  
                                .ExpirationDate()  
                                    .When(lic => lic.Type == LicenseType.Trial)  
                                .And()  
                                .Signature(publicKey)
                                .AssertValidLicense();
			if (validationFailures.ToList().Any())
			{
				foreach (var failure in validationFailures)
					     MessageBox.Show(failure.GetType().Name + ": " + failure.Message + " - " + failure.HowToResolve);
				//new RegistrationForm().ShowDialog();
				MessageBox.Show("Your license is invalid or has expired. Please select a new license.");
				return false;
			}
			return true;
		}
		void RegistrationFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!VerifyLicense())
			{
				e.Cancel = true;
				this.Hide();
				this.Show();
				this.WindowState = FormWindowState.Minimized;
				this.WindowState = FormWindowState.Normal;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			OpenFileDialog theDialog = new OpenFileDialog();
		    theDialog.Title = "Select License File";
		    theDialog.Multiselect = false;
		    theDialog.Filter = "0xFireball Licenses|*.licx";
		    theDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		    if (theDialog.ShowDialog() == DialogResult.OK)
		    {
		    	string filename = theDialog.FileName;
		    	string zlicense = File.ReadAllText(filename);
		    	Properties.Settings.Default.License = zlicense;
				if (VerifyLicense())
				{
					MessageBox.Show("License Verification Successful! You can now close this window and use FireCryptEx!");
					Properties.Settings.Default.License = "<L>UNveRIFY!!!!!</L>"; //remove this later
				}
				else
				{
					
				}
		    }
		}
		
	}
}

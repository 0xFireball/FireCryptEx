
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
		/// <summary>
		/// Access Level to program
		/// 0: Demo mode
		/// 1: Trial mode
		/// 8: Normal mode
		/// </summary>
		public static int accessLevel = -1;
		public static License userLicense;
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
			userLicense = license;
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
				if (accessLevel<0)
					MessageBox.Show("Your license is invalid, nonexistent, or has expired. Please select a new license, or enter the limited demo mode.","FireCryptEx");
				return false;
			}
			accessLevel = 2;//pending update
			return true;
		}
		void RegistrationFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!VerifyLicense()&&accessLevel<0)
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
		    //theDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		    if (theDialog.ShowDialog() == DialogResult.OK)
		    {
		    	string filename = theDialog.FileName;
		    	string zlicense = File.ReadAllText(filename);
		    	Properties.Settings.Default.License = zlicense;
				if (VerifyLicense())
				{
					//MessageBox.Show("License Verification Successful! You can now close this window and use FireCryptEx!");
					License l = License.Load(zlicense);
					string name = l.Customer.Name;
					int days = (int)(l.Expiration - DateTime.Now).TotalDays;
					string wMsg = string.Format("Welcome {0}, and thanks for using FireCryptEx. ",name);
					if (l.Type==LicenseType.Trial)
					{
						accessLevel=1;
						wMsg += string.Format("You have {0} days remaining on your trial license. You can now close this window and continue to the program. FireCryptEx will remember your license details.",days);
					}
					else
					{
						accessLevel=8;
						wMsg += string.Format("Thank you for purchasing your full license of FireCryptEx! You can now close this window and continue to the program. FireCryptEx will remember your license details.");
					}
					label1.Text = wMsg;
					button1.Visible = false;
					button2.Visible = false;
					button3.Visible = false;
					//Properties.Settings.Default.License = "<L>UNveRIFY!!!!!</L>"; //remove this later
				}
				else
				{
					
				}
		    }
		}
		void Button2Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		void Button3Click(object sender, EventArgs e)
		{
			MessageBox.Show("You are about to enter demo mode. Most features will be locked until you obtain a free trial license or purchase a full license.");
			accessLevel=0;
			string wMsg = string.Format("Welcome, and thanks for using FireCryptEx. ");
			wMsg += string.Format("Demo mode has been activated. Most features are locked, and you cannot create new volumes. Upgrade to a free trial license to do much, much more with FireCryptEx.");
			label1.Text = wMsg;
			button1.Visible = false;
			button2.Visible = false;
			button3.Visible = false;
		}
		
	}
}

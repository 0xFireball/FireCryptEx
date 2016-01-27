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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Security.Cryptography;

using EPFramework.Forms;
using MetroFramework.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


using FireCrypt.Network;
using FireCrypt.NewVolumeWizard;

using PluginInterface;
using Aluminum.PluginCore2.Types;
using Aluminum.PluginCore2;

namespace FireCrypt
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : MetroForm, IPluginHost
	{
		FireCryptVolume currentVolume;
		List<string> CryptListItemLocations;
		Process browserProcess;
		public MainForm()
		{
			CryptListItemLocations = new List<string>();
			Form.CheckForIllegalCrossThreadCalls = false;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            PreparePlugins();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        void PreparePlugins()
        {
            SuspendLayout();
            //Call the find plugins routine, to search in our Plugins Folder
            Global.Plugins.FindPluginsByPath(Application.StartupPath + @"\Plugins");
            Global.Plugins.FindPluginsBySuffix(Application.StartupPath, ".Plugin.dll");

            var availablePlugins = Global.Plugins.AvailablePlugins;
            //Add each plugin to the treeview
            foreach (AvailablePlugin plugin in availablePlugins)
            {
                var pluginBtn = new ToolStripMenuItem(plugin.Instance.Name);
                plugin.Instance.Host = this;
                plugin.Instance.HostObject = this;
                pluginBtn.Click += (sender, e) => plugin.Instance.InvokePlugin();
                pluginListStrip.Items.Add(pluginBtn);
            }
            if (availablePlugins.Count == 0)
            {
                button7.Visible = false;
            }
            ResumeLayout();
        }
        async void Button2Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Are you sure you want to remove the selected item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (dr == DialogResult.Yes)
			{
				await Task.Run(()=>RemoveCryptBox());
			}
		}
		void RemoveCryptBox()
		{
			try
			{
				cryptList.Items.RemoveAt(cryptList.SelectedIndex);
			}
			catch
			{}
			SaveCryptList();
			
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		Portable.Licensing.License uLicense = RegistrationForm.userLicense;
		public static int licenseLevel=RegistrationForm.accessLevel;
		static int maxVaults = licenseLevel<8?1:999999;
		void ApplyRestrictions()
		{
			if (licenseLevel<8)
			{
				label6.Visible=true;
			}
			if (RegistrationForm.accessLevel==2)
			{
				if(RegistrationForm.userLicense.Type==Portable.Licensing.LicenseType.Trial) licenseLevel=1;
				if(RegistrationForm.userLicense.Type==Portable.Licensing.LicenseType.Standard) licenseLevel=8;
			}
			label6.Text="";
			if(licenseLevel==1)label6.Text= String.Format("TRIAL: {0} DAYS REMAINING.", (int)(RegistrationForm.userLicense.Expiration - DateTime.Now).TotalDays);
			if(licenseLevel==0)label6.Text="DEMO MODE [UPGRADE]";
			if (licenseLevel==1) {
				maxVaults = int.Parse(uLicense.ProductFeatures.Get("MaxVolumes"));
			}
		}
		
		void MainFormLoad(object sender, EventArgs e1)
		{
            
			//if its not free, enforce some limits.
			if (!RegistrationForm.isFreeSoftware)
			{
				//save license
				Properties.Settings.Default.License = RegistrationForm.userLicense.ToString();
				//trial info
				ApplyRestrictions();
			}
			else
			{
				//if it IS free, remove licensing related stuff.
				button6.Visible=false;
			}
			
			
			//automatic versioning
			label1.Text = string.Format("Version {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
			//Properties.Settings.Default.Reload();
			string volListJ = Properties.Settings.Default.VolumeList;
			//panel1.BackColor = Color.FromArgb(255, Color.Transparent);
			try
			{
				CryptListItemLocations = JsonConvert.DeserializeObject<List<string>>(volListJ);
				foreach (string cli in CryptListItemLocations)
				{
					cryptList.Items.Add(new CryptListItem(new FireCryptVolume(cli)));
				}
			}
			catch (Exception e)
			{
				
			}
			SaveCryptList();
		}
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		async void Button3Click(object sender, EventArgs e)
		{
			try
			{
				if (!currentVolume.Unlocked)
				{
					label5.Text = "Unlocking...";
					await Task.Run(()=>TryUnlockVolume());
					//TryUnlockVolume();
				}
				else
				{
					label5.Text = "Locking...";
					await Task.Run(()=>TryLockVolume());
					//TryLockVolume();
				}
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Please select a volume.");
			}
		}
		List<char> GetFreeDriveLetters()
		{
			List<char> driveLetters = new List<char>(); // Allocate space for alphabet
			for (int i = 65; i < 91; i++) // increment from ASCII values for A-Z
			{
			   driveLetters.Add(Convert.ToChar(i)); // Add uppercase letters to possible drive letters
			}
			
			foreach (string drive in Directory.GetLogicalDrives())
			{
			   driveLetters.Remove(drive[0]); // removed used drive letters from possible drive letters
			}
			
			return driveLetters;
		}
		void TryLockVolume()
		{
			try
			{
				string pass = textBox1.Text;
				try
				{
					if (browserProcess!=null)
						if (!browserProcess.HasExited) browserProcess.Kill();
					if (currentVolume.NetworkDriveMap != null)
						currentVolume.NetworkDriveMap.UnMapDrive();
				}
				catch (System.ComponentModel.Win32Exception)
				{
					MessageBox.Show("Could not unmap drive. You can do this manually by right-clicking the drive in Explorer and selecting 'Disconnect'.");
				}
				currentVolume.NetworkDriveMap = null;
				currentVolume.LockVolume(pass);
				label5.Text = "Successfully Locked.";
				UpdateCurrentItem();
			}
            catch (IOException ioe)
            {
                MessageBox.Show("Please close all Explorer windows before locking volume.");
                label5.Text = "Successfully Locked.";
                UpdateCurrentItem();
            }
			catch (Exception e)
			{
				label5.Text = "Drive lock error.";
				MessageBox.Show(e.ToString());
			}
		}
		void TryUnlockVolume()
		{
			//pictureBox1.Visible = true;
			try
			{
				string pass = textBox1.Text;
				currentVolume.UnlockVolume(pass);
				label5.Text = "Successfully Unlocked.";
				if (checkBox1.Checked && IsMicrosoftCLR())
				{
					currentVolume.NetworkDriveMap = new NetworkDrive();
					currentVolume.NetworkDriveMap.ShareName = NetworkDrive.ConvertToUNCPath(currentVolume.UnlockPath);
					//string mdl = GetFreeDriveLetters()[0]+":"; //map drive letter
					string mdl = freeDriveLetters[comboBox1.SelectedIndex]+":"; //map drive letter
					currentVolume.NetworkDriveMap.LocalDrive = mdl;
					try
					{
						currentVolume.NetworkDriveMap.MapDrive();
						browserProcess = Process.Start(mdl);
					}
					catch (System.ComponentModel.Win32Exception w3e)
					{
						MessageBox.Show(w3e.ToString());
					}
				}
				else
				{
					if (!IsMicrosoftCLR()&&checkBox1.Checked)
					{
						MessageBox.Show("This operation is not supported on your platform.");
					}
                    if (IsMicrosoftCLR())
					    browserProcess = Process.Start("explorer.exe",currentVolume.UnlockPath);
                    else
                        browserProcess = Process.Start(currentVolume.UnlockPath);
                }
			}
			catch (System.Reflection.TargetInvocationException ex)
			{
				try
				{
					throw ex.InnerException;
				}
				catch (NullReferenceException)
				{
					MessageBox.Show("Please select a volume.");
				}
			}
			catch (System.IO.InvalidDataException)
			{
				label5.Text = "Incorrect Password.";
			}
			catch (CryptographicException ce)
			{
				label5.Text = "Incorrect Password.";
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				label5.Text = "Unknown Decryption Error. Check your password.";
			}
			//pictureBox1.Visible = false;
			UpdateCurrentItem();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (licenseLevel<=1)
			{
				int currentV = cryptList.Items.Count;
				if (currentV >= maxVaults)
				{
					MessageBox.Show("You have reached the maximum number of vaults allowed by your license. Upgrade your license to add more vaults.");
					return;
				}
			}
			Button btnSender = (Button)sender;
		    Point ptLowerLeft = new Point(0, btnSender.Height);
		    ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);           
		    newOrExistingCtxM.Show(ptLowerLeft);
			
		}
		void SaveCryptList()
		{
			CryptListItemLocations = new List<string>();
			foreach (CryptListItem cli in cryptList.Items)
			{
				CryptListItemLocations.Add(cli.CryptVolume.RawLocation);
			}
			Properties.Settings.Default.VolumeList = JsonConvert.SerializeObject(CryptListItemLocations);
			Properties.Settings.Default.Save();
		}
		void Button5Click(object sender, EventArgs e)
		{
			textBox1.Text = Clipboard.GetText();
		}
		void CryptListSelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				UpdateCurrentItem();
			}
			catch (ArgumentOutOfRangeException)
			{
				
			}
		}
		void UpdateCurrentItem()
		{
			CryptListItem listItem = (CryptListItem)cryptList.Items[cryptList.SelectedIndex];
			currentVolume = listItem.CryptVolume;
			label4.Text = string.Format("{0} [{1}]", currentVolume.Label, currentVolume.VolumeVersion);
			button3.Text = currentVolume.Unlocked ? "Lock Vault" : "Unlock Vault";
			if (currentVolume.Unlocked)
			{
				
			}
			else
			{
				
			}
		}
		bool forceClose = false;
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			SaveCryptList();
			e.Cancel = !forceClose;
			forceClose = false;
			this.Hide();
			if (e.Cancel)
			{
				//notifyIcon1.ShowBalloonTip(5000, "FireCryptEx", "FireCryptEx is still running. Exit by right-clicking the icon, but first ensure that all vaults are locked.", ToolTipIcon.Info);
			}
            else
            {
                Global.Plugins.ClosePlugins();
            }
		}
		void Button4Click(object sender, EventArgs e)
		{
			OpenFileDialog sfd = new OpenFileDialog();
			sfd.Multiselect = false;
			sfd.Filter = "Key Files (*.key)|*.key|All files (*.*)|*.*"  ;
			DialogResult dr = sfd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				string key = System.IO.File.ReadAllText(sfd.FileName);
				textBox1.Text = key;
			}
		}
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveCryptList();
			forceClose = true;
			Application.Exit();
		}
		void NotifyIcon1MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
		}
		void NotifyIcon1BalloonTipClicked(object sender, EventArgs e)
		{
			//this.Show();
		}
		static bool IsMicrosoftCLR()
		{
			return (Type.GetType ("Mono.Runtime") == null);
		}
		List<string> freeDriveLetters = new List<string>();
		bool react=true;
		void CheckBox1CheckedChanged(object sender, EventArgs e)
		{
			if (licenseLevel<=1)
			{
				checkBox1.Checked = false;
				if (react)
					MessageBox.Show("This feature is only available in the full version of FireCryptEx.");
				react=!react;
				return;
			}
			comboBox1.Enabled = checkBox1.Enabled;
			if (comboBox1.Enabled)
			{
				freeDriveLetters = GetFreeDriveLetters().Select(c => c.ToString()).ToList();
				comboBox1.Items.AddRange(freeDriveLetters.ToArray());
			}
		}
		void AddNew()
		{
			if (licenseLevel<1)
			{
				MessageBox.Show("Demo licenses cannot create vaults. Upgrade to a trial or full license.");
				return;
			}
			var nvw = new FireCrypt.Wizards.NewVolumeWizard(false);
			nvw.ShowDialog();
			if (nvw.FinalVolume!=null)
			{
				FireCryptVolume nv = nvw.FinalVolume;
				cryptList.Items.Add(new CryptListItem(nv));
				SaveCryptList();
			}
		}
		void AddExisting()
		{
			var nvw = new FireCrypt.Wizards.NewVolumeWizard(true);
			nvw.ShowDialog();
			if (nvw.FinalVolume!=null)
			{
				FireCryptVolume nv = nvw.FinalVolume;
				cryptList.Items.Add(new CryptListItem(nv));
				SaveCryptList();
			}
		}
		
		void AddNewToolStripMenuItemClick(object sender, EventArgs e)
		{
			AddNew();
		}
		void AddExistingToolStripMenuItemClick(object sender, EventArgs e)
		{
			AddExisting();
		}
		void Button6Click(object sender, EventArgs e)
		{
			DialogResult dr = MessageBox.Show("Are you sure you want to remove your license (You can always add it back)?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (dr == DialogResult.Yes)
			{
				Properties.Settings.Default.License="<l>N</l>";
				MessageBox.Show("Your license has been removed. Restart the application to apply changes.");
			}
		}
		void AddNewToolStripMenuItem1Click(object sender, EventArgs e)
		{
			AddNew();
		}
		void AddExistingToolStripMenuItem1Click(object sender, EventArgs e)
		{
			AddExisting();
		}
		void AboutToolStripMenuItem1Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}
		void FreeVersionToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/0xFireball/FireCrypt");
		}
		void MetroMenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
	
		}
		void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
	
		}
		void ExportToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (licenseLevel<8)
			{
				MessageBox.Show("This feature is only available in the full version of FireCryptEx. Please purchase a full license to use this feature.");
				return;
			}
			ExportFromCryptList();
		}
		void ExportFromCryptList()
		{
			
		}
		void MetroMenuStrip1DoubleClick(object sender, EventArgs e)
		{
			//metroMenuStrip1.Visible = false;
		}
		void MetroMenuStrip1MouseHover(object sender, EventArgs e)
		{
			//metroMenuStrip1.Visible = true;
		}
		void MetroMenuStrip1MouseLeave(object sender, EventArgs e)
		{
			//metroMenuStrip1.Visible = false;
		}

        private void metroMenuStrip1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            pluginListStrip.Show(ptLowerLeft);
        }
    }
    class CryptListItem
	{
		private FireCryptVolume _internalVolume;
		
		public FireCryptVolume CryptVolume
		{
			get
			{
				return _internalVolume;
			}
		}
		
		public CryptListItem(FireCryptVolume volume)
		{
			_internalVolume = volume;
		}
		
		public override string ToString()
		{
			return _internalVolume.Label;
		}
	}
}

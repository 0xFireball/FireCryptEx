
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Security.Cryptography;


using FireCrypt.NewVolumeWizard;


namespace FireCrypt
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		FireCryptVolume currentVolume;
		List<string> CryptListItemLocations;
		public MainForm()
		{
			CryptListItemLocations = new List<string>();
			Form.CheckForIllegalCrossThreadCalls = false;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
		
		void MainFormLoad(object sender, EventArgs e1)
		{
			//automatic versioning
			label1.Text = string.Format("Version {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
			//Properties.Settings.Default.Reload();
			string volListJ = Properties.Settings.Default.VolumeList;
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
			if (!currentVolume.Unlocked)
			{
				await Task.Run(()=>TryUnlockVolume());
				//TryUnlockVolume();
			}
			else
			{
				await Task.Run(()=>TryLockVolume());
				//TryLockVolume();
			}
		}
		void TryLockVolume()
		{
			string pass = textBox1.Text;
			currentVolume.LockVolume(pass);
			label5.Text = "Successfully Locked.";
			UpdateCurrentItem();
		}
		void TryUnlockVolume()
		{
			//pictureBox1.Visible = true;
			try
			{
				string pass = textBox1.Text;
				currentVolume.UnlockVolume(pass);
				label5.Text = "Successfully Unlocked.";
				System.Diagnostics.Process.Start(currentVolume.UnlockPath);
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Please select a volume.");
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
			var nvw = new FireCrypt.Wizards.NewVolumeWizard();
			nvw.ShowDialog();
			if (nvw.FinalVolume!=null)
			{
				FireCryptVolume nv = nvw.FinalVolume;
				cryptList.Items.Add(new CryptListItem(nv));
				SaveCryptList();
			}
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
			label4.Text = currentVolume.Label;
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
			notifyIcon1.ShowBalloonTip(5000, "FireCrypt", "FireCrypt is still running. Exit by right-clicking the icon, but first ensure that all vaults are locked.", ToolTipIcon.Info);
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

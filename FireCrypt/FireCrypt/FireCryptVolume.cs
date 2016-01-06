/*
 */
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.IO.Compression;

using SharpWipe;

using OmniBean.PowerCrypt4;

namespace FireCrypt
{
	static class ByteConverter
	{
		public static byte[] GetBytes(this string str)
		{
		    byte[] bytes = new byte[str.Length * sizeof(char)];
		    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
		    return bytes;
		}
		
		public static string GetString(this byte[] bytes)
		{
		    char[] chars = new char[bytes.Length / sizeof(char)];
		    System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
		    return new string(chars);
		}
	}
	/// <summary>
	/// FireCryptVolume.
	/// </summary>
	public class FireCryptVolume
	{
		public string RawLocation;
		public string VaultLocation;
		public string VolumeLocation;
		public string OpenVaultLocation;
		public string UID;
		public string Label;		
		
		Dictionary<string,string> MetadataValues = new Dictionary<string, string>();
		bool _unlocked;
		string _metadata;
		string _unlockPath;
		
		private static string UnlockLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\FireCrypt\\";
		
		public bool Unlocked
		{
			get
			{
				return _unlocked;
			}
		}
		
		public string UnlockPath
		{
			get
			{
				return _unlockPath;
			}
		}
		
		public static void CreateNewVolume(string location, string label, string password)
		{
			string fnwoext = Path.GetFileNameWithoutExtension(location); //filenamewithout extension
			string volN = Path.GetDirectoryName(location)+"\\"+fnwoext+".vault\\"+fnwoext+".firecrypt";
			string vaultL = Path.GetDirectoryName(volN);
			Directory.CreateDirectory(Path.GetDirectoryName(volN));
			string vid = Guid.NewGuid().ToString();
			Dictionary<string,string> volMeta = new Dictionary<string,string>();
			volMeta["UID"] = vid;
			volMeta["Label"] = label;
			string ed = Path.GetTempPath()+"\\"+Guid.NewGuid();
			Directory.CreateDirectory(ed);
			string unlLoc = ed;
			string DecVolumeLocation = unlLoc+".dec";
			ZipFile.CreateFromDirectory(unlLoc, DecVolumeLocation);
			string dVolume = File.ReadAllBytes(DecVolumeLocation).GetString();
			File.WriteAllBytes(volN, PowerAES.Encrypt(dVolume, password).GetBytes());
			string metaS = new JavaScriptSerializer().Serialize(volMeta);
			File.WriteAllText(vaultL+"\\vault.metadata",metaS);
		}
		
		
		public void UnlockVolume(string key)
		{
			string eVolume = File.ReadAllBytes(VolumeLocation).GetString();
			string unlockName = UnlockLocation+UID;
			string DecVolumeLocation = unlockName+".dec";
			if (!Directory.Exists(UnlockLocation))
			{
				Directory.CreateDirectory(UnlockLocation);
			}
			File.WriteAllBytes(DecVolumeLocation, PowerAES.Decrypt(eVolume,key).GetBytes());
			ZipFile.ExtractToDirectory(DecVolumeLocation, unlockName);
			FileWiper fw = new FileWiper();	
			fw.PassInfoEvent += (e) => {};
			fw.SectorInfoEvent += (e) => {};
            fw.WipeDoneEvent += (e) => {};
            fw.WipeErrorEvent += (e) => {};
			fw.WipeFile(DecVolumeLocation, 1);
			_unlocked = true;
			_unlockPath = unlockName;
		}
		
		public void LockVolume(string key)
		{
			string unlockName = UnlockLocation+UID;
			string DecVolumeLocation = unlockName+".dec";
			ZipFile.CreateFromDirectory(unlockName, DecVolumeLocation);
			string dVolume = File.ReadAllBytes(DecVolumeLocation).GetString();
			FileWiper fw = new FileWiper();
			fw.WipeFile(DecVolumeLocation, 1);
			File.WriteAllBytes(VolumeLocation, PowerAES.Encrypt(dVolume, key).GetBytes());
			_unlocked = false;
			_unlockPath = null;
		}
		
		public FireCryptVolume(string location)
		{
			RawLocation = location;
			string fnwoext = Path.GetFileNameWithoutExtension(RawLocation); //filenamewithout extension
			string volN = Path.GetDirectoryName(RawLocation)+"\\"+fnwoext+".vault\\"+fnwoext+".firecrypt";
			VolumeLocation = volN;
			VaultLocation = Path.GetDirectoryName(volN);
			_unlocked = Directory.Exists(OpenVaultLocation);
			_metadata = File.ReadAllText(VaultLocation+"\\vault.metadata");
			var jss = new JavaScriptSerializer();
			MetadataValues = jss.Deserialize<Dictionary<string,string>>(_metadata);
			UID = MetadataValues["UID"];
			Label = MetadataValues["Label"];
		}
		
		public FireCryptVolume()
		{
			string fnwoext = Path.GetFileNameWithoutExtension(RawLocation); //filenamewithout extension
			string volN = Path.GetDirectoryName(RawLocation)+"\\"+fnwoext+".vault\\"+fnwoext+".firecrypt";
			VolumeLocation = volN;
			VaultLocation = Path.GetDirectoryName(volN);
			_unlocked = Directory.Exists(OpenVaultLocation);
			_metadata = File.ReadAllText(VaultLocation+"\\vault.metadata");
			var jss = new JavaScriptSerializer();
			MetadataValues = jss.Deserialize<Dictionary<string,string>>(_metadata);
			UID = MetadataValues["UID"];
			Label = MetadataValues["Label"];
		}
		
	}
}

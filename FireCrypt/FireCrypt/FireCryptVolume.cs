/*
 */
using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace FireCrypt
{
	/// <summary>
	/// Description of FireCryptVolume.
	/// </summary>
	public class FireCryptVolume
	{
		public string VaultLocation;
		public string VolumeLocation;
		public string OpenVaultLocation;
		public string UID;
		
		
		Dictionary<string,string> MetadataValues = new Dictionary<string, string>();
		bool _unlocked;
		string _metadata;
		
		public bool Unlocked
		{
			get
			{
				return _unlocked;
			}
		}
		
		public FireCryptVolume(string location)
		{
			string fnwoext = Path.GetFileNameWithoutExtension(location); //filenamewithout extension
			string volN = Path.GetDirectoryName(location)+"\\"+fnwoext+".vault\\"+fnwoext+".firecrypt";
			VolumeLocation = volN;
			VaultLocation = Path.GetDirectoryName(volN);
			_unlocked = Directory.Exists(OpenVaultLocation);
			_metadata = File.ReadAllText(VaultLocation+"\\vault.metadata");
			var jss = new JavaScriptSerializer();
			MetadataValues = jss.Deserialize<Dictionary<string,string>>(_metadata);
		}
	}
}

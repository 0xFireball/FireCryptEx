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
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FireCrypt.Network
{
	/// <summary>
	/// Network Drive Interface
	/// </summary>
	public class NetworkDrive
	{

		#region API
		[DllImport("mpr.dll")] private static extern int WNetAddConnection2A(ref structNetResource pstNetRes, string psPassword, string psUsername, int piFlags);
		[DllImport("mpr.dll")] private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);
		[DllImport("mpr.dll")] private static extern int WNetConnectionDialog(int phWnd, int piType);
		[DllImport("mpr.dll")] private static extern int WNetDisconnectDialog(int phWnd, int piType);
		[DllImport("mpr.dll")] private static extern int WNetRestoreConnectionW(int phWnd, string psLocalDrive);

		[StructLayout(LayoutKind.Sequential)]
		private struct structNetResource{
			public int iScope;
			public int iType;
			public int iDisplayType;
			public int iUsage;
			public string sLocalName;
			public string sRemoteName;
			public string sComment;
			public string sProvider;
		}
		
		private const int RESOURCETYPE_DISK = 0x1;
		
		//Standard	
		private const int CONNECT_INTERACTIVE = 0x00000008;
		private const int CONNECT_PROMPT = 0x00000010;
		private const int CONNECT_UPDATE_PROFILE = 0x00000001;
		//IE4+
		private const int CONNECT_REDIRECT = 0x00000080;
		//NT5 only
		private const int CONNECT_COMMANDLINE = 0x00000800;
		private const int CONNECT_CMD_SAVECRED = 0x00001000;
		
		#endregion

		#region Propertys and options
		private bool lf_SaveCredentials = false;
		/// <summary>
		/// Option to save credentials are reconnection...
		/// </summary>
		public bool SaveCredentials{
			get{return(lf_SaveCredentials);}
			set{lf_SaveCredentials=value;}
		}
		private bool lf_Persistent = false;
		/// <summary>
		/// Option to reconnect drive after log off / reboot ...
		/// </summary>
		public bool Persistent{
			get{return(lf_Persistent);}
			set{lf_Persistent=value;}
		}
		private bool lf_Force = false;
		/// <summary>
		/// Option to force connection if drive is already mapped...
		/// or force disconnection if network path is not responding...
		/// </summary>
		public bool Force{
			get{return(lf_Force);}
			set{lf_Force=value;}
		}
		private bool ls_PromptForCredentials = false;
		/// <summary>
		/// Option to prompt for user credintals when mapping a drive
		/// </summary>
		public bool PromptForCredentials{
			get{return(ls_PromptForCredentials);}
			set{ls_PromptForCredentials=value;}
		}

		private string ls_Drive = "s:";
		/// <summary>
		/// Drive to be used in mapping / unmapping...
		/// </summary>
		public string LocalDrive{
			get{return(ls_Drive);}
			set{
				if(value.Length>=1) {
					ls_Drive=value.Substring(0,1)+":";
				}else{
					ls_Drive="";
				}
			}
		}
		private string ls_ShareName = "\\\\Computer\\C$";
		/// <summary>
		/// Share address to map drive to.
		/// </summary>
		public string ShareName{
			get{return(ls_ShareName);}
			set{ls_ShareName=value;}
		}
		#endregion

		#region Function mapping
		/// <summary>
		/// Map network drive
		/// </summary>
		public void MapDrive(){zMapDrive(null, null);}
		/// <summary>
		/// Map network drive (using supplied Password)
		/// </summary>
		public void MapDrive(string Password){zMapDrive(null, Password);}
		/// <summary>
		/// Map network drive (using supplied Username and Password)
		/// </summary>
		public void MapDrive(string Username, string Password){zMapDrive(Username, Password);}
		/// <summary>
		/// Unmap network drive
		/// </summary>
		public void UnMapDrive(){zUnMapDrive(this.lf_Force);}
		/// <summary>
		/// Check / restore persistent network drive
		/// </summary>
		public void RestoreDrives(){zRestoreDrive();}
		/// <summary>
		/// Display windows dialog for mapping a network drive
		/// </summary>
		public void ShowConnectDialog(Form ParentForm){zDisplayDialog(ParentForm,1);}
		/// <summary>
		/// Display windows dialog for disconnecting a network drive
		/// </summary>
		public void ShowDisconnectDialog(Form ParentForm){zDisplayDialog(ParentForm,2);}


		#endregion

		#region Core functions

		// Map network drive
		private void zMapDrive(string psUsername, string psPassword){
			//create struct data
			structNetResource stNetRes = new structNetResource();			
			stNetRes.iScope=2;
			stNetRes.iType=RESOURCETYPE_DISK;
			stNetRes.iDisplayType=3;
			stNetRes.iUsage=1;
			stNetRes.sRemoteName=ls_ShareName;
			stNetRes.sLocalName=ls_Drive;			
			//prepare params
			int iFlags=0;
			if(lf_SaveCredentials){iFlags+=CONNECT_CMD_SAVECRED;}
			if(lf_Persistent){iFlags+=CONNECT_UPDATE_PROFILE;}
			if(ls_PromptForCredentials){iFlags+=CONNECT_INTERACTIVE+CONNECT_PROMPT;}
			if(psUsername==""){psUsername=null;}
			if(psPassword==""){psPassword=null;}
			//if force, unmap ready for new connection
			if(lf_Force){try{zUnMapDrive(true);}catch{}}
			//call and return
			int i = WNetAddConnection2A(ref stNetRes, psPassword, psUsername, iFlags);			
			if(i>0){throw new System.ComponentModel.Win32Exception(i);}						
		}


		// Unmap network drive	
		private void zUnMapDrive(bool pfForce){
			//call unmap and return
			int iFlags=0;
			if(lf_Persistent){iFlags+=CONNECT_UPDATE_PROFILE;}
			int i = WNetCancelConnection2A(ls_Drive, iFlags, Convert.ToInt32(pfForce));
			if(i!=0) i=WNetCancelConnection2A(ls_ShareName, iFlags, Convert.ToInt32(pfForce));  //disconnect if localname was null
			if(i>0){throw new System.ComponentModel.Win32Exception(i);}
		}
		

		// Check / Restore a network drive
		private void zRestoreDrive()
		{
			//call restore and return
			int i = WNetRestoreConnectionW(0, null);
			if(i>0){throw new System.ComponentModel.Win32Exception(i);}
		}

		// Display windows dialog
		private void zDisplayDialog(Form poParentForm, int piDialog)
		{
			int i = -1;
			int iHandle = 0;
			//get parent handle
			if(poParentForm!=null)
			{
				iHandle = poParentForm.Handle.ToInt32();
			}
			//show dialog
			if(piDialog==1)
			{
				i = WNetConnectionDialog(iHandle, RESOURCETYPE_DISK);
			}else if(piDialog==2)
			{
				i = WNetDisconnectDialog(iHandle, RESOURCETYPE_DISK);
			}
			if(i>0){throw new System.ComponentModel.Win32Exception(i);}
			//set focus on parent form
			poParentForm.BringToFront();
		}
		
		[DllImport("mpr.dll", CharSet = CharSet.Unicode)]
		[return:MarshalAs(UnmanagedType.U4)]
		static extern int WNetGetUniversalName(
		    string lpLocalPath,
		    [MarshalAs(UnmanagedType.U4)] int dwInfoLevel,
		    IntPtr lpBuffer,
		    [MarshalAs(UnmanagedType.U4)] ref int lpBufferSize);
		
		const int UNIVERSAL_NAME_INFO_LEVEL = 0x00000001;
		const int REMOTE_NAME_INFO_LEVEL = 0x00000002;
		
		const int ERROR_MORE_DATA = 234;
		const int NOERROR = 0;    
		
		public static string GetUniversalName(string localPath)
		{
		    // The return value.
		    string retVal = null ;
		
		    // The pointer in memory to the structure.
		    IntPtr buffer = IntPtr.Zero;
		
		    // Wrap in a try/catch block for cleanup.
		    try
		    {
		        // First, call WNetGetUniversalName to get the size.
		        int size = 0;
		
		        // Make the call.
		        // Pass IntPtr.Size because the API doesn't like null, even though
		        // size is zero.  We know that IntPtr.Size will be
		        // aligned correctly.
		        int apiRetVal = WNetGetUniversalName(localPath, UNIVERSAL_NAME_INFO_LEVEL, (IntPtr) IntPtr.Size, ref size);
		
		        // If the return value is not ERROR_MORE_DATA, then
		        // raise an exception.
		        if (apiRetVal != ERROR_MORE_DATA)
		            // Throw an exception.
		            throw new Win32Exception(apiRetVal);
		
		        // Allocate the memory.
		        buffer = Marshal.AllocCoTaskMem(size);
		
		        // Now make the call.
		        apiRetVal = WNetGetUniversalName(localPath, UNIVERSAL_NAME_INFO_LEVEL, buffer, ref size);
		
		        // If it didn't succeed, then throw.
		        if (apiRetVal != NOERROR)
		            // Throw an exception.
		            throw new Win32Exception(apiRetVal);
		
		        // Now get the string.  It's all in the same buffer, but
		        // the pointer is first, so offset the pointer by IntPtr.Size
		        // and pass to PtrToStringAnsi.
		        retVal = Marshal.PtrToStringAuto(new IntPtr(buffer.ToInt64() + IntPtr.Size), size);
		        retVal = retVal.Substring(0, retVal.IndexOf('\0'));
		    }
		    finally
		    {
		        // Release the buffer.
		        Marshal.FreeCoTaskMem(buffer);
		    }
		
		    // First, allocate the memory for the structure.
		
		    // That's all folks.
		    return retVal;
		}
		[DllImport("mpr.dll")]
    static extern int WNetGetUniversalNameA(
        string lpLocalPath, int dwInfoLevel, IntPtr lpBuffer, ref int lpBufferSize
    );

    // I think max length for UNC is actually 32,767
    public static string LocalToUNC(string localPath, int maxLen = 2000)
    {
        IntPtr lpBuff;

        // Allocate the memory
        try
        {
            lpBuff = Marshal.AllocHGlobal(maxLen); 
        }
        catch (OutOfMemoryException)
        {
            return null;
        }

        try
        {
            int res = WNetGetUniversalNameA(localPath, 1, lpBuff, ref maxLen);

            if (res != 0)
                return null;

            // lpbuff is a structure, whose first element is a pointer to the UNC name (just going to be lpBuff + sizeof(int))
            return Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(lpBuff));
        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            Marshal.FreeHGlobal(lpBuff);
        }
    }
    [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WNetGetConnection(
            [MarshalAs(UnmanagedType.LPTStr)] string localName, 
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder remoteName, 
            ref int length);
        /// <summary>
        /// Given a path, returns the UNC path or the original. (No exceptions
        /// are raised by this function directly). For example, "P:\2008-02-29"
        /// might return: "\\networkserver\Shares\Photos\2008-02-09"
        /// </summary>
        /// <param name="originalPath">The path to convert to a UNC Path</param>
        /// <returns>A UNC path. If a network drive letter is specified, the
        /// drive letter is converted to a UNC or network path. If the 
        /// originalPath cannot be converted, it is returned unchanged.</returns>
        public static string GetUNCPath(string originalPath)
        {
            StringBuilder sb = new StringBuilder(512);
            int size = sb.Capacity;

            // look for the {LETTER}: combination ...
            if (originalPath.Length > 2 && originalPath[1] == ':')
            {
                // don't use char.IsLetter here - as that can be misleading
                // the only valid drive letters are a-z && A-Z.
                char c = originalPath[0];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    int error = WNetGetConnection(originalPath.Substring(0, 2), 
                        sb, ref size);
                    if (error == 0)
                    {                        
                        DirectoryInfo dir = new DirectoryInfo(originalPath);

                        string path = Path.GetFullPath(originalPath)
                            .Substring(Path.GetPathRoot(originalPath).Length);
                        return Path.Combine(sb.ToString().TrimEnd(), path);
                    }
                }
            }
            
            return originalPath;
        }
        public static string ConvertToUNCPath(string localpath)
        {
        	string uncP = null;
        	DriveInfo di = new DriveInfo(localpath);
        	string driveLetter = di.Name.Replace(":\\","");
        	string sysName = Environment.MachineName;
        	string nDpath = localpath.Substring (Path.GetPathRoot(localpath).Length); //path without drive letter
        	uncP = string.Format(@"\\{0}\{1}$\{2}",sysName,driveLetter,nDpath);
        	return uncP;
        }
    }


		#endregion

}

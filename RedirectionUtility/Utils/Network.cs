using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace RedirectionUtility.Utils
{
    public class Network
    {
        private const string ucbFiles = @"\\files.colorado.edu\";
        private const string UsrFolderName = @"\Users\";
        private string fullPath = null;

        public bool CreateFolder(string user)
        {
            if (Directory.Exists(fullPath))
            {
                return true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(fullPath);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    return false;
                }
            }
        }
        public bool AssignPermission(string user)
        {
            DirectoryInfo dir = Directory.GetParent(fullPath);
            if (SetAcl(user)) return true;
            else return false;
        }
        private bool SetAcl(string user)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dirSec = dirInfo.GetAccessControl();
            try
            {
                dirSec = AssignSettings(dirSec,user);
                dirInfo.SetAccessControl(dirSec);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        private DirectorySecurity AssignSettings(DirectorySecurity dirSec,string user) {
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.Read, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.Write, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.Modify, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.ReadAndExecute, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.ListDirectory, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.Read, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.Write, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.Modify, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.ReadAndExecute, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(Environment.UserDomainName + $"\\{user}", FileSystemRights.ListDirectory, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            return dirSec;
        }
        public bool ProcessAll(string dept,string usr)
        {
            fullPath = ucbFiles + dept + UsrFolderName + usr;
            if (CreateFolder(usr))
            {
                if (AssignPermission(usr))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

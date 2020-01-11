using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedirectionUtility.Lists;

namespace RedirectionUtility.Utils
{
    public static class ConfigUtil
    {
        private static string deptFile = $"{Application.ExecutablePath}\\Config\\departments.cfg";
        private static string serverFile = $"{Application.ExecutablePath}\\Config\\servers.cfg";
        private static string oneDriveFile = $"{Application.ExecutablePath}\\Config\\onedrive_name.cfg";
        private static string configFolder = $"{Application.ExecutablePath}\\Config";

        private static string[] GetDepartments()
        {
            try
            {
                if (IO.FilePresent(deptFile))
                {
                    return IO.ReadLines(deptFile);
                }
                else
                {

                    return null;
                }
            }
            catch (Exception e)
            {
                InitialBlankCfg();
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        private static string[] GetServers()
        {
            try
            {
                if (IO.FilePresent(serverFile))
                {
                    return IO.ReadLines(serverFile);
                }
                else
                {

                    return null;
                }
            }
            catch (Exception e)
            {
                InitialBlankCfg();
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public static bool GetConfigs()
        {
            if (IO.FolderPresent(configFolder))
            {
                StaticDepartments.Departments.AddRange(GetDepartments());
                StaticServerLocations.Paths.AddRange(GetServers());
                return true;
            }
            else
            {
                // Fresh start
                InitialBlankCfg();
                return false;
            }
        }

        private static void InitialBlankCfg()
        {
            IO.CreateFolder(configFolder);
            IO.CreateFile(deptFile);
            IO.CreateFile(serverFile);
        }
    }
}

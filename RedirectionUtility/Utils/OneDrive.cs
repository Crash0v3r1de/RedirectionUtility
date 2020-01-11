using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedirectionUtility.Lists;

namespace RedirectionUtility.Utils
{
    public class OneDrive
    {
        private string oneDrivePath = $"C:\\Users{Environment.UserName}\\{StaticOneDriveName.OneDriveName.Split(':')[0]}";
        private string redirectionFolder = $"\\{StaticOneDriveName.OneDriveName.Split(':')[1]}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public static class VersionGV
    {
        public static string LocalVersion = "3.0";
        public static string WebVersion = CheckUpdate.Instance.GetVersion();
    }
    public static class SomeV
    {
        // 这是拿Visual Studio Code敲的
        public static string HWID = ProcessHelper.GetHardwareId();
        public static string IPAddress = ProcessHelper.GetPublicIpAddress();
    }
}

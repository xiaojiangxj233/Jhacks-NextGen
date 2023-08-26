using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public class ProcessHelper
    {
        public static int FindPid(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                return processes[0].Id;
            }
            else
            {
                return -1; // 如果未找到匹配的进程，则返回-1
            }
        }

        public static string GetHardwareId()
        {
            string hardwareId = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct");
                foreach (ManagementObject obj in searcher.Get())
                {
                    hardwareId = obj["UUID"].ToString();
                    break; // 只获取第一个对象的硬件ID
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve hardware ID: " + ex.Message);
            }
            return hardwareId;
        }

        public static bool IsRunningAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        public static async Task<string> GetIP()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string ip = await client.GetStringAsync("https://api.ipify.org");
                    return ip.Trim();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to retrieve public IP address: " + ex.Message);
            }
            return string.Empty;
        }
     
    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
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
        public static string GetPublicIpAddress()
        {
            try
            {
                string externalIP;

                using (WebClient client = new WebClient())
                {
                    externalIP = client.DownloadString("https://api-ipv4.ip.sb/ip");
                }

                return externalIP;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取公网IP地址时出现错误: {ex.Message}");
                return "None";
            }


        }
        public static bool RunCmdCommand(string command)
        {
            // 创建一个ProcessStartInfo对象，用于设置进程启动信息
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe", // 设置要执行的命令行程序（cmd.exe）
                RedirectStandardInput = true, // 启用标准输入流
                RedirectStandardOutput = true, // 启用标准输出流
                CreateNoWindow = false, // 不创建新窗口
                UseShellExecute = false, // 不使用操作系统外壳程序启动进程
                Verb = "runasuser" // 以普通用户权限运行
            };

            // 创建一个Process对象，并将启动信息传递给它
            Process process = new Process
            {
                StartInfo = psi
            };

            // 启动进程
            process.Start();

            // 向命令行发送命令
            process.StandardInput.WriteLine(command);

            // 等待命令执行完成
            process.WaitForExit();

            // 获取命令的退出码
            int exitCode = process.ExitCode;

            // 关闭进程
            process.Close();

            // 返回true表示成功（ExitCode为0），否则返回false
            return exitCode == 0;
        }

    }
    public class OpenURLInterop
    {
        // 使用 DllImport 声明 OpenURL.dll 中的 OpenURL 方法
        [DllImport("OpenURL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void OpenURL(string url);

        // 这是一个可选的包装方法，如果需要进行更多的处理或错误处理，可以在这里添加代码。
        public static void OpenURLWrapper(string url)
        {
            try
            {
                OpenURL(url);
            }
            catch (Exception ex)
            {
                // 处理异常，如果有的话
                DevConsole.Instance.WriteLine($"发生异常：{ex.Message}");
                MessageBox.Show($"发生异常：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jhacks_NextGen
{
    public class GETQQ
    {
        // 导入WinAPI函数来隐藏窗口
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;

        // 释放GETQQ.exe到Jhacks-NextGen文件夹，并返回释放是否成功
        public static bool ExtractGETQQ()
        {
            try
            {
                // 获取GETQQ.exe的完整路径
                string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string jhacksNextGenFolder = Path.Combine(exeDirectory, "Jhacks-NextGen");
                string exePathInJhacksNextGen = Path.Combine(jhacksNextGenFolder, "GETQQ.exe");

                // 检查是否需要释放GETQQ.exe
                if (!File.Exists(exePathInJhacksNextGen))
                {
                    // 获取嵌入资源的流
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    string resourceName = "Jhacks_NextGen.src.GETQQ.exe"; // 嵌入资源的名称
                    using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
                    {
                        if (resourceStream != null)
                        {
                            // 确保Jhacks-NextGen文件夹存在
                            if (!Directory.Exists(jhacksNextGenFolder))
                            {
                                Directory.CreateDirectory(jhacksNextGenFolder);
                            }

                            // 写入GETQQ.exe到Jhacks-NextGen文件夹内
                            using (FileStream fileStream = File.Create(exePathInJhacksNextGen))
                            {
                                resourceStream.CopyTo(fileStream);
                            }

                            return true; // 成功释放GETQQ.exe
                        }
                        else
                        {
                            throw new Exception("未找到GETQQ.exe的嵌入资源");
                        }
                    }
                }
                else
                {
                    // GETQQ.exe 已经存在
                    return true; // 已存在，认为成功
                }
            }
            catch (Exception)
            {
                throw new Exception("GETQQ.exe释放失败");
                return false; // 释放失败
            }
        }

        // 获取QQ号码
        public static string GetQQNumber()
        {
            // 获取GETQQ.exe的完整路径
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Jhacks-NextGen", "GETQQ.exe");

            if (File.Exists(exePath))
            {
                // 创建一个ProcessStartInfo对象来配置要执行的GETQQ.exe进程
                ProcessStartInfo psi = new ProcessStartInfo(exePath)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas" // 请求管理员权限
                };

                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();

                    // 等待GETQQ.exe进程完成
                    process.WaitForExit();

                    // 读取GETQQ.exe的输出
                    string output = process.StandardOutput.ReadToEnd();

                    // 隐藏GETQQ.exe的窗口
                    IntPtr hWnd = FindWindow(null, process.MainWindowTitle);
                    if (hWnd != IntPtr.Zero)
                    {
                        ShowWindow(hWnd, SW_HIDE);
                    }
                    DevConsole.Instance.WriteLine(output);
                    return output;
                }
            }
            else
            {
                MessageBox.Show("GETQQ.exe 未找到，你是不是删除了这个文件\n如果程序自动释放失败，请重启程序");
                return "114514";
                
            }
        }

    }
}


using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Jhacks_NextGen
{
    public partial class MainForm : Form

    {
        private static HttpClient httpClient = new HttpClient();
        private static string jhacksFolderPath;
        private static bool shouldDeleteFolder = true;
        public MainForm()
        {
            InitializeComponent();
            // 在窗体加载时执行复制和解压缩操作
            CopyAndExtractFiles();
            FetchAndDisplayContentAsync();

            // 绑定窗体关闭事件
            this.FormClosing += MainForm_FormClosing;
            bool isRunningAsAdmin = ProcessHelper.IsRunningAsAdmin();
            if (isRunningAsAdmin)
            {
                ProcessList.PopulateProcessList(jinchenBox);
                

            }
            else
            {
                MessageBox.Show("请使用管理员权限运行此程序", "信息");
                Environment.Exit(0);
            }
            
            



        }
        public class ProcessList
        {
            public static void PopulateProcessList(ComboBox comboBox)
            {
                try
                {
                    // 获取当前计算机上运行的所有进程
                    Process[] processes = Process.GetProcesses();

                    // 遍历进程列表并将进程名称添加到 ComboBox 控件中
                    foreach (Process process in processes)
                    {
                        comboBox.Items.Add(process.ProcessName + ".exe" + "(pid:" + ProcessHelper.FindPid(process.ProcessName) + ")");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("获取进程列表出错：" + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessList.PopulateProcessList(jinchenBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int processpid = ProcessHelper.FindPid(jinchenBox.Text);
            if (processpid != -1)
            {
                string selectedText = jinchenBox.SelectedItem.ToString();
                if (selectedText == "Zelix Cracked(1.12.2)")
                {
                    DLLInjector.InjectDLL(jhacksFolderPath + "zelix.dll", processpid);
                }

            }
            else
            {
                MessageBox.Show("进程不存在");
                return;
            }

        }
        private void CopyAndExtractFiles()
        {
            try
            {
                // 获取临时目录路径
                string tempFolderPath = Path.GetTempPath();

                // 创建 Jhacks-NextGen 文件夹路径
                jhacksFolderPath = Path.Combine(tempFolderPath, "Jhacks-NextGen");

                // 创建 Jhacks-NextGen 文件夹
                Directory.CreateDirectory(jhacksFolderPath);

                // 获取当前程序集
                Assembly assembly = Assembly.GetExecutingAssembly();

                // 构建资源名称
                string zelixResourceName = "Jhacks_NextGen.zelix.dll";
                string vapeResourceName = "Jhacks_NextGen.vape.zip";

                // 复制并解压资源
                using (Stream zelixStream = assembly.GetManifestResourceStream(zelixResourceName))
                using (Stream vapeStream = assembly.GetManifestResourceStream(vapeResourceName))
                {
                    // 复制 zelix.dll 到 Jhacks-NextGen 文件夹
                    string zelixDllDestinationPath = Path.Combine(jhacksFolderPath, "zelix.dll");
                    using (FileStream fileStream = new FileStream(zelixDllDestinationPath, FileMode.Create))
                    {
                        zelixStream.CopyTo(fileStream);
                    }

                    // 复制 vape.zip 到 Jhacks-NextGen 文件夹
                    string vapeZipDestinationPath = Path.Combine(jhacksFolderPath, "vape.zip");
                    using (FileStream fileStream = new FileStream(vapeZipDestinationPath, FileMode.Create))
                    {
                        vapeStream.CopyTo(fileStream);
                    }

                    // 解压 vape.zip 到 Jhacks-NextGen 文件夹
                    string vapeZipExtractPath = Path.Combine(jhacksFolderPath, "vape");
                    ZipFile.ExtractToDirectory(vapeZipDestinationPath, vapeZipExtractPath);

                    Console.WriteLine("文件复制、解压缩完成！");
                }

                // 在窗体关闭事件中取消删除临时文件夹的操作
                Application.ApplicationExit += Application_ApplicationExit;
            }
            catch (Exception ex)
            {
                Console.WriteLine("操作出错：" + ex.Message);
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            shouldDeleteFolder = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shouldDeleteFolder)
            {
                // 删除 vape.zip 文件
                string vapeZipDestinationPath = Path.Combine(jhacksFolderPath, "vape.zip");
                if (File.Exists(vapeZipDestinationPath))
                {
                    File.Delete(vapeZipDestinationPath);
                    Console.WriteLine("vape.zip 文件已删除！");
                }

                // 删除临时文件夹及其内容
                if (Directory.Exists(jhacksFolderPath))
                {
                    Directory.Delete(jhacksFolderPath, true);
                    Console.WriteLine("临时文件夹已删除！");
                }
            }
        }
        private async Task FetchAndDisplayContentAsync()
        {
            try
            {
                string url = "https://jhacks.xiaojiang233.top/bcapi.html";

                // 发送 GET 请求并获取响应内容
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode(); // 确保响应成功

                string responseBody = await response.Content.ReadAsStringAsync();

                // 处理 HTML 标签，并将结果显示在多行文本框中
                string processedText = ProcessHtml(responseBody);

                // 在 BCtextBox1 中显示内容
                BCtextBox1.Text = processedText;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取内容失败：" + ex.Message);
            }
        }

        private string ProcessHtml(string input)
        {
            // 去除 Cloudflare 脚本
            input = RemoveCloudflareScript(input);

            // 去除 < 和 > 包含的内容（保留前9行内容）
            string[] lines = input.Split(new[] { '\n' });
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < 9)
                {
                    continue; // 保留前9行内容
                }

                lines[i] = Regex.Replace(lines[i], "<.*?>", ""); // 去除 HTML 标签
            }
            return string.Join(Environment.NewLine, lines);
        }

        private string RemoveCloudflareScript(string input)
        {
            // 找到一对 Cloudflare 脚本，并将其删除
            string pattern = @"\(function\(\)\{var js = ""window\['__CF\$cv\$params'\].*?;\}\)\(\);";
            return Regex.Replace(input, pattern, "");
        }
    }
}



using Microsoft.JSInterop;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Net;
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
        QQNumberExtractor qqNumberExtractor = new QQNumberExtractor();
        private DateTime startTime;
        private int clicks;
        private string logFilePath = "Jhacks-NextGen\\CPSTester.txt";
        public MainForm()
        {



            // 绑定窗体关闭事件
            this.FormClosing += MainForm_FormClosing;
            bool isRunningAsAdmin = ProcessHelper.IsRunningAsAdmin();
            if (isRunningAsAdmin)
            {
                // 在初始化组件之前执行硬件 ID 检查
                string hwid = ProcessHelper.GetHardwareId();
                bool isHwidValid = CheckHardwareId(hwid);

                if (!isHwidValid)
                {
                    MessageBox.Show("你的hwid没有被录入，请打开https://jhacks.xiaojiang233.top进行录入，按确定键复制你的hwid\n或者你的网络出现了问题，检查后重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // 复制 hwid 到剪贴板
                    Clipboard.SetText(hwid);

                    // 关闭应用程序
                    Environment.Exit(0);
                }
                else
                {

                    InitializeComponent();
                    // 在窗体加载时执行复制和解压缩操作
                    CopyAndExtractFiles();
                    EnsureLogsDirectoryExists();
                    FetchAndDisplayContentAsync();
                    bool isDevelopmentEnvironment = DevelopmentEnvironmentDetector.IsDevelopmentEnvironment();
                    if (isDevelopmentEnvironment)
                    {
                        this.Text = this.Text + "(Dev-Build)";
                        DevConsole.Instance.WriteLine("程序加载完成(Debug)");


                    }
                    else
                    {
                        this.Text = this.Text;
                        DevConsole.Instance.Hide();
                        this.Text = this.Text + "(Release-Build)";
                        DevConsole.Instance.WriteLine("程序加载完成");
                    }
                    ModeComboBox.Items.Add("左键模式");
                    ModeComboBox.Items.Add("右键模式");

                    // 向 TimeComboBox 添加选项
                    TimecomboBox.Items.Add("1秒");
                    TimecomboBox.Items.Add("5秒");
                    TimecomboBox.Items.Add("10秒");
                    TimecomboBox.Items.Add("20秒");

                    // 创建目录并加载日志数据
                    Directory.CreateDirectory("Jhacks-NextGen");
                    LoadLogData();

                    // 更新按钮文本
                    UpdateButtonText();
                }



            }
            else
            {
                MessageBox.Show("请使用管理员权限运行此程序", "信息");
                DevConsole.Instance.WriteLine("未使用管理员权限运行，退出");
                Environment.Exit(0);
            }





        }
        private bool CheckHardwareId(string hwid)
        {
            try
            {
                string url = $"https://jhacks.xiaojiang233.top/GET.php?hwid={hwid}";

                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(url);
                    return response.Trim().ToLower() == "true";
                }
            }
            catch (Exception ex)
            {
                // 处理异常，例如网络问题等
                DevConsole.Instance.WriteLine("验证HWID失败:" + (ex.Message));
                return false;
            }
        }
        private void LoadLogData()
        {
            if (File.Exists(logFilePath))
            {
                string[] lines = File.ReadAllLines(logFilePath);
                LogListBox.Items.AddRange(lines);
            }
        }
        private void UpdateButtonText()
        {
            if (timer1.Enabled)
                CPStestbtn.Text = "点我";
            else
                CPStestbtn.Text = "点击以开始";
        }
        private void StartTimer()
        {
            startTime = DateTime.Now;
            clicks = 0;
            timer1.Start();
            UpdateButtonText();
        }
        private void StopTimer()
        {
            timer1.Stop();
            UpdateButtonText();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - startTime;
            int totalMilliseconds = (int)elapsedTime.TotalMilliseconds;
            int cps = (int)Math.Round((clicks / (totalMilliseconds / 1000.0)), 2);

            timelabel.Text = $"剩余时长: {20 - elapsedTime.TotalSeconds:F1}秒";
        }
        private void CPStestbtn_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                clicks++;
                int cps = (int)Math.Round(clicks / (20 - timer1.Interval / 1000.0), 2);
                LogListBox.Items.Add($"{DateTime.Now} {cps}CPS");
            }
            else
            {
                StartTimer();
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
                        comboBox.Items.Add(process.ProcessName);
                    }
                }
                catch (Exception ex)
                {
                    DevConsole.Instance.WriteLine("获取进程列表出错：" + ex.Message);
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
                DevConsole.Instance.WriteLine(jinchenBox.Text + "程序的pid为" + processpid);
                int selectedText = jinchenBox.SelectedIndex;
                if (selectedText == 0)
                {
                    bool aaa = true;
                    DLLInjector.Instance.InjectDLL(processpid, jhacksFolderPath + "\\zelix.dll");
                    DevConsole.Instance.WriteLine(processpid + "," + jhacksFolderPath + "\\zelix.dll");
                    if (aaa)
                    {
                        MessageBox.Show("注入成功");
                        DevConsole.Instance.WriteLine("注入成功");
                    }
                    else
                    {
                        MessageBox.Show("注入失败");
                        DevConsole.Instance.WriteLine("注入成功");
                    }
                }
                else if (selectedText == 1)
                {

                }
                else
                {

                }

            }
            else
            {
                DevConsole.Instance.WriteLine("进程不存在");
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
                DevConsole.Instance.WriteLine("Jhacks临时文件夹目录:" + jhacksFolderPath);

                // 创建 Jhacks-NextGen 文件夹
                Directory.CreateDirectory(jhacksFolderPath);

                // 获取当前程序集
                Assembly assembly = Assembly.GetExecutingAssembly();

                // 构建资源名称
                string zelixResourceName = "Jhacks_NextGen.src.zelix.dll";
                string vapeResourceName = "Jhacks_NextGen.src.vape.zip";

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

                    DevConsole.Instance.WriteLine("文件复制、解压缩完成！");
                    // 删除 vape.zip 文件
                    string vapeZipDestinationPath1 = Path.Combine(jhacksFolderPath, "vape.zip");
                    if (File.Exists(vapeZipDestinationPath))
                    {
                        File.Delete(vapeZipDestinationPath);
                        DevConsole.Instance.WriteLine("vape.zip 文件已删除！");
                    }
                }

                // 在窗体关闭事件中取消删除临时文件夹的操作
                Application.ApplicationExit += Application_ApplicationExit;
            }
            catch (Exception ex)
            {
                DevConsole.Instance.WriteLine("操作出错：" + ex.Message);
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


                // 删除临时文件夹及其内容
                if (Directory.Exists(jhacksFolderPath))
                {
                    Directory.Delete(jhacksFolderPath, true);
                    DevConsole.Instance.WriteLine("临时文件夹已删除！");
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
                DevConsole.Instance.WriteLine("获取内容失败：" + ex.Message);
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

        private void SelectDLLBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.OpenFile();

        }
        private void EnsureLogsDirectoryExists()
        {
            string logsDirectory = System.IO.Path.Combine(Application.StartupPath, "Jhacks-NextGen");
            if (!System.IO.Directory.Exists(logsDirectory))
            {
                System.IO.Directory.CreateDirectory(logsDirectory);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://qm.qq.com/cgi-bin/qm/qr?k=KBXdszckZORIyvIPoGUQ-N3AXzxLV_8w&jump_from=webapi&authKey=KNH0Jehi+S9f82d7tEYep7CGILDJ1KOyLNlqVxTmVIoJQ4U+MVts104+i4xVceUA");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Hide();
            this.button5.Show();
            DevConsole.Instance.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button3.Show();
            this.button5.Hide();
            DevConsole.Instance.Hide();

        }

        private void SelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string qqnumber = qqNumberExtractor.ExtractSingleQQNumber();
            DevConsole.Instance.WriteLine(qqnumber);
        }
    }
}



using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Jhacks_NextGen
{
    public partial class MainForm : Form

    {

        private static HttpClient httpClient = new HttpClient();
        private static string jhacksFolderPath;
        private static bool shouldDeleteFolder = true;
        private string QQNumber = GETQQ.GetQQNumber();
        private LoadForm lFrom;

        private string hwid = ProcessHelper.GetHardwareId();
        public MainForm()
        {



            // 绑定窗体关闭事件
            this.FormClosing += MainForm_FormClosing;
            bool besure = GETQQ.ExtractGETQQ();
            if (besure)
            {
                DevConsole.Instance.WriteLine("GETQQ.exe释放成功");

            }
            else
            {
                DevConsole.Instance.WriteLine("GETQQ.exe释放失败");
            }
            bool isRunningAsAdmin = ProcessHelper.IsRunningAsAdmin();
            if (isRunningAsAdmin)
            {
                // 在初始化组件之前执行硬件 ID 检查

                bool isHwidValid = PerformVerification();

                if (!isHwidValid)
                {
                    MessageBox.Show("你的hwid没有被录入或QQ号不正确，请打开https://jhacks.xiaojiang233.top/Entry.html进行录入，按确定键复制你的hwid\n或者你的网络出现了问题，检查后重试（注意本程序不支持新版QQ，请使用旧版或者使用TIM）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);


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
                    CenterToScreen();
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
                    lFrom = new LoadForm();
                    LoadForm.Instance.Hide();
                    string lv = VersionGV.LocalVersion;
                    string wv = VersionGV.WebVersion;
                    localversion.Text = lv;
                    webversion.Text = wv;
                    QQLabel.Text = SomeV.QQNumber;
                    ThisIPLable.Text = SomeV.IPAddress;

                }



            }
            else
            {
                MessageBox.Show("请使用管理员权限运行此程序", "信息");
                DevConsole.Instance.WriteLine("未使用管理员权限运行，退出");
                Environment.Exit(0);
            }



        }

        private string SendGetRequest(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        // 请求不成功，返回错误消息
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // 发生异常，返回错误消息
                    return null;
                }
            }
        }

        private bool PerformVerification()
        {
            bool bbb = DevelopmentEnvironmentDetector.IsDevelopmentEnvironment();
            if (bbb)
            {
                // 显示一个消息框，并捕获用户的操作结果
                DialogResult result = MessageBox.Show("检测到处于调试模式中\n请问是否跳过验证步骤", "Debug Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // 判断用户的操作结果
                if (result == DialogResult.Yes)
                {
                    DevConsole.Instance.WriteLine("已跳过验证步骤，正在加载UI");
                    return true;

                }
                else if (result == DialogResult.No)
                {

                }
            }
            LoadForm.Instance.message("正在获取机器码");
            DevConsole.Instance.WriteLine("正在获取机器码");
            string hardwareId = ProcessHelper.GetHardwareId();
            SomeV.HWID = hardwareId;
            LoadForm.Instance.message("正在获取QQ号");
            DevConsole.Instance.WriteLine("正在获取QQ号");
            string qqNumber = GETQQ.GetQQNumber();
            SomeV.QQNumber = qqNumber;
            LoadForm.Instance.message("正在获取IP地址");
            DevConsole.Instance.WriteLine("正在获取IP地址");
            string publicIpAddress = ProcessHelper.GetPublicIpAddress();
            SomeV.IPAddress = publicIpAddress;

            // 构建API URL
            LoadForm.Instance.message("正在连接至服务器");
            DevConsole.Instance.WriteLine("正在连接至服务器");
            string apiUrl = $"https://jhacks.xiaojiang233.top/GET.php?hwid={hardwareId}&qq={qqNumber}&ip={publicIpAddress}";
            bool isDevelopmentEnvironment = DevelopmentEnvironmentDetector.IsDevelopmentEnvironment();
            if (isDevelopmentEnvironment)
            {
                DevConsole.Instance.WriteLine("https://jhacks.xiaojiang233.top/GET.php?hwid=" + hardwareId + "&qq=" + qqNumber + "&ip=" + publicIpAddress);
            }


            string jsonResponse = SendGetRequest(apiUrl);

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                // 使用Json.NET库解析JSON响应
                var responseObj = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                bool status = responseObj.status;
                string latestIP = responseObj.latestIP;

                if (status)
                {
                    LoadForm.Instance.message("正在获取公告");

                    // 如果status为true，则继续运行
                    LoadForm.Instance.message("验证完成，正在加载主界面");
                    LoadForm.Instance.message("验证完成，正在加载主界面");
                    LoadForm.Instance.message("验证完成，正在加载主界面");


                    return true;
                }
                else
                {
                    // 如果status为false或没有，则返回false
                    return false;
                }
            }
            else
            {
                // 请求失败，返回false
                return false;
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
                string leaveResourceName = "Jhacks_NextGen.src.Leave.dll";

                // 复制并解压资源
                using (Stream zelixStream = assembly.GetManifestResourceStream(zelixResourceName))
                using (Stream vapeStream = assembly.GetManifestResourceStream(vapeResourceName))
                using (Stream leaveStream = assembly.GetManifestResourceStream(leaveResourceName))
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
                    // 复制 leave.dll 到 Jhacks-NextGen 文件夹
                    string leavedllDestinationPath = Path.Combine(jhacksFolderPath, "leave.dll");
                    using (FileStream fileStream = new FileStream(leavedllDestinationPath, FileMode.Create))
                    {
                        leaveStream.CopyTo(fileStream);
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

        private string GetWebPageContent(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(url).Result; // 使用同步方式获取内容

                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result; // 使用同步方式读取内容
                        return content;
                    }
                    else
                    {
                        return "无法获取网页内容";
                    }
                }
            }
            catch (Exception ex)
            {
                return "发生错误: " + ex.Message;
            }
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
            ShellExecute(IntPtr.Zero, "open", "\"https://qm.qq.com/cgi-bin/qm/qr?k=KBXdszckZORIyvIPoGUQ-N3AXzxLV_8w&jump_from=webapi&authKey=KNH0Jehi+S9f82d7tEYep7CGILDJ1KOyLNlqVxTmVIoJQ4U+MVts104+i4xVceUA\"", null, null, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void SelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string qqnumber = GETQQ.GetQQNumber();
            DevConsole.Instance.WriteLine(qqnumber);
        }

        private void Inject_Click(object sender, EventArgs e)
        {

        }
        public class ApiResponse
        {
            public bool status { get; set; }
            public string latestIP { get; set; }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.button3.Hide();
            this.button5.Show();
            DevConsole.Instance.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.button3.Show();
            this.button5.Hide();
            DevConsole.Instance.Hide();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            throw new Exception(textBox1.Text);
        }

        private void LatestIPLabel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void BCtextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GETHWID_Click(object sender, EventArgs e)
        {
            string hwid = SomeV.HWID;
            MessageBox.Show("你的HWID为:\n" + hwid);
            Clipboard.SetText(hwid);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", jhacksFolderPath);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string a = ModTextBox.Text;
            string c = jhacksFolderPath + "\\will.jar";
            string b = MCLTextBox.Text + "\\Game\\.minecraft\\mods\\J®H™Σ✪A✯☭C➳卐K√↖↗S●.jar";
            File.Copy(a, c);
            File.Move(c, b);
            if (File.Exists(b))
            {
                MessageBox.Show("注入成功");
            }
            else
            {
                MessageBox.Show("注入失败");
            }
        }

        private void liulanModbtn_Click(object sender, EventArgs e)
        {
            // 创建 OpenFileDialog 实例
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // 设置文件过滤器，仅允许选择.jar文件
            openFileDialog1.Filter = "jar模组 (*.jar)|*.jar";

            // 打开文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 将选定的文件路径赋值给 TextBox 控件的 Text 属性
                ModTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 创建 FolderBrowserDialog 实例
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            // 打开文件夹选择对话框
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // 将用户选择的目录路径赋值给 TextBox 控件的 Text 属性
                MCLTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string nVersion = CheckUpdate.Instance.GetVersion();
            string nattribute = CheckUpdate.Instance.GetAttribute();
            string ntime = CheckUpdate.Instance.GetTime();
            string nupdate = CheckUpdate.Instance.GetUpdate();
            string nlink = CheckUpdate.Instance.Link();
            if (nVersion == "无法获取版本号")
            {
                MessageBox.Show("获取更新失败");
            }
            else
            {
                MessageBox.Show("最新版：" + nVersion + "\n" + "版本类型：" + nattribute + "\n" + "发布时间：" + ntime + "\n" + "更新内容：" + "\n" + nupdate + "\n" + "下载链接：" + nlink + "\n");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void VAPUBtn_Click(object sender, EventArgs e)
        {
            PlayEmbeddedResourceAudio("src.guiwowJG.wav");
        }
        static void PlayEmbeddedResourceAudio(string resourceName)
        {
            // 获取当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 构建资源文件的完整名称（包括命名空间）
            string fullResourceName = assembly.GetName().Name + "." + resourceName;

            // 从嵌入资源中读取音频数据
            using (Stream stream = assembly.GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    DevConsole.Instance.WriteLine("找不到资源文件: " + resourceName);
                    return;
                }

                try
                {
                    // 使用NAudio播放音频
                    using (var reader = new NAudio.Wave.WaveFileReader(stream))
                    using (var outputDevice = new NAudio.Wave.WaveOutEvent())
                    {
                        outputDevice.Init(new NAudio.Wave.WaveChannel32(reader));
                        outputDevice.Play();
                        while (outputDevice.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                        {
                            // 等待音频播放完成
                        }
                    }
                }
                catch (Exception ex)
                {
                    DevConsole.Instance.WriteLine("播放音频时出错: " + ex.Message);
                }
            }
        }

        private void SelectDLLBtn_Click_1(object sender, EventArgs e)
        {
            // 创建 OpenFileDialog 实例
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // 设置文件过滤器，仅允许选择.jar文件
            openFileDialog1.Filter = "Windows动态链接库文件 (*.dll)|*.dll";

            // 打开文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 将选定的文件路径赋值给 TextBox 控件的 Text 属性
                SelectBox.Text = openFileDialog1.FileName;
                SelectBox.Items.Add(openFileDialog1.FileName);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int processpid = ProcessHelper.FindPid(jinchenBox.Text);
            if (processpid == -1)
            {
                DevConsole.Instance.WriteLine(jinchenBox.Text + "程序的pid为" + processpid);
                int selectedIndex = jinchenBox.SelectedIndex;
                if (selectedIndex == -1)
                {
                    bool aaa;

                    aaa = Injector.DLLInjector(processpid, jhacksFolderPath + "\\zelix.dll");
                    DevConsole.Instance.WriteLine(processpid + "," + jhacksFolderPath + "\\zelix.dll");
                    if (aaa)
                    {
                        MessageBox.Show("注入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DevConsole.Instance.WriteLine("注入成功");
                    }
                    else
                    {
                        MessageBox.Show("注入失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DevConsole.Instance.WriteLine("注入失败");
                    }
                }
                else if (selectedIndex == 9)
                {
                    bool bbb;

                    bbb = Injector.DLLInjector(processpid, jhacksFolderPath + "\\leave.dll");
                    DevConsole.Instance.WriteLine(processpid + "," + jhacksFolderPath + "\\leave.dll");
                    if (bbb)
                    {
                        MessageBox.Show("注入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DevConsole.Instance.WriteLine("注入成功");
                    }
                    else
                    {
                        MessageBox.Show("注入失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DevConsole.Instance.WriteLine("注入失败");
                    }
                }
                else
                {
                    MessageBox.Show("选项失效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                DevConsole.Instance.WriteLine("进程不存在");
                MessageBox.Show("进程不存在");

                return;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ProcessList.PopulateProcessList(jinchenBox);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (QQFetcher qqFetcher = new QQFetcher())
            {
                string qqNumbers = qqFetcher.GetQQNumbers();
                MessageBox.Show("获取到的QQ号码：" + qqNumbers);
            }

        }
        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShellExecute(IntPtr.Zero, "open", "https://4399.js.mcdds.cn/", null, null, 1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



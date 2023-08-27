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
        public MainForm()
        {


            // �󶨴���ر��¼�
            this.FormClosing += MainForm_FormClosing;
            bool isRunningAsAdmin = ProcessHelper.IsRunningAsAdmin();
            if (isRunningAsAdmin)
            {
                // �ڳ�ʼ�����֮ǰִ��Ӳ�� ID ���
                string hwid = ProcessHelper.GetHardwareId();
                bool isHwidValid = CheckHardwareId(hwid);

                if (!isHwidValid)
                {
                    MessageBox.Show("���hwidû�б�¼�룬���https://jhacks.xiaojiang233.top����¼�룬��ȷ�����������hwid", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    // ���� hwid ��������
                    Clipboard.SetText(hwid);

                    // �ر�Ӧ�ó���
                    Environment.Exit(0);
                }
                else
                {
                    InitializeComponent();
                    // �ڴ������ʱִ�и��ƺͽ�ѹ������
                    CopyAndExtractFiles();
                    EnsureLogsDirectoryExists();
                    FetchAndDisplayContentAsync();
                    bool isDevelopmentEnvironment = DevelopmentEnvironmentDetector.IsDevelopmentEnvironment();
                    if (isDevelopmentEnvironment)
                    {
                        this.Text = this.Text + "(Dev-Build)";
                        DevConsole.Instance.WriteLine("����������");

                    }
                    else
                    {
                        this.Text = this.Text;
                        DevConsole.Instance.Hide();
                    }
                }
                


            }
            else
            {
                MessageBox.Show("��ʹ�ù���ԱȨ�����д˳���", "��Ϣ");
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
                // �����쳣���������������
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public class ProcessList
        {
            public static void PopulateProcessList(ComboBox comboBox)
            {
                try
                {
                    // ��ȡ��ǰ����������е����н���
                    Process[] processes = Process.GetProcesses();

                    // ���������б�������������ӵ� ComboBox �ؼ���
                    foreach (Process process in processes)
                    {
                        comboBox.Items.Add(process.ProcessName);
                    }
                }
                catch (Exception ex)
                {
                    DevConsole.Instance.WriteLine("��ȡ�����б����" + ex.Message);
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
                string selectedText = jinchenBox.SelectedText.ToString();
                if (selectedText == "Zelix Cracked(1.12.2)")
                {
                    bool aaa = DLLInjector.InjectDLL(jhacksFolderPath + "zelix.dll", processpid);
                    if (aaa)
                    {
                        MessageBox.Show("ע��ɹ�");
                        DevConsole.Instance.WriteLine("ע��ɹ�");
                    }
                    else
                    {
                        MessageBox.Show("ע��ʧ��");
                        DevConsole.Instance.WriteLine("ע��ɹ�");
                    }
                }
                else if (selectedText == "Vape V1")
                {

                }

            }
            else
            {
                DevConsole.Instance.WriteLine("���̲�����");
                MessageBox.Show("���̲�����");

                return;
            }

        }
        private void CopyAndExtractFiles()
        {
            try
            {
                // ��ȡ��ʱĿ¼·��
                string tempFolderPath = Path.GetTempPath();

                // ���� Jhacks-NextGen �ļ���·��
                jhacksFolderPath = Path.Combine(tempFolderPath, "Jhacks-NextGen");

                // ���� Jhacks-NextGen �ļ���
                Directory.CreateDirectory(jhacksFolderPath);

                // ��ȡ��ǰ����
                Assembly assembly = Assembly.GetExecutingAssembly();

                // ������Դ����
                string zelixResourceName = "Jhacks_NextGen.zelix.dll";
                string vapeResourceName = "Jhacks_NextGen.vape.zip";

                // ���Ʋ���ѹ��Դ
                using (Stream zelixStream = assembly.GetManifestResourceStream(zelixResourceName))
                using (Stream vapeStream = assembly.GetManifestResourceStream(vapeResourceName))
                {
                    // ���� zelix.dll �� Jhacks-NextGen �ļ���
                    string zelixDllDestinationPath = Path.Combine(jhacksFolderPath, "zelix.dll");
                    using (FileStream fileStream = new FileStream(zelixDllDestinationPath, FileMode.Create))
                    {
                        zelixStream.CopyTo(fileStream);
                    }

                    // ���� vape.zip �� Jhacks-NextGen �ļ���
                    string vapeZipDestinationPath = Path.Combine(jhacksFolderPath, "vape.zip");
                    using (FileStream fileStream = new FileStream(vapeZipDestinationPath, FileMode.Create))
                    {
                        vapeStream.CopyTo(fileStream);
                    }

                    // ��ѹ vape.zip �� Jhacks-NextGen �ļ���
                    string vapeZipExtractPath = Path.Combine(jhacksFolderPath, "vape");
                    ZipFile.ExtractToDirectory(vapeZipDestinationPath, vapeZipExtractPath);

                    DevConsole.Instance.WriteLine("�ļ����ơ���ѹ����ɣ�");
                    // ɾ�� vape.zip �ļ�
                    string vapeZipDestinationPath1 = Path.Combine(jhacksFolderPath, "vape.zip");
                    if (File.Exists(vapeZipDestinationPath))
                    {
                        File.Delete(vapeZipDestinationPath);
                        DevConsole.Instance.WriteLine("vape.zip �ļ���ɾ����");
                    }
                }

                // �ڴ���ر��¼���ȡ��ɾ����ʱ�ļ��еĲ���
                Application.ApplicationExit += Application_ApplicationExit;
            }
            catch (Exception ex)
            {
                DevConsole.Instance.WriteLine("��������" + ex.Message);
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


                // ɾ����ʱ�ļ��м�������
                if (Directory.Exists(jhacksFolderPath))
                {
                    Directory.Delete(jhacksFolderPath, true);
                    DevConsole.Instance.WriteLine("��ʱ�ļ�����ɾ����");
                }
            }
        }
        private async Task FetchAndDisplayContentAsync()
        {
            try
            {
                string url = "https://jhacks.xiaojiang233.top/bcapi.html";

                // ���� GET ���󲢻�ȡ��Ӧ����
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode(); // ȷ����Ӧ�ɹ�

                string responseBody = await response.Content.ReadAsStringAsync();

                // ���� HTML ��ǩ�����������ʾ�ڶ����ı�����
                string processedText = ProcessHtml(responseBody);

                // �� BCtextBox1 ����ʾ����
                BCtextBox1.Text = processedText;
            }
            catch (Exception ex)
            {
                DevConsole.Instance.WriteLine("��ȡ����ʧ�ܣ�" + ex.Message);
            }
        }

        private string ProcessHtml(string input)
        {
            // ȥ�� Cloudflare �ű�
            input = RemoveCloudflareScript(input);

            // ȥ�� < �� > ���������ݣ�����ǰ9�����ݣ�
            string[] lines = input.Split(new[] { '\n' });
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < 9)
                {
                    continue; // ����ǰ9������
                }

                lines[i] = Regex.Replace(lines[i], "<.*?>", ""); // ȥ�� HTML ��ǩ
            }
            return string.Join(Environment.NewLine, lines);
        }

        private string RemoveCloudflareScript(string input)
        {
            // �ҵ�һ�� Cloudflare �ű���������ɾ��
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
            Process.Start("https://qm.qq.com/cgi-bin/qm/qr?k=KBXdszckZORIyvIPoGUQ-N3AXzxLV_8w&jump_from=webapi&authKey=KNH0Jehi+S9f82d7tEYep7CGILDJ1KOyLNlqVxTmVIoJQ4U+MVts104+i4xVceUA");
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
    }
}



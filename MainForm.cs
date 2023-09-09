using Microsoft.JSInterop;
using Newtonsoft.Json;
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
        private string QQNumber = GETQQ.GetQQNumber();

        private string hwid = ProcessHelper.GetHardwareId();
        public MainForm()
        {



            // �󶨴���ر��¼�
            this.FormClosing += MainForm_FormClosing;
            bool besure = GETQQ.ExtractGETQQ();
            if (besure)
            {
                DevConsole.Instance.WriteLine("GETQQ.exe�ͷųɹ�");

            }
            else
            {
                DevConsole.Instance.WriteLine("GETQQ.exe�ͷ�ʧ��");
            }
            bool isRunningAsAdmin = ProcessHelper.IsRunningAsAdmin();
            if (isRunningAsAdmin)
            {
                // �ڳ�ʼ�����֮ǰִ��Ӳ�� ID ���

                bool isHwidValid = PerformVerification();

                if (!isHwidValid)
                {
                    MessageBox.Show("���hwidû�б�¼���QQ�Ų���ȷ�����https://jhacks.xiaojiang233.top/Entry.html����¼�룬��ȷ�����������hwid\n�������������������⣬�������ԣ�ע�Ȿ����֧���°�QQ����ʹ�þɰ����ʹ��TIM��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);


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
                        DevConsole.Instance.WriteLine("����������(Debug)");


                    }
                    else
                    {
                        this.Text = this.Text;
                        DevConsole.Instance.Hide();
                        this.Text = this.Text + "(Release-Build)";
                        DevConsole.Instance.WriteLine("����������");
                    }
                }



            }
            else
            {
                MessageBox.Show("��ʹ�ù���ԱȨ�����д˳���", "��Ϣ");
                DevConsole.Instance.WriteLine("δʹ�ù���ԱȨ�����У��˳�");
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
                        // ���󲻳ɹ������ش�����Ϣ
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // �����쳣�����ش�����Ϣ
                    return null;
                }
            }
        }

        private bool PerformVerification()
        {
            string hardwareId = ProcessHelper.GetHardwareId();
            string qqNumber = GETQQ.GetQQNumber();
            string publicIpAddress = ProcessHelper.GetPublicIpAddress();

            // ����API URL
            string apiUrl = $"https://jhacks.xiaojiang233.top/GET.php?hwid={hardwareId}&qq={qqNumber}&ip={publicIpAddress}";
            bool isDevelopmentEnvironment = DevelopmentEnvironmentDetector.IsDevelopmentEnvironment();
            if (isDevelopmentEnvironment)
            {
                DevConsole.Instance.WriteLine("https://jhacks.xiaojiang233.top/GET.php?hwid=" + hardwareId + "&qq=" + qqNumber + "&ip=" + publicIpAddress);
            }


            string jsonResponse = SendGetRequest(apiUrl);

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                // ʹ��Json.NET�����JSON��Ӧ
                var responseObj = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                bool status = responseObj.status;
                string latestIP = responseObj.latestIP;

                if (status)
                {
                    // ���statusΪtrue�����������
                    // LatestIPLabel.Text = latestIP;
                    return true;
                }
                else
                {
                    // ���statusΪfalse��û�У��򷵻�false
                    return false;
                }
            }
            else
            {
                // ����ʧ�ܣ�����false
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
                DevConsole.Instance.WriteLine(jinchenBox.Text + "�����pidΪ" + processpid);
                int selectedText = jinchenBox.SelectedIndex;
                if (selectedText == 0)
                {
                    bool aaa = true;
                    DLLInjector.Instance.InjectDLL(processpid, jhacksFolderPath + "\\zelix.dll");
                    DevConsole.Instance.WriteLine(processpid + "," + jhacksFolderPath + "\\zelix.dll");
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
                else if (selectedText == 1)
                {

                }
                else
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
                DevConsole.Instance.WriteLine("Jhacks��ʱ�ļ���Ŀ¼:" + jhacksFolderPath);

                // ���� Jhacks-NextGen �ļ���
                Directory.CreateDirectory(jhacksFolderPath);

                // ��ȡ��ǰ����
                Assembly assembly = Assembly.GetExecutingAssembly();

                // ������Դ����
                string zelixResourceName = "Jhacks_NextGen.src.zelix.dll";
                string vapeResourceName = "Jhacks_NextGen.src.vape.zip";

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
            System.Diagnostics.Process.Start("https://qm.qq.com/cgi-bin/qm/qr?k=KBXdszckZORIyvIPoGUQ-N3AXzxLV_8w&jump_from=webapi&authKey=KNH0Jehi+S9f82d7tEYep7CGILDJ1KOyLNlqVxTmVIoJQ4U+MVts104+i4xVceUA");
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
    }
}



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
            // �ڴ������ʱִ�и��ƺͽ�ѹ������
            CopyAndExtractFiles();
            FetchAndDisplayContentAsync();

            // �󶨴���ر��¼�
            this.FormClosing += MainForm_FormClosing;
            bool isRunningAsAdmin = ProcessHelper.IsRunningAsAdmin();
            if (isRunningAsAdmin)
            {
                ProcessList.PopulateProcessList(jinchenBox);
                

            }
            else
            {
                MessageBox.Show("��ʹ�ù���ԱȨ�����д˳���", "��Ϣ");
                Environment.Exit(0);
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
                        comboBox.Items.Add(process.ProcessName + ".exe" + "(pid:" + ProcessHelper.FindPid(process.ProcessName) + ")");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("��ȡ�����б����" + ex.Message);
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

                    Console.WriteLine("�ļ����ơ���ѹ����ɣ�");
                }

                // �ڴ���ر��¼���ȡ��ɾ����ʱ�ļ��еĲ���
                Application.ApplicationExit += Application_ApplicationExit;
            }
            catch (Exception ex)
            {
                Console.WriteLine("��������" + ex.Message);
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
                // ɾ�� vape.zip �ļ�
                string vapeZipDestinationPath = Path.Combine(jhacksFolderPath, "vape.zip");
                if (File.Exists(vapeZipDestinationPath))
                {
                    File.Delete(vapeZipDestinationPath);
                    Console.WriteLine("vape.zip �ļ���ɾ����");
                }

                // ɾ����ʱ�ļ��м�������
                if (Directory.Exists(jhacksFolderPath))
                {
                    Directory.Delete(jhacksFolderPath, true);
                    Console.WriteLine("��ʱ�ļ�����ɾ����");
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
                Console.WriteLine("��ȡ����ʧ�ܣ�" + ex.Message);
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
    }
}



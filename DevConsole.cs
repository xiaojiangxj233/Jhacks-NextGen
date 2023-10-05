using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jhacks_NextGen
{
    public partial class DevConsole : Form
    {
        private static DevConsole _instance;
        private StringBuilder commandHistory = new StringBuilder();
        private int commandHistoryIndex = -1;
        private string LogsFilePath
        {
            get
            {
                string logsDirectory = Path.Combine(Application.StartupPath, "Jhacks-NextGen");
                if (!Directory.Exists(logsDirectory))
                {
                    Directory.CreateDirectory(logsDirectory);
                }
                return Path.Combine(logsDirectory, "DevLogs.txt");
            }
        }
        private DevConsole()
        {
            InitializeComponent(); // Initialize the Form and its controls
            CommandBox.Width = this.ClientSize.Width; // Set CommandBox width
            this.SizeChanged += DevConsole_SizeChanged; // Subscribe to the SizeChanged event
        }

        private void DevConsole_SizeChanged(object sender, EventArgs e)
        {
            CommandBox.Width = this.ClientSize.Width; // Update CommandBox width when the form size changes
        }
        public static DevConsole Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DevConsole();
                return _instance;
            }
        }

        public void WriteLine(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string formattedMessage = $"{timestamp} {message}";
            CommandBox.Items.Add(formattedMessage);
            SaveLogToFile(formattedMessage);
        }

        private void SaveLogToFile(string message)
        {
            using (StreamWriter writer = File.AppendText(LogsFilePath))
            {
                writer.WriteLine(message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void DevConsole_Load(object sender, EventArgs e)
        {
            DisplayWelcome();
        }
        private void CommandSendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = CommandSendTextBox.Text.Trim();
                ExecuteCommand(command);
                CommandSendTextBox.Clear();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                ShowPreviousCommand();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                ShowNextCommand();
                e.Handled = true;
            }
        }
        private void ShowNextCommand()
        {
            if (commandHistoryIndex < commandHistory.Length - 1)
            {
                commandHistoryIndex++;
                CommandSendTextBox.Text = GetCommandFromHistory();
                CommandSendTextBox.SelectionStart = CommandSendTextBox.Text.Length;
            }
            else if (commandHistoryIndex == commandHistory.Length - 1)
            {
                commandHistoryIndex = -1;
                CommandSendTextBox.Text = string.Empty;
            }
        }
        private string GetCommandFromHistory()
        {
            return commandHistory[commandHistoryIndex].ToString();
        }   
        private void ShowPreviousCommand()
        {
            if (commandHistoryIndex > 0)
            {
                commandHistoryIndex--;
                CommandSendTextBox.Text = GetCommandFromHistory();
                CommandSendTextBox.SelectionStart = CommandSendTextBox.Text.Length;
            }
        }
        private void ExecuteCommand(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                commandHistory.Append(command).Append('\n');
                commandHistoryIndex = -1;
                PrintCommand($"> {command}");
                ExecuteCommandInternal(command);
            }
        }
        private void ExecuteCommandInternal(string command)
        {
            string[] parts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
                return;

            string cmd = parts[0].ToLower();

            switch (cmd)
            {
                case "restart":
                    RestartProgram();
                    break;
                case "help":
                    DisplayHelp();
                    break;
                case "findpid":
                    if (parts.Length > 1)
                        FindPid(parts[1]);
                    else
                        PrintMessage("Usage: findpid <程序名>");
                    break;
                case "gethwid":
                    GetHardwareId();
                    break;
                case "injectdll":
                    if (parts.Length > 2)
                        InjectDLL(parts[1], parts[2]);
                    else
                        PrintMessage("Usage: injectdll <pid> <dllpath>");
                    break;
                default:
                    PrintMessage("Unknown command. Type 'help' for a list of commands.");
                    break;
            }
        }
        private void RestartProgram()
        {
            // 重启程序的逻辑，您可以根据需要自定义
            // 此处只是关闭当前程序
            Application.Restart();
            Environment.Exit(0);
        }
        private void FindPid(string programName)
        {
            int pid = -1; // 默认值，表示未找到
            Process[] processes = Process.GetProcessesByName(programName);
            if (processes.Length > 0)
            {
                pid = processes[0].Id;
            }

            PrintMessage($"PID for '{programName}': {pid}");
        }
        private void GetHardwareId()
        {
            string hwid = ProcessHelper.GetHardwareId(); // 假设有一个 GetHardwareId() 方法获取 HWID
            PrintMessage($"HWID: {hwid}");
        }

        private void InjectDLL(string pid, string dllPath)
        {
            int processId = -1;
            if (int.TryParse(pid, out processId) && processId > 0)
            {
                bool success = Injector.DLLInjector(processId, dllPath);
                if (success)
                    PrintMessage($"DLL injected into process {processId}");
                else
                    PrintMessage($"Failed to inject DLL into process {processId}");
            }
            else
            {
                PrintMessage("Invalid PID.");
            }
        }
        private void DisplayHelp()
        {
            string helpText = "Available commands:\r\n" +
                              "  restart - Restart the program\r\n" +
                              "  help - Show this help message\r\n" +
                              "  findpid <程序名> - Find PID for a program\r\n" +
                              "  gethwid - Get HWID\r\n" +
                              "  injectdll <pid> <dllpath> - Inject DLL into a process\r\n";
            PrintMessage(helpText);
        }
        private void DisplayWelcome()
        {
            string helpText = "Welcome to use Jhacks-Console\r\n" +
                              "Available commands:\r\n" +
                              "  restart - Restart the program\r\n" +
                              "  help - Show help message\r\n" +
                              "  findpid <程序名> - Find PID for a program\r\n" +
                              "  gethwid - Get HWID\r\n" +
                              "  injectdll <pid> <dllpath> - Inject DLL into a process\r\n";
            PrintMessage(helpText);
        }
        private void PrintMessage(string message)
        {
            CommandTextBox.AppendText(message + "\r\n");
        }
        private void PrintCommand(string command)
        {
            CommandTextBox.AppendText(command + "\r\n");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string command = CommandSendTextBox.Text.Trim();
            ExecuteCommand(command);
            CommandSendTextBox.Clear();
        }

        private void CommandSendTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            string timestamp = DateTime.Now.ToString("[HH:mm:ss]");
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
        
    }
}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jhacks_NextGen
{
    public partial class HWIDSubmit : Form
    {
        public HWIDSubmit()
        {
            InitializeComponent();
            webView21.Source = new Uri("https://jhacks.xiaojiang233.top/Entry.html");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webView21.Dispose();
            Application.Restart();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }
    }
}

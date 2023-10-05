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
    public partial class XjauthForm : Form
    {
        public XjauthForm()
        {
            InitializeComponent();
            webView21.Source = new Uri("https://4399.js.mcdds.cn/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webView21.Dispose();
            this.Close();

        }
        /*public static XjauthForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoadForm();
                return _instance;
            }

        }*/
        private void button2_Click(object sender, EventArgs e)
        {
            webView21.Reload();
        }
    }
}

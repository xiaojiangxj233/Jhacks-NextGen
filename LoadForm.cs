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
    public partial class LoadForm : Form
    {
        private static LoadForm _instance;
        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        public static LoadForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LoadForm();
                return _instance;
            }

        }
        public void message(string message)
        {
            label2.Text = message;
        }
    }
}

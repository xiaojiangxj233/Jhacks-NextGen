namespace Jhacks_NextGen
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            Home = new TabPage();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            ThisIPLable = new Label();
            QQLabel = new Label();
            Label7 = new Label();
            label8 = new Label();
            BCtextBox1 = new TextBox();
            label1 = new Label();
            Inject = new TabPage();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            jinchenBox = new ComboBox();
            SelectDLLBtn = new Button();
            SelectBox = new ComboBox();
            Settings = new TabPage();
            label6 = new Label();
            Tools = new TabPage();
            tabControl2 = new TabControl();
            ABCD = new TabPage();
            button7 = new Button();
            textBox1 = new TextBox();
            button6 = new Button();
            button3 = new Button();
            button5 = new Button();
            more = new TabPage();
            About = new TabPage();
            label5 = new Label();
            button4 = new Button();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            Home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            Inject.SuspendLayout();
            Settings.SuspendLayout();
            Tools.SuspendLayout();
            tabControl2.SuspendLayout();
            ABCD.SuspendLayout();
            About.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Home);
            tabControl1.Controls.Add(Inject);
            tabControl1.Controls.Add(Settings);
            tabControl1.Controls.Add(Tools);
            tabControl1.Controls.Add(About);
            tabControl1.Location = new Point(-5, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 449);
            tabControl1.TabIndex = 0;
            // 
            // Home
            // 
            Home.Controls.Add(pictureBox1);
            Home.Controls.Add(panel1);
            Home.Controls.Add(BCtextBox1);
            Home.Controls.Add(label1);
            Home.Location = new Point(4, 26);
            Home.Name = "Home";
            Home.Size = new Size(795, 419);
            Home.TabIndex = 4;
            Home.Text = "主页";
            Home.UseVisualStyleBackColor = true;
            Home.Click += Home_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "https://t.mwm.moe/moe";
            pictureBox1.Location = new Point(23, 183);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(407, 215);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ThisIPLable);
            panel1.Controls.Add(QQLabel);
            panel1.Controls.Add(Label7);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(523, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 71);
            panel1.TabIndex = 11;
            // 
            // ThisIPLable
            // 
            ThisIPLable.AutoSize = true;
            ThisIPLable.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            ThisIPLable.Location = new Point(104, 9);
            ThisIPLable.Name = "ThisIPLable";
            ThisIPLable.Size = new Size(57, 20);
            ThisIPLable.TabIndex = 13;
            ThisIPLable.Text = "114514";
            // 
            // QQLabel
            // 
            QQLabel.AutoSize = true;
            QQLabel.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            QQLabel.Location = new Point(115, 35);
            QQLabel.Name = "QQLabel";
            QQLabel.Size = new Size(78, 25);
            QQLabel.TabIndex = 13;
            QQLabel.Text = "114514";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            Label7.Location = new Point(3, 9);
            Label7.Name = "Label7";
            Label7.Size = new Size(95, 20);
            Label7.TabIndex = 12;
            Label7.Text = "这一次使用IP:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(3, 35);
            label8.Name = "label8";
            label8.Size = new Size(118, 25);
            label8.TabIndex = 12;
            label8.Text = "已登录QQ：";
            // 
            // BCtextBox1
            // 
            BCtextBox1.Location = new Point(484, 183);
            BCtextBox1.Multiline = true;
            BCtextBox1.Name = "BCtextBox1";
            BCtextBox1.ReadOnly = true;
            BCtextBox1.Size = new Size(300, 215);
            BCtextBox1.TabIndex = 9;
            BCtextBox1.TextChanged += BCtextBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(13, 0);
            label1.Name = "label1";
            label1.Size = new Size(519, 83);
            label1.TabIndex = 0;
            label1.Text = "Jhacks-Nextgen";
            // 
            // Inject
            // 
            Inject.Controls.Add(button1);
            Inject.Controls.Add(label3);
            Inject.Controls.Add(label2);
            Inject.Controls.Add(button2);
            Inject.Controls.Add(jinchenBox);
            Inject.Controls.Add(SelectDLLBtn);
            Inject.Controls.Add(SelectBox);
            Inject.Location = new Point(4, 26);
            Inject.Name = "Inject";
            Inject.Padding = new Padding(3);
            Inject.Size = new Size(795, 419);
            Inject.TabIndex = 0;
            Inject.Text = "注入";
            Inject.UseVisualStyleBackColor = true;
            Inject.Click += Inject_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(51, 142);
            button1.Name = "button1";
            button1.Size = new Size(352, 189);
            button1.TabIndex = 7;
            button1.Text = "注入";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(14, 96);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 6;
            label3.Text = "要注入的进程：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(10, 60);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 5;
            label2.Text = "要注入的端或DLL：";
            // 
            // button2
            // 
            button2.Location = new Point(663, 99);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "刷新";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // jinchenBox
            // 
            jinchenBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            jinchenBox.FormattingEnabled = true;
            jinchenBox.Location = new Point(148, 99);
            jinchenBox.Name = "jinchenBox";
            jinchenBox.Size = new Size(512, 29);
            jinchenBox.TabIndex = 3;
            jinchenBox.Text = "javaw";
            // 
            // SelectDLLBtn
            // 
            SelectDLLBtn.Location = new Point(663, 56);
            SelectDLLBtn.Name = "SelectDLLBtn";
            SelectDLLBtn.Size = new Size(94, 29);
            SelectDLLBtn.TabIndex = 2;
            SelectDLLBtn.Text = "浏览";
            SelectDLLBtn.UseVisualStyleBackColor = true;
            SelectDLLBtn.Click += SelectDLLBtn_Click;
            // 
            // SelectBox
            // 
            SelectBox.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectBox.FormattingEnabled = true;
            SelectBox.Items.AddRange(new object[] { "Zelix Cracked(1.12.2)", "Vape V4.10(1.8.9Vanila)" });
            SelectBox.Location = new Point(148, 56);
            SelectBox.Name = "SelectBox";
            SelectBox.Size = new Size(511, 29);
            SelectBox.TabIndex = 1;
            SelectBox.Text = "Zelix Cracked(1.12.2)";
            SelectBox.SelectedIndexChanged += SelectBox_SelectedIndexChanged;
            // 
            // Settings
            // 
            Settings.Controls.Add(label6);
            Settings.Location = new Point(4, 26);
            Settings.Name = "Settings";
            Settings.Padding = new Padding(3);
            Settings.Size = new Size(795, 419);
            Settings.TabIndex = 1;
            Settings.Text = "设置";
            Settings.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft YaHei UI", 72F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(227, 119);
            label6.Name = "label6";
            label6.Size = new Size(340, 124);
            label6.TabIndex = 0;
            label6.Text = "未完成";
            // 
            // Tools
            // 
            Tools.Controls.Add(tabControl2);
            Tools.Location = new Point(4, 26);
            Tools.Name = "Tools";
            Tools.Size = new Size(795, 419);
            Tools.TabIndex = 3;
            Tools.Text = "工具";
            Tools.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(ABCD);
            tabControl2.Controls.Add(more);
            tabControl2.Location = new Point(0, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(795, 420);
            tabControl2.TabIndex = 0;
            // 
            // ABCD
            // 
            ABCD.Controls.Add(button7);
            ABCD.Controls.Add(textBox1);
            ABCD.Controls.Add(button6);
            ABCD.Controls.Add(button3);
            ABCD.Controls.Add(button5);
            ABCD.Location = new Point(4, 26);
            ABCD.Name = "ABCD";
            ABCD.Padding = new Padding(3);
            ABCD.Size = new Size(787, 390);
            ABCD.TabIndex = 0;
            ABCD.Text = "114514";
            ABCD.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(267, 160);
            button7.Name = "button7";
            button7.Size = new Size(253, 71);
            button7.TabIndex = 7;
            button7.Text = "模拟报错";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(676, 23);
            textBox1.TabIndex = 6;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(391, 6);
            button6.Name = "button6";
            button6.Size = new Size(253, 71);
            button6.TabIndex = 5;
            button6.Text = "获取QQ号";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(132, 6);
            button3.Name = "button3";
            button3.Size = new Size(253, 71);
            button3.TabIndex = 3;
            button3.Text = "显示开发控制台";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(132, 6);
            button5.Name = "button5";
            button5.Size = new Size(253, 71);
            button5.TabIndex = 4;
            button5.Text = "隐藏开发控制台";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // more
            // 
            more.Location = new Point(4, 26);
            more.Name = "more";
            more.Padding = new Padding(3);
            more.Size = new Size(787, 390);
            more.TabIndex = 1;
            more.Text = "233333";
            more.UseVisualStyleBackColor = true;
            // 
            // About
            // 
            About.Controls.Add(label5);
            About.Controls.Add(button4);
            About.Controls.Add(label4);
            About.Location = new Point(4, 26);
            About.Name = "About";
            About.Size = new Size(795, 419);
            About.TabIndex = 2;
            About.Text = "关于";
            About.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(203, 146);
            label5.Name = "label5";
            label5.Size = new Size(435, 17);
            label5.TabIndex = 2;
            label5.Text = "注意：你是用的是未完成的Dev版本，Dev版本有许多bug，且许多功能都未完成";
            // 
            // button4
            // 
            button4.Location = new Point(1, 129);
            button4.Name = "button4";
            button4.Size = new Size(184, 51);
            button4.TabIndex = 1;
            button4.Text = "点此进入QQ群";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 72F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(789, 124);
            label4.TabIndex = 0;
            label4.Text = "Jhacks-NextGen";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "DLL文件(*.dll)|*.dll";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 450);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Jhacks-NextGen";
            tabControl1.ResumeLayout(false);
            Home.ResumeLayout(false);
            Home.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Inject.ResumeLayout(false);
            Inject.PerformLayout();
            Settings.ResumeLayout(false);
            Settings.PerformLayout();
            Tools.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            ABCD.ResumeLayout(false);
            ABCD.PerformLayout();
            About.ResumeLayout(false);
            About.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Inject;
        private TabPage Settings;
        private TabPage About;
        private ComboBox SelectBox;
        private Button SelectDLLBtn;
        private Label label3;
        private Label label2;
        private Button button2;
        private ComboBox jinchenBox;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Label label4;
        private Button button4;
        private Label label5;
        private TabPage Tools;
        private TabControl tabControl2;
        private TabPage ABCD;
        private TabPage more;
        private System.Windows.Forms.Timer timer1;
        private TabPage Home;
        private Label label1;
        private Button button6;
        private Button button3;
        private Button button5;
        private TextBox BCtextBox1;
        private TextBox textBox1;
        private Button button7;
        private Label label6;
        private Panel panel1;
        private Label QQLabel;
        private Label label8;
        private Label ThisIPLable;
        private Label Label7;
        private PictureBox pictureBox1;
    }
}
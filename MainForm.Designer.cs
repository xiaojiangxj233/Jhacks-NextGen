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
            Inject = new TabPage();
            BCtextBox1 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            jinchenBox = new ComboBox();
            SelectDLLBtn = new Button();
            SelectBox = new ComboBox();
            Settings = new TabPage();
            button6 = new Button();
            button3 = new Button();
            button5 = new Button();
            Tools = new TabPage();
            tabControl2 = new TabControl();
            CPSTester = new TabPage();
            clicklabel = new Label();
            timelabel = new Label();
            TimecomboBox = new ComboBox();
            ModeComboBox = new ComboBox();
            CPStestbtn = new Button();
            LogListBox = new ListBox();
            more = new TabPage();
            About = new TabPage();
            label5 = new Label();
            button4 = new Button();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            Home = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            Inject.SuspendLayout();
            Settings.SuspendLayout();
            Tools.SuspendLayout();
            tabControl2.SuspendLayout();
            CPSTester.SuspendLayout();
            About.SuspendLayout();
            Home.SuspendLayout();
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
            // Inject
            // 
            Inject.Controls.Add(BCtextBox1);
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
            // 
            // BCtextBox1
            // 
            BCtextBox1.Location = new Point(419, 142);
            BCtextBox1.Multiline = true;
            BCtextBox1.Name = "BCtextBox1";
            BCtextBox1.ReadOnly = true;
            BCtextBox1.Size = new Size(348, 187);
            BCtextBox1.TabIndex = 8;
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
            Settings.Controls.Add(button6);
            Settings.Controls.Add(button3);
            Settings.Controls.Add(button5);
            Settings.Location = new Point(4, 26);
            Settings.Name = "Settings";
            Settings.Padding = new Padding(3);
            Settings.Size = new Size(795, 419);
            Settings.TabIndex = 1;
            Settings.Text = "设置";
            Settings.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(272, 6);
            button6.Name = "button6";
            button6.Size = new Size(253, 71);
            button6.TabIndex = 2;
            button6.Text = "获取QQ号（测试）";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(13, 6);
            button3.Name = "button3";
            button3.Size = new Size(253, 71);
            button3.TabIndex = 0;
            button3.Text = "显示开发控制台";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(13, 6);
            button5.Name = "button5";
            button5.Size = new Size(253, 71);
            button5.TabIndex = 1;
            button5.Text = "隐藏开发控制台";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
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
            tabControl2.Controls.Add(CPSTester);
            tabControl2.Controls.Add(more);
            tabControl2.Location = new Point(0, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(795, 420);
            tabControl2.TabIndex = 0;
            // 
            // CPSTester
            // 
            CPSTester.Controls.Add(clicklabel);
            CPSTester.Controls.Add(timelabel);
            CPSTester.Controls.Add(TimecomboBox);
            CPSTester.Controls.Add(ModeComboBox);
            CPSTester.Controls.Add(CPStestbtn);
            CPSTester.Controls.Add(LogListBox);
            CPSTester.Location = new Point(4, 26);
            CPSTester.Name = "CPSTester";
            CPSTester.Padding = new Padding(3);
            CPSTester.Size = new Size(787, 390);
            CPSTester.TabIndex = 0;
            CPSTester.Text = "CPSTester";
            CPSTester.UseVisualStyleBackColor = true;
            // 
            // clicklabel
            // 
            clicklabel.AutoSize = true;
            clicklabel.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            clicklabel.Location = new Point(335, 30);
            clicklabel.Name = "clicklabel";
            clicklabel.Size = new Size(111, 41);
            clicklabel.TabIndex = 5;
            clicklabel.Text = "label7";
            // 
            // timelabel
            // 
            timelabel.AutoSize = true;
            timelabel.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            timelabel.Location = new Point(32, 30);
            timelabel.Name = "timelabel";
            timelabel.Size = new Size(111, 41);
            timelabel.TabIndex = 4;
            timelabel.Text = "label6";
            // 
            // TimecomboBox
            // 
            TimecomboBox.FormattingEnabled = true;
            TimecomboBox.Location = new Point(32, 88);
            TimecomboBox.Name = "TimecomboBox";
            TimecomboBox.Size = new Size(414, 25);
            TimecomboBox.TabIndex = 3;
            // 
            // ModeComboBox
            // 
            ModeComboBox.FormattingEnabled = true;
            ModeComboBox.Location = new Point(32, 127);
            ModeComboBox.Name = "ModeComboBox";
            ModeComboBox.Size = new Size(414, 25);
            ModeComboBox.TabIndex = 2;
            // 
            // CPStestbtn
            // 
            CPStestbtn.Font = new Font("Microsoft YaHei UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            CPStestbtn.Location = new Point(32, 171);
            CPStestbtn.Name = "CPStestbtn";
            CPStestbtn.Size = new Size(414, 186);
            CPStestbtn.TabIndex = 1;
            CPStestbtn.Text = "button7";
            CPStestbtn.UseVisualStyleBackColor = true;
            // 
            // LogListBox
            // 
            LogListBox.FormattingEnabled = true;
            LogListBox.ItemHeight = 17;
            LogListBox.Items.AddRange(new object[] { "时间记录：" });
            LogListBox.Location = new Point(478, -1);
            LogListBox.Name = "LogListBox";
            LogListBox.Size = new Size(313, 395);
            LogListBox.TabIndex = 0;
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
            // Home
            // 
            Home.Controls.Add(label1);
            Home.Location = new Point(4, 26);
            Home.Name = "Home";
            Home.Size = new Size(795, 419);
            Home.TabIndex = 4;
            Home.Text = "主页";
            Home.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(219, 83);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 450);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Jhacks-NextGen";
            tabControl1.ResumeLayout(false);
            Inject.ResumeLayout(false);
            Inject.PerformLayout();
            Settings.ResumeLayout(false);
            Tools.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            CPSTester.ResumeLayout(false);
            CPSTester.PerformLayout();
            About.ResumeLayout(false);
            About.PerformLayout();
            Home.ResumeLayout(false);
            Home.PerformLayout();
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
        private TextBox BCtextBox1;
        private Button button3;
        private Label label4;
        private Button button4;
        private Label label5;
        private Button button5;
        private TabPage Tools;
        private TabControl tabControl2;
        private TabPage CPSTester;
        private ListBox LogListBox;
        private TabPage more;
        private Button button6;
        private Label clicklabel;
        private Label timelabel;
        private ComboBox TimecomboBox;
        private ComboBox ModeComboBox;
        private Button CPStestbtn;
        private System.Windows.Forms.Timer timer1;
        private TabPage Home;
        private Label label1;
    }
}
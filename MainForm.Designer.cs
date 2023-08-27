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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            Home = new TabPage();
            BCtextBox1 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            jinchenBox = new ComboBox();
            SelectDLLBtn = new Button();
            SelectBox = new ComboBox();
            label1 = new Label();
            Settings = new TabPage();
            button3 = new Button();
            button5 = new Button();
            About = new TabPage();
            label5 = new Label();
            button4 = new Button();
            label4 = new Label();
            openFileDialog1 = new OpenFileDialog();
            tabControl1.SuspendLayout();
            Home.SuspendLayout();
            Settings.SuspendLayout();
            About.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Home);
            tabControl1.Controls.Add(Settings);
            tabControl1.Controls.Add(About);
            tabControl1.Location = new Point(-5, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 449);
            tabControl1.TabIndex = 0;
            // 
            // Home
            // 
            Home.Controls.Add(BCtextBox1);
            Home.Controls.Add(button1);
            Home.Controls.Add(label3);
            Home.Controls.Add(label2);
            Home.Controls.Add(button2);
            Home.Controls.Add(jinchenBox);
            Home.Controls.Add(SelectDLLBtn);
            Home.Controls.Add(SelectBox);
            Home.Controls.Add(label1);
            Home.Location = new Point(4, 26);
            Home.Name = "Home";
            Home.Padding = new Padding(3);
            Home.Size = new Size(795, 419);
            Home.TabIndex = 0;
            Home.Text = "主页";
            Home.UseVisualStyleBackColor = true;
            // 
            // BCtextBox1
            // 
            BCtextBox1.Location = new Point(426, 213);
            BCtextBox1.Multiline = true;
            BCtextBox1.Name = "BCtextBox1";
            BCtextBox1.ReadOnly = true;
            BCtextBox1.Size = new Size(348, 187);
            BCtextBox1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(50, 211);
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
            label3.Location = new Point(13, 165);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 6;
            label3.Text = "要注入的进程：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 129);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 5;
            label2.Text = "要注入的端或DLL：";
            // 
            // button2
            // 
            button2.Location = new Point(662, 168);
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
            jinchenBox.Location = new Point(147, 168);
            jinchenBox.Name = "jinchenBox";
            jinchenBox.Size = new Size(512, 29);
            jinchenBox.TabIndex = 3;
            jinchenBox.Text = "javaw";
            // 
            // SelectDLLBtn
            // 
            SelectDLLBtn.Location = new Point(662, 125);
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
            SelectBox.Location = new Point(147, 125);
            SelectBox.Name = "SelectBox";
            SelectBox.Size = new Size(511, 29);
            SelectBox.TabIndex = 1;
            SelectBox.Text = "Zelix Cracked(1.12.2)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(34, 13);
            label1.Name = "label1";
            label1.Size = new Size(732, 83);
            label1.TabIndex = 0;
            label1.Text = "Jhacks-NextGen V1.0.0";
            // 
            // Settings
            // 
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
            // button3
            // 
            button3.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(265, 44);
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
            button5.Location = new Point(265, 44);
            button5.Name = "button5";
            button5.Size = new Size(253, 71);
            button5.TabIndex = 1;
            button5.Text = "隐藏开发控制台";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Jhacks-NextGen";
            tabControl1.ResumeLayout(false);
            Home.ResumeLayout(false);
            Home.PerformLayout();
            Settings.ResumeLayout(false);
            About.ResumeLayout(false);
            About.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Home;
        private TabPage Settings;
        private TabPage About;
        private ComboBox SelectBox;
        private Label label1;
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
    }
}
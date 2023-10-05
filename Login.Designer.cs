namespace Jhacks_NextGen
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            LoginBtn = new Button();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            linkLabel2 = new LinkLabel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BackgroundImage = Properties.Resources._1680252905141_685636360;
            pictureBox1.ErrorImage = Properties.Resources._1680252905141_685636360;
            pictureBox1.ImageLocation = "";
            pictureBox1.InitialImage = Properties.Resources._1680252905141_685636360;
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(431, 510);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(480, 28);
            label1.Name = "label1";
            label1.Size = new Size(290, 46);
            label1.TabIndex = 1;
            label1.Text = "Jhacks-NextGen";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(505, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(591, 83);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 3;
            label2.Text = "请登录";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(505, 199);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 23);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(444, 144);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 5;
            label3.Text = "账号：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(445, 205);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 6;
            label4.Text = "密码：";
            // 
            // LoginBtn
            // 
            LoginBtn.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            LoginBtn.Location = new Point(480, 317);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(301, 79);
            LoginBtn.TabIndex = 7;
            LoginBtn.Text = "林肯死大头";
            LoginBtn.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(729, 239);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(68, 17);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "忘记密码了";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(519, 297);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 9;
            label5.Text = "没有账号？";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(579, 297);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(173, 17);
            linkLabel2.TabIndex = 10;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "注册新的Jhacks-NextGen账号";
            // 
            // button1
            // 
            button1.Location = new Point(536, 424);
            button1.Name = "button1";
            button1.Size = new Size(179, 42);
            button1.TabIndex = 11;
            button1.Text = "复制HWID";
            button1.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(810, 511);
            Controls.Add(button1);
            Controls.Add(linkLabel2);
            Controls.Add(label5);
            Controls.Add(linkLabel1);
            Controls.Add(LoginBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
        private Button LoginBtn;
        private LinkLabel linkLabel1;
        private Label label5;
        private LinkLabel linkLabel2;
        private Button button1;
    }
}
namespace Jhacks_NextGen
{
    partial class DevConsole
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevConsole));
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            CommandBox = new ListBox();
            CommandTextBox = new TextBox();
            CommandSendTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(308, 0);
            label1.Name = "label1";
            label1.Size = new Size(265, 46);
            label1.TabIndex = 0;
            label1.Text = "开发模式控制台";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // CommandBox
            // 
            CommandBox.FormattingEnabled = true;
            CommandBox.ItemHeight = 17;
            CommandBox.Items.AddRange(new object[] { "Welcome to DevConsole" });
            CommandBox.Location = new Point(0, 49);
            CommandBox.Name = "CommandBox";
            CommandBox.Size = new Size(468, 412);
            CommandBox.TabIndex = 3;
            // 
            // CommandTextBox
            // 
            CommandTextBox.Location = new Point(474, 49);
            CommandTextBox.Multiline = true;
            CommandTextBox.Name = "CommandTextBox";
            CommandTextBox.Size = new Size(371, 368);
            CommandTextBox.TabIndex = 4;
            // 
            // CommandSendTextBox
            // 
            CommandSendTextBox.Location = new Point(474, 428);
            CommandSendTextBox.Name = "CommandSendTextBox";
            CommandSendTextBox.Size = new Size(315, 23);
            CommandSendTextBox.TabIndex = 5;
            CommandSendTextBox.TextChanged += CommandSendTextBox_TextChanged;
            CommandSendTextBox.KeyDown += CommandSendTextBox_KeyDown;
            // 
            // button1
            // 
            button1.Location = new Point(792, 426);
            button1.Name = "button1";
            button1.Size = new Size(52, 26);
            button1.TabIndex = 6;
            button1.Text = "执行";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // DevConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 463);
            Controls.Add(button1);
            Controls.Add(CommandSendTextBox);
            Controls.Add(CommandTextBox);
            Controls.Add(CommandBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DevConsole";
            Text = "DevConsole";
            Load += DevConsole_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private StatusStrip statusStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private ListBox CommandBox;
        private TextBox CommandTextBox;
        private TextBox CommandSendTextBox;
        private Button button1;
    }
}
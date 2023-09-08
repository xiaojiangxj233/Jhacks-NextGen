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
            CommandBox.Size = new Size(848, 327);
            CommandBox.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(352, 397);
            button1.Name = "button1";
            button1.Size = new Size(156, 40);
            button1.TabIndex = 4;
            button1.Text = "重启程序";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DevConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 463);
            Controls.Add(button1);
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
        private Button button1;
    }
}
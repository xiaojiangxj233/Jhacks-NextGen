namespace Jhacks_NextGen
{
    partial class XjauthForm
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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(1, 23);
            webView21.Name = "webView21";
            webView21.Size = new Size(799, 427);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 3);
            label1.Name = "label1";
            label1.Size = new Size(224, 17);
            label1.TabIndex = 1;
            label1.Text = "请先通过人机验证，通过后按下确认按键";
            // 
            // button1
            // 
            button1.Location = new Point(721, 0);
            button1.Name = "button1";
            button1.Size = new Size(79, 22);
            button1.TabIndex = 2;
            button1.Text = "确认";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(636, 0);
            button2.Name = "button2";
            button2.Size = new Size(79, 22);
            button2.TabIndex = 3;
            button2.Text = "刷新";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // XjauthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(webView21);
            Name = "XjauthForm";
            Text = "browser";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}
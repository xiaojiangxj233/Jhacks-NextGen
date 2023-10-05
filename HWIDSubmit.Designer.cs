namespace Jhacks_NextGen
{
    partial class HWIDSubmit
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
            webView21.Location = new Point(2, 23);
            webView21.Name = "webView21";
            webView21.Size = new Size(798, 428);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 3);
            label1.Name = "label1";
            label1.Size = new Size(200, 17);
            label1.TabIndex = 1;
            label1.Text = "请在提示数据提交成功后再点击确定";
            // 
            // button1
            // 
            button1.Location = new Point(623, 0);
            button1.Name = "button1";
            button1.Size = new Size(88, 22);
            button1.TabIndex = 2;
            button1.Text = "刷新";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(712, 0);
            button2.Name = "button2";
            button2.Size = new Size(88, 22);
            button2.TabIndex = 3;
            button2.Text = "确定";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // HWIDSubmit
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(webView21);
            Name = "HWIDSubmit";
            Text = "录入HWID";
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
namespace WebIntegrationApp
{
    partial class Form1
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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            button1 = new Button();
            addressBar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(12, 125);
            webView21.Name = "webView21";
            webView21.Size = new Size(1629, 559);
            webView21.Source = new Uri("https://www.google.com", UriKind.Absolute);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.Click += webView21_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1529, 49);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Aller";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // addressBar
            // 
            addressBar.Location = new Point(12, 51);
            addressBar.Name = "addressBar";
            addressBar.Size = new Size(1511, 23);
            addressBar.TabIndex = 2;
            addressBar.TextChanged += addressBar_TextChanged;
            // 
            // Form1
            // 
            ClientSize = new Size(1646, 693);
            Controls.Add(addressBar);
            Controls.Add(button1);
            Controls.Add(webView21);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button button1;
        private TextBox addressBar;
    }
}

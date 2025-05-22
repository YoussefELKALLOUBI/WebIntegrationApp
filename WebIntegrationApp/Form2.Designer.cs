namespace WebIntegrationApp
{
    partial class Form2
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
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnVisiter = new Button();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Dock = DockStyle.Bottom;
            webView.Location = new Point(0, 58);
            webView.Margin = new Padding(4, 3, 4, 3);
            webView.Name = "webView";
            webView.Size = new Size(1167, 727);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            webView.Click += webView_Click;
            // 
            // btnVisiter
            // 
            btnVisiter.Location = new Point(12, 12);
            btnVisiter.Margin = new Padding(4, 3, 4, 3);
            btnVisiter.Name = "btnVisiter";
            btnVisiter.Size = new Size(175, 35);
            btnVisiter.TabIndex = 1;
            btnVisiter.Text = "Recherche IA";
            btnVisiter.UseVisualStyleBackColor = true;
            btnVisiter.Click += BtnVisiter_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 785);
            Controls.Add(btnVisiter);
            Controls.Add(webView);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form2";
            Text = "Navigation W3Schools - WebView2";
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Button btnVisiter;
    }
}
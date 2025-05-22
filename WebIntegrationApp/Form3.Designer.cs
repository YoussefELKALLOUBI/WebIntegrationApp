namespace WebIntegrationApp
{
    partial class Form3
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
            btnRechercheIA = new Button();
            webView2RechercheIA = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView2RechercheIA).BeginInit();
            SuspendLayout();
            // 
            // btnRechercheIA
            // 
            btnRechercheIA.Location = new Point(26, 25);
            btnRechercheIA.Name = "btnRechercheIA";
            btnRechercheIA.Size = new Size(132, 42);
            btnRechercheIA.TabIndex = 0;
            btnRechercheIA.Text = "Recherche IA";
            btnRechercheIA.UseVisualStyleBackColor = true;
            btnRechercheIA.Click += btnRechercheIA_Click_1;
            // 
            // webView2RechercheIA
            // 
            webView2RechercheIA.AllowExternalDrop = true;
            webView2RechercheIA.CreationProperties = null;
            webView2RechercheIA.DefaultBackgroundColor = Color.White;
            webView2RechercheIA.Location = new Point(26, 105);
            webView2RechercheIA.Name = "webView2RechercheIA";
            webView2RechercheIA.Size = new Size(1183, 557);
            webView2RechercheIA.TabIndex = 1;
            webView2RechercheIA.ZoomFactor = 1D;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 706);
            Controls.Add(webView2RechercheIA);
            Controls.Add(btnRechercheIA);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)webView2RechercheIA).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnRechercheIA;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2RechercheIA;
    }
}
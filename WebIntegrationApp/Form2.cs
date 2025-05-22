using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace WebIntegrationApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            // Initialiser le CoreWebView2 avec un environnement par défaut
            await webView.EnsureCoreWebView2Async(null);

            // Limitation des fonctionnalités du navigateur
            webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView.CoreWebView2.Settings.IsStatusBarEnabled = false;

            // Configurer les événements après l'initialisation 
            webView.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

            // Événement pour intercepter l'ouverture de nouvelles fenêtres
            webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }

        private void BtnVisiter_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.Navigate("https://www.w3schools.com/");
            }
        }

        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            // Vérifier si l'URL de destination est dans le domaine w3schools.com
            Uri uri;
            if (Uri.TryCreate(e.Uri, UriKind.Absolute, out uri))
            {
                if (!uri.Host.EndsWith("w3schools.com"))
                {
                    // Annuler la navigation si ce n'est pas w3schools.com
                    e.Cancel = true;
                    MessageBox.Show("Navigation limitée au domaine w3schools.com uniquement.",
                                    "Navigation restreinte : NavigationStarting",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Rediriger vers la page d'accueil de w3schools.com
                    webView.CoreWebView2.Navigate("https://www.w3schools.com/");
                }
            }
        }

        // Intercepter les demandes d'ouverture de nouvelle fenêtre
        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Annuler l'ouverture de la nouvelle fenêtre
            e.Handled = true;

            // Vérifier si l'URL est dans w3schools.com
            Uri uri;
            if (Uri.TryCreate(e.Uri, UriKind.Absolute, out uri) && uri.Host.EndsWith("w3schools.com"))
            {
                // Rediriger vers la même WebView plutôt que d'ouvrir une nouvelle fenêtre
                webView.CoreWebView2.Navigate(e.Uri);
            }
            else
            {
                // Si ce n'est pas w3schools.com, informer l'utilisateur et ne pas naviguer
                MessageBox.Show("Navigation limitée au domaine w3schools.com uniquement.",
                                "Navigation restreinte : NewWindowRequested",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void webView_Click(object sender, EventArgs e)
        {

        }
    }
}
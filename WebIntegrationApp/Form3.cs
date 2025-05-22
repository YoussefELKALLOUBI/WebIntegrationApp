using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebIntegrationApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            InitializeAsync();
        }
        async void InitializeAsync()
        {
            await webView2RechercheIA.EnsureCoreWebView2Async(null);

            // Limitation des fonctionnalités du navigateur
            webView2RechercheIA.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView2RechercheIA.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView2RechercheIA.CoreWebView2.Settings.IsStatusBarEnabled = false;

            // Configurer les événements après l'initialisation 
            webView2RechercheIA.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;

            // Événement pour intercepter l'ouverture de nouvelles fenêtres
            webView2RechercheIA.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }


        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            // Vérifier le domaine de destination
            Uri uri;
            if (Uri.TryCreate(e.Uri, UriKind.Absolute, out uri))
            {
                if (!uri.Host.EndsWith("w3schools.com"))
                {
                    // Annuler la navigation si ce n'est pas le bon domaine
                    e.Cancel = true;
                    MessageBox.Show("Navigation limitée au domaine X uniquement.",
                                    "Navigation restreinte : NavigationStarting",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Rediriger vers la page d'accueil de w3schools.com
                    webView2RechercheIA.CoreWebView2.Navigate("https://www.w3schools.com/");
                }
            }
        }

        // Intercepter les demandes d'ouverture de nouvelle fenêtre
        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Annuler l'ouverture de la nouvelle fenêtre
            e.Handled = true;

            // Vérifier le domaine de destination
            Uri uri;
            if (Uri.TryCreate(e.Uri, UriKind.Absolute, out uri) && uri.Host.EndsWith("w3schools.com"))
            {
                // Rediriger vers la même WebView plutôt que d'ouvrir une nouvelle fenêtre
                webView2RechercheIA.CoreWebView2.Navigate(e.Uri);
            }
            else
            {
                // Si ce n'est pas w3schools.com, informer l'utilisateur et ne pas naviguer
                MessageBox.Show("Navigation limitée au domaine X uniquement.",
                                "Navigation restreinte : NewWindowRequested",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void btnRechercheIA_Click_1(object sender, EventArgs e)
        {
            if (webView2RechercheIA != null && webView2RechercheIA.CoreWebView2 != null)
            {
                webView2RechercheIA.CoreWebView2.Navigate("https://www.w3schools.com/");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Dans le constructeur du formulaire ou dans Form_Load
            webView2RechercheIA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }
    }
}

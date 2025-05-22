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
        private const string ALLOWED_DOMAIN = "w3schools.com";
        private const string DEFAULT_URL = "https://www.w3schools.com/";
        private const string RESTRICTION_MESSAGE = "Navigation limitée au domaine "+ ALLOWED_DOMAIN + " uniquement.";

        public Form3()
        {
            InitializeComponent();
            InitializeAsync();
        }
        async void InitializeAsync()
        {
            try
            {
                await webView2RechercheIA.EnsureCoreWebView2Async(null);
                ConfigureWebView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur d'initialisation WebView2: {ex.Message}",
                               "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureWebView()
        {
            var settings = webView2RechercheIA.CoreWebView2.Settings;
            settings.AreDevToolsEnabled = false;
            settings.AreDefaultContextMenusEnabled = false;
            settings.IsStatusBarEnabled = false;
            
            //settings.IsWebMessageEnabled = false;
            //settings.AreDefaultScriptDialogsEnabled = false;

            // Événements
            webView2RechercheIA.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            webView2RechercheIA.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }

        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (!IsAllowedDomain(e.Uri))
            {
                e.Cancel = true;
                ShowRestrictionMessage("NavigationStarting");
                NavigateToDefault();
            }
        }

        // Intercepter les demandes d'ouverture de nouvelle fenêtre
        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Annuler l'ouverture de la nouvelle fenêtre
            e.Handled = true;

            // Vérifier si le domaine de destination est autorisé
            if (IsAllowedDomain(e.Uri))
            {
                // Rediriger vers la même WebView plutôt que d'ouvrir une nouvelle fenêtre
                webView2RechercheIA.CoreWebView2.Navigate(e.Uri);
            }
            else
            {
                // Si ce n'est pas le domaine autorisé, informer l'utilisateur
                ShowRestrictionMessage("NewWindowRequested");
            }
        }

        private void ShowRestrictionMessage(string context)
        {
            MessageBox.Show(RESTRICTION_MESSAGE,
                           $"Navigation restreinte : {context}",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsAllowedDomain(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uri) &&
                   uri.Host.EndsWith(ALLOWED_DOMAIN, StringComparison.OrdinalIgnoreCase);
        }

        private void NavigateToDefault()
        {
            webView2RechercheIA.CoreWebView2?.Navigate(DEFAULT_URL);
        }

        private void btnRechercheIA_Click_1(object sender, EventArgs e)
        {
            if (webView2RechercheIA != null && webView2RechercheIA.CoreWebView2 != null)
            {
                NavigateToDefault();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Dans le constructeur du formulaire ou dans Form_Load
            webView2RechercheIA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }
    }
}

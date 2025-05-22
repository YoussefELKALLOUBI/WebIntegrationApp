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
        // Configuration des restrictions de navigation
        private const string ALLOWED_DOMAIN = "w3schools.com";
        private const string RESTRICTION_MESSAGE = "Navigation limitée au domaine " + ALLOWED_DOMAIN + " uniquement.";
        
        private const string BASE_URL = "https://www.w3schools.com/";
        private readonly string _username;
        
        // Encode les caractères spéciaux du username pour éviter de casser l'URL
        private string DEFAULT_URL => $"{BASE_URL}?username={Uri.EscapeDataString(_username)}";

        public Form3(string username = "anonymous")
        {
            _username = string.IsNullOrWhiteSpace(username) ? "anonymous" : username;
            InitializeComponent();
            InitializeAsync();
        }

        /// <summary>
        /// Initialise de manière asynchrone le composant WebView2
        /// </summary>
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

        /// <summary>
        /// Configure les paramètres de sécurité et les gestionnaires d'événements du WebView2
        /// </summary>
        private void ConfigureWebView()
        {
            var settings = webView2RechercheIA.CoreWebView2.Settings;

            // Désactiver les outils de développement et menus contextuels
            settings.AreDevToolsEnabled = false;
            settings.AreDefaultContextMenusEnabled = false;
            settings.IsStatusBarEnabled = false;

            // Attacher les gestionnaires d'événements pour contrôler la navigation
            webView2RechercheIA.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;            
            webView2RechercheIA.CoreWebView2.NavigationStarting += (s, e) => {
                btnRechercheIA.Text = "Chargement...";
                btnRechercheIA.Enabled = false;
            };

            webView2RechercheIA.CoreWebView2.NavigationCompleted += (s, e) => {
                btnRechercheIA.Text = "Nouvelle recherche IA ✨";
                btnRechercheIA.Enabled = true;
            };

            webView2RechercheIA.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;

        }

        /// <summary>
        /// Contrôle la navigation et bloque les domaines non autorisés
        /// </summary>
        private void CoreWebView2_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (!IsAllowedDomain(e.Uri))
            {
                e.Cancel = true;
                ShowRestrictionMessage("NavigationStarting");
                NavigateToDefault();
            }
        }

        /// <summary>
        /// Intercepte les demandes d'ouverture de nouvelle fenêtre et les redirige dans la WebView actuelle
        /// </summary>
        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;

            if (IsAllowedDomain(e.Uri))
            {
                // Rediriger dans la même WebView au lieu d'ouvrir une nouvelle fenêtre
                webView2RechercheIA.CoreWebView2.Navigate(e.Uri);
            }
            else
            {
                ShowRestrictionMessage("NewWindowRequested");
            }
        }

        /// <summary>
        /// Affiche un message d'information sur les restrictions de navigation
        /// </summary>
        private void ShowRestrictionMessage(string context)
        {
            MessageBox.Show(RESTRICTION_MESSAGE,
                           $"Navigation restreinte : {context}",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Vérifie si l'URL appartient au domaine autorisé
        /// </summary>
        private bool IsAllowedDomain(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uri) &&
                   uri.Host.EndsWith(ALLOWED_DOMAIN, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Navigue vers l'URL par défaut
        /// </summary>
        private void NavigateToDefault()
        {
            webView2RechercheIA.CoreWebView2?.Navigate(DEFAULT_URL);
        }

        /// <summary>
        /// Gestionnaire du clic sur le bouton de recherche IA
        /// </summary>
        private void btnRechercheIA_Click_1(object sender, EventArgs e)
        {
            btnRechercheIA.Text = "Nouvelle recherche IA ✨";
            if (webView2RechercheIA?.CoreWebView2 != null)
            {
                NavigateToDefault();
            }
        }

        /// <summary>
        /// Configure l'ancrage du WebView2 lors du chargement du formulaire
        /// </summary>
        private void Form3_Load(object sender, EventArgs e)
        {
            webView2RechercheIA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            StyleButton();
        }
        private void StyleButton()
        {
            btnRechercheIA.BackColor = Color.FromArgb(114, 137, 218);
            btnRechercheIA.ForeColor = Color.White;
        }
    }
}
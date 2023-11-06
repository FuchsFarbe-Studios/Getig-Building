// Getig-Building
// LanguageConstruction.xaml.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 05-11-2023

using System.Windows;
using System.Windows.Controls;
using Getig.Models.Lang;
using Getig.WinApp.Pages.Language;

namespace Getig.WinApp
{
    public partial class LanguageConstruction : Page
    {
        public LanguageConstruction()
        {
            InitializeComponent();
        }

        private void OnCreateLanguage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateLanguage());
        }
    }
}
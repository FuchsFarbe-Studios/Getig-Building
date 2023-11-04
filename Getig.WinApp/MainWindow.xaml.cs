using System.Windows;

namespace Getig.WinApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void HandleLanguageSubmit(object sender, RoutedEventArgs e)
        {
            // LanguageService _service = new LanguageService(yourDbContext);
            // var createdLanguage = await _service.AddLanguageAsync(new Language { Name = txtLanguageName.Text });
        }
    }
}

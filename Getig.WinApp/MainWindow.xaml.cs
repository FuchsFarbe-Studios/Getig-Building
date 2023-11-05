using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Getig.Models.Lang;
using Getig.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Getig.WinApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GetigDbContext _context;
        private List<Models.Lang.ConLang> _conLangs;

        public string TxtResult { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(assemblyFolder).FullName).FullName).FullName).FullName;
            string dbRelativePath = @"Getig.Services\Data\GetigDb.accdb";
            string dbPath = Path.Combine(solutionFolder, dbRelativePath);
            _context = new GetigDbContext(dbPath);
            _conLangs = new List<ConLang>(); _conLangs = await _context.Languages.ToListAsync();
        }

        private void HandleLanguageSubmit(object sender, RoutedEventArgs e)
        {
            TxtResult = $"Hello {TxtLanguageName.Text}";
            MessageBox.Show("Hello World! I am Getig." + "\n" + $"{TxtResult}");
            foreach (var lang in _conLangs)
            {
                MessageBox.Show(lang.Name);
            }
        }

        private void OnClosing(object? sender, CancelEventArgs e)
        {
            _context.Dispose();
            base.OnClosing(e);
        }
    }
}
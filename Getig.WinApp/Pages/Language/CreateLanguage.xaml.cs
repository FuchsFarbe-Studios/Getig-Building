// Getig-Building
// CreateLanguage.xaml.cs
// FuchsFarbe Studios 2023
// Oliver MacDougall
// Modified: 06-11-2023

using System.IO;
using System.Reflection;
using System.Windows.Controls;
using Getig.Models.Lang;
using Getig.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace Getig.WinApp.Pages.Language
{
    public partial class CreateLanguage : Page
    {
        private GetigDbContext _context;


        public CreateLanguage()
        {
            InitializeComponent();
            InitializeDbContext();
        }

        private async void CreateLanguageAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            var conLang = new ConLang { };
            await _context.Languages.AddAsync(conLang);
            _context.SaveChanges();
        }

        private void InitializeDbContext()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(assemblyFolder).FullName).FullName).FullName).FullName;
            string dbRelativePath = @"Getig.Services\Data\GetigDb.accdb";
            string dbPath = Path.Combine(solutionFolder, dbRelativePath);
            _context = new GetigDbContext(dbPath);
        }
    }
}
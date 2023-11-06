using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
        private List<ConLang> _conLangs;

        public string TxtResult { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(assemblyFolder).FullName).FullName).FullName).FullName;
            string dbRelativePath = @"Getig.Services\Data\GetigDb.accdb";
            string dbPath = Path.Combine(solutionFolder, dbRelativePath);
            _context = new GetigDbContext(dbPath);

            LblTitle.Content = "Getig" + "\n" + "Home";
            DisplayFrame.Source = new Uri("Pages/Home.xaml", UriKind.Relative);
        }

        private async void LoadLanguages(object sender, RoutedEventArgs e)
        {
            // LangList.Items.Clear();
            // _conLangs = new List<ConLang>(); _conLangs = await _context.Languages.ToListAsync();
            // _conLangs.ForEach(x =>
            //                   {
            //                       LangList.Items.Add(x.Name);
            //                   });
        }

        private async void HandleLanguageSubmit(object sender, RoutedEventArgs e)
        {
            // TxtResult = $"Hello {TxtLanguage.Text}";
            // MessageBox.Show("Hello World! I am Getig." + "\n" + $"{TxtResult}");
            // var conLang = new ConLang { Name = TxtLanguage.Text, };
            // await _context.Languages.AddAsync(conLang);
            // _context.SaveChanges();
        }

        private void btnLangPage_Click(object sender, RoutedEventArgs e)
        {
            LblTitle.Content = "Getig" + "\n" + "Languages";
            DisplayFrame.Source = new Uri("Pages/LanguageConstruction.xaml", UriKind.Relative);
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            LblTitle.Content = "Getig" + "\n" + "Home";
            DisplayFrame.Source = new Uri("Pages/Home.xaml", UriKind.Relative);
        }

        private void OnClosed(object sender, EventArgs e)
        {
            _context.Dispose();
        }
    }
}
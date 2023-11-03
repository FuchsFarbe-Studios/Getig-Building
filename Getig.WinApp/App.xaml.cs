using System.Diagnostics;
using System.Windows;

namespace Getig.WinApp
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var consoleApp = StartConsoleApplication();
            if (consoleApp == null)
                MessageBox.Show("Could not start console application");
            //   Shutdown();
            else
            {
                consoleApp.WaitForExit();
                MessageBox.Show("Console closed");
                // Shutdown();
            }
        }

        public Process? StartConsoleApplication()
        {
            // Starts up the console application in Getig.Services assembly

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "Getig.Services.exe";
            startInfo.WorkingDirectory = @"..\..\..\Getig.Services\bin\Debug";
            return Process.Start(startInfo);
        }
    }
}

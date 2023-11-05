// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Getig.Services.Data;
internal class Program
{
    public static void Main(string[] args)
    {
        string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string solutionFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(assemblyFolder).FullName).FullName).FullName;
        string dbRelativePath = @"Data\GetigDb.accdb";
        string dbPath = Path.Combine(solutionFolder, dbRelativePath);
        Console.WriteLine(dbPath);

        DbTest(dbPath);
    }
    private async static void DbTest(string dbPath)
    {

        var db = new GetigDbContext(dbPath);
        await db.Database.EnsureCreatedAsync();
    }
}
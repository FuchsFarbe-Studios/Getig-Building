// See https://aka.ms/new-console-template for more information
using Getig.Services.Data;
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        DbTest();
    }
    private async static void DbTest()
    {

        var db = new GetigDbContext();
        await db.Database.EnsureCreatedAsync();
    }
}

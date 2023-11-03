// See https://aka.ms/new-console-template for more information
using Getig.Services.Data;
internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var db = new GetigDbContext();
    }
}

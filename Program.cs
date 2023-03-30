using System;
using System.IO;

using BudgetDjinni.Database.Schemas;

namespace BudgetDjinni
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(Database.Manager.DatabaseFilePath))
            {
                File.Delete(Database.Manager.DatabaseFilePath);
            }

            Console.WriteLine("> Opening database...");
            Database.Manager.Instance.OpenOrCreateDatabase();
            Console.WriteLine("> Database opened!\n");

            Console.WriteLine("> Closing database...");
            Database.Manager.Instance.CloseDatabase();
            Console.WriteLine("> Database closed!\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}

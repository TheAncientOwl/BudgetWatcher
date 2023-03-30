using System;
using System.IO;

using BudgetDjinni.Database.Schemas;

namespace BudgetDjinni
{
    internal class Program
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

            Income income1 = new Income("Salariu", 4000);
            income1.Save();
            Console.WriteLine(income1);

            Income income2 = new Income(income1.Id);
            income2.Name = "Chirii";
            income2.Value = 5000;
            income2.Update();
            Console.WriteLine(income2);

            Income income3 = new Income(income1.Id);
            Console.WriteLine(income3);
            income3.Delete();

            try
            {
                Income income4 = new Income(income1.Id);
                Console.WriteLine(income4);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("> Closing database...");
            Database.Manager.Instance.CloseDatabase();
            Console.WriteLine("> Database closed!\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}

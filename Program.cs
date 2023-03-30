using System;
using System.IO;

using BudgetDjinni.Database.Schemas;
using BudgetDjinni.Forms;

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

            Database.Manager.Instance.OpenOrCreateDatabase();

            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();

            Database.Manager.Instance.CloseDatabase();
        }
    }
}

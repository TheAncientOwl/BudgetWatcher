using System.IO;

using BudgetWatcher.Forms;

namespace BudgetWatcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.Manager.Instance.OpenOrCreateDatabase();

            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();

            Database.Manager.Instance.CloseDatabase();
        }
    }
}

using System;
using System.Threading;
using System.Windows.Forms;

using BudgetWatcher.Forms;
using BudgetWatcher.Forms.Feedback;

namespace BudgetWatcher
{
    public class Program
    {
        static readonly MainForm mainForm = new MainForm();

        static readonly LoadingScreenForm loadingScreenForm = new LoadingScreenForm();
        static Thread loadingScreenThread = null;

        static void Main(string[] args)
        {
            Database.Manager.Instance.OnDatabaseLoad += OpenLoadingScreen;

            Database.Manager.Instance.OnDatabaseLoaded += CloseLoadingScreen;
            Database.Manager.Instance.OnDatabaseLoaded += OpenMainForm;

            mainForm.FormClosing += TerminateApp;

            Database.Manager.Instance.OpenOrCreateDatabase();
        }

        public static void TerminateApp(Object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Sigur doriți să închideți aplicația?", "Confirmă închiderea aplicației",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Database.Manager.Instance.CloseDatabase();
                    Environment.Exit(0);
                }
            }
        }

        public static void OpenMainForm() => mainForm.ShowDialog();

        public static void OpenLoadingScreen()
        {
            loadingScreenThread = new Thread(() =>
            {
                loadingScreenForm.ShowDialog();
            });

            loadingScreenThread.Start();
        }

        public static void CloseLoadingScreen()
        {
            loadingScreenForm.Invoke(new Action(loadingScreenForm.Close));
        }
    }
}

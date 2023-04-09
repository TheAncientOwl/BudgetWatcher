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

        static readonly LoadingScreenForm loadingScreenForm = new LoadingScreenForm("Se încarcă baza de date...");
        static Thread loadingScreenThread = null;

        [STAThread]
        static void Main(string[] args)
        {
            Database.Manager.Instance.OnDatabaseLoad += OpenLoadingScreen;

            Database.Manager.Instance.OnDatabaseLoaded += CloseLoadingScreen;
            Database.Manager.Instance.OnDatabaseLoaded += OpenMainForm;

            mainForm.FormClosing += TerminateApp;

            Database.Manager.Instance.OpenOrCreateDatabase();
        }

        public static void TerminateApp(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Utils.ShowQuestionBox("Sigur doriți să închideți aplicația?") == DialogResult.No)
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

        public static void OpenMainForm()
        {
            if (!IsFormOpen(mainForm.Name))
            {
                mainForm.ShowDialog();
            }
        }

        private static bool IsFormOpen(string formName)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == formName || form.Text == formName)
                {
                    return true;
                }
            }
            return false;
        }

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
            if (loadingScreenForm.IsHandleCreated)
            {
                loadingScreenForm.Invoke(new Action(loadingScreenForm.Close));
            }
        }
    }
}

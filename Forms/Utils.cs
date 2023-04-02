using System.Windows.Forms;

namespace BudgetWatcher.Forms
{
    public class Utils
    {
        public static void ShowInfoMessageBox(string message) => MessageBox.Show(message, "BudgetWatcher - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static DialogResult ShowQuestionBox(string question) => MessageBox.Show(question, "BudgetWatcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }
}


using System.Windows.Forms;

namespace BudgetWatcher.Forms
{
    public class Utils
    {
        public static void ShowInfoMessageBox(string message) => MessageBox.Show(message, "BudgetWatcher - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

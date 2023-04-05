using System.Windows.Forms;

namespace BudgetWatcher.Forms.Feedback
{
    public partial class LoadingScreenForm : Form
    {
        public LoadingScreenForm(string text)
        {
            InitializeComponent();

            loadingLabel.Text = text;
        }
    }
}

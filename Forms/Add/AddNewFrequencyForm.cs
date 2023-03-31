using System.Windows.Forms;

namespace BudgetWatcher.Forms.Add
{
    public partial class AddNewFrequencyForm : Form
    {
        public AddNewFrequencyForm()
        {
            InitializeComponent();
        }

        public string NameData { get => NameTextBox.Text.Length == 0 ? "NewFrequency" : NameTextBox.Text; }
        public int DaysData { get => (int)DaysUpDown.Value; }
    }
}

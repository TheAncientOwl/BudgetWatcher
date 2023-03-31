using System.Windows.Forms;

namespace BudgetWatcher.Forms.Add
{
    public partial class AddNewFrequencyForm : Form
    {
        public AddNewFrequencyForm()
        {
            InitializeComponent();
        }

        public string NameData { get => NameTextBox.Text; }
        public int DaysData { get => (int)DaysUpDown.Value; }
    }
}

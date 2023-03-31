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

        private void NameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

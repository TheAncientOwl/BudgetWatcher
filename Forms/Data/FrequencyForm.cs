using System.Windows.Forms;

namespace BudgetWatcher.Forms.Data
{
    public partial class FrequencyForm : Form
    {
        public FrequencyForm()
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

using BudgetWatcher.Database.Schemas;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.Data
{
    public partial class FrequencyForm : Form
    {
        public FrequencyForm(string formTitle, ExpenseFrequency defaultFrequency)
        {
            InitializeComponent();

            Text = formTitle;

            NameTextBox.Text = defaultFrequency.Name;
            DaysUpDown.Value = defaultFrequency.Days;
        }

        public void FillInData(ExpenseFrequency frequency)
        {
            frequency.Name = NameTextBox.Text;
            frequency.Days= (int)DaysUpDown.Value;
        }

        private void NameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

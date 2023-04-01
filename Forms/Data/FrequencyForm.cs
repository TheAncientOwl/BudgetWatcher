using BudgetWatcher.Database.Schemas;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.Data
{
    public partial class FrequencyForm : Form, IDatabaseObjectFiller<ExpenseFrequency>, ISetDefaultFormProperties<ExpenseFrequency>
    {
        public FrequencyForm()
        {
            InitializeComponent();
        }

        public void FillInData(ExpenseFrequency frequency)
        {
            frequency.Name = NameTextBox.Text;
            frequency.Days= (int)DaysUpDown.Value;
        }

        public void SetDefaultFormProperties(string formTitle, ExpenseFrequency defaultFrequency)
        {
            Text = formTitle;

            NameTextBox.Text = defaultFrequency.Name;
            DaysUpDown.Value = defaultFrequency.Days;
        }

        private void NameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

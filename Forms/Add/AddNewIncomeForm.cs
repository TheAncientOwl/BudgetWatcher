using System;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.Add
{
    public partial class AddNewIncomeForm : Form
    {
        public AddNewIncomeForm()
        {
            InitializeComponent();
        }

        public string NameData { get => NameTextBox.Text; }
        public double ValueData { get => (double)ValueUpDown.Value; }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

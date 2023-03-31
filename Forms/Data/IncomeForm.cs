using System;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.Data
{
    public partial class IncomeForm : Form
    {
        public IncomeForm()
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

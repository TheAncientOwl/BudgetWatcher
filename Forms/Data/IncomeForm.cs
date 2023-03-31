using System;
using System.Windows.Forms;

using BudgetWatcher.Database.Schemas;

namespace BudgetWatcher.Forms.Data
{
    public partial class IncomeForm : Form
    {
        public IncomeForm(string formTitle, Income defaultIncome)
        {
            InitializeComponent();

            Text = formTitle;

            NameTextBox.Text = defaultIncome.Name;
            ValueUpDown.Value = (decimal)defaultIncome.Value;
        }

        public void FillInData(Income income)
        {
            income.Name = NameTextBox.Text;
            income.Value = (double)ValueUpDown.Value;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

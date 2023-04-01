using System;
using System.Windows.Forms;

using BudgetWatcher.Database.Schemas;

namespace BudgetWatcher.Forms.Data
{
    public partial class IncomeForm : Form, IDatabaseObjectFiller<Income>, ISetDefaultFormProperties<Income>
    {
        public IncomeForm()
        {
            InitializeComponent();
        }

        public void FillInData(Income income)
        {
            income.Name = NameTextBox.Text;
            income.Value = (double)ValueUpDown.Value;
        }

        public void SetDefaultFormProperties(string formTitle, Income defaultIncome)
        {
            Text = formTitle;

            NameTextBox.Text = defaultIncome.Name;
            ValueUpDown.Value = (decimal)defaultIncome.Value;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

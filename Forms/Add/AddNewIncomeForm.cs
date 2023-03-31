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

        public string NameData { get => NameTextBox.Text.Length == 0 ? "NewIncome" : NameTextBox.Text; }
        public double ValueData { get => (double)ValueUpDown.Value; }
    }
}

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
    }
}

using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Add;
using System;
using System.Windows.Forms;

namespace BudgetWatcher.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowInfoMessageBox(string message) => MessageBox.Show(message, "BudgetWatcher - Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void Button_OpenAddIncomeForm_Click(object sender, EventArgs e)
        {
            AddNewIncomeForm form = new AddNewIncomeForm();
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                Income newIncome = new Income(form.NameData, form.ValueData);
                newIncome.Insert();

                ShowInfoMessageBox("Venit adăugat cu succes!");
            }
        }

        private void Button_OpenAddNewCategoryForm_Click(object sender, EventArgs e)
        {
            AddNewCategoryForm form = new AddNewCategoryForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ExpenseCategory expenseCategory = new ExpenseCategory(form.NameData, form.DescriptionData);
                expenseCategory.Insert();

                ShowInfoMessageBox("Categorie adăugată cu succes!");
            }
        }

        private void Button_OpenAddNewFrequencyForm_Click(object sender, EventArgs e)
        {
            AddNewFrequencyForm form = new AddNewFrequencyForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ExpenseFrequency expenseFrequency = new ExpenseFrequency(form.NameData, form.DaysData);
                expenseFrequency.Insert();

                ShowInfoMessageBox("Frecvență adăugată cu succes!");
            }
        }

        private void Button_OpenAddNewExpenseForm_Click(object sender, EventArgs e)
        {
            AddNewExpenseForm form = new AddNewExpenseForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Expense expense = new Expense(form.NameData, form.ValueData, form.DateData, form.DetailsData, form.CategoryIdData, form.FrequencyIdData);
                
                expense.Insert();

                ShowInfoMessageBox("Cheltuială adăugată cu succes!");
            }
        }
    }
}

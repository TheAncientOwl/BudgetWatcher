using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Add;
using BudgetWatcher.Forms.Feedback;
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

        private void ShowInfo(string message)
        {
            InfoForm infoForm = new InfoForm(message);

            if (infoForm.ShowDialog() == DialogResult.OK)
            {
                infoForm.Close();
            }
        }

        private void Button_OpenAddIncomeForm_Click(object sender, EventArgs e)
        {
            AddNewIncomeForm form = new AddNewIncomeForm();
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                Income newIncome = new Income(form.NameData, form.ValueData);
                newIncome.Insert();

                ShowInfo("Venit adăugat cu succes!");
            }
        }

        private void Button_OpenAddNewCategoryForm_Click(object sender, EventArgs e)
        {
            AddNewCategoryForm form = new AddNewCategoryForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ExpenseCategory expenseCategory = new ExpenseCategory(form.NameData, form.DescriptionData);
                expenseCategory.Insert();

                ShowInfo("Categorie adăugată cu succes!");
            }
        }

        private void Button_OpenAddNewFrequencyForm_Click(object sender, EventArgs e)
        {
            AddNewFrequencyForm form = new AddNewFrequencyForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ExpenseFrequency expenseFrequency = new ExpenseFrequency(form.NameData, form.DaysData);
                expenseFrequency.Insert();

                ShowInfo("Frecvență adăugată cu succes!");
            }
        }

        private void Button_OpenAddNewExpenseForm_Click(object sender, EventArgs e)
        {
            AddNewExpenseForm form = new AddNewExpenseForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Expense expense = new Expense(form.NameData, form.ValueData, form.DateData, form.DetailsData, form.CategoryIdData, form.FrequencyIdData);
                
                expense.Insert();

                ShowInfo("Cheltuială adăugată cu succes!");
            }
        }
    }
}

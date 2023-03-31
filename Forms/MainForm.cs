using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;
using BudgetWatcher.Forms.List;
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
            Income newIncome = new Income();
            IncomeForm form = new IncomeForm("Adaugă un venit nou", newIncome);
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.FillInData(newIncome);
                newIncome.Insert();

                ShowInfoMessageBox("Venit adăugat cu succes!");
            }
        }

        private void Button_OpenAddNewCategoryForm_Click(object sender, EventArgs e)
        {
            ExpenseCategory newCategory = new ExpenseCategory();
            CategoryForm form = new CategoryForm("Adăugați o categorie nouă", newCategory);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.FillInData(newCategory);
                newCategory.Insert();

                ShowInfoMessageBox("Categorie adăugată cu succes!");
            }
        }

        private void Button_OpenAddNewFrequencyForm_Click(object sender, EventArgs e)
        {
            ExpenseFrequency newFrequency = new ExpenseFrequency();
            FrequencyForm form = new FrequencyForm("Adăugați o frecvență nouă", newFrequency);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.FillInData(newFrequency);
                newFrequency.Insert();

                ShowInfoMessageBox("Frecvență adăugată cu succes!");
            }
        }

        private void Button_OpenAddNewExpenseForm_Click(object sender, EventArgs e)
        {
            Expense newExpense = new Expense();
            ExpenseForm form = new ExpenseForm("Adăugați o cheltuială nouă", newExpense);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.FillInData(newExpense);
                newExpense.Insert();

                ShowInfoMessageBox("Cheltuială adăugată cu succes!");
            }
        }

        private void Button_ListIncomes_Click(object sender, EventArgs e)
        {
            ListIncomesForm form = new ListIncomesForm();

            form.ShowDialog();
        }
    }
}

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
    }
}

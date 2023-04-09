using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;
using BudgetWatcher.Forms.Generate;
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

        #region Open Add Forms Button Click
        private void Button_OpenAddForm_Click<DbObject, DataForm>(string formTitle, string successMessage)
            where DbObject : IDatabaseObject, new()
            where DataForm : Form, IDatabaseObjectFiller<DbObject>, ISetDefaultFormProperties<DbObject>, new()
        {
            DbObject newDbObject = new DbObject();
            DataForm form = new DataForm();

            form.SetDefaultFormProperties(formTitle, newDbObject);

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.FillInData(newDbObject);
                newDbObject.Insert();

                Utils.ShowInfoMessageBox(successMessage);
            }
        }

        private void Button_OpenAddIncomeForm_Click(object sender, EventArgs e)
            => Button_OpenAddForm_Click<Income, IncomeForm>("Adaugă un venit nou", "Venit adăugat cu succes!");

        private void Button_OpenAddNewCategoryForm_Click(object sender, EventArgs e)
            => Button_OpenAddForm_Click<ExpenseCategory, CategoryForm>("Adaugă o categorie nouă", "Categorie adăugată cu succes!");

        private void Button_OpenAddNewFrequencyForm_Click(object sender, EventArgs e)
            => Button_OpenAddForm_Click<ExpenseFrequency, FrequencyForm>("Adăugă o frecvență nouă", "Frecvență adăugată cu succes!");

        private void Button_OpenAddNewExpenseForm_Click(object sender, EventArgs e)
            => Button_OpenAddForm_Click<Expense, ExpenseForm>("Adaugă cheltuială nouă", "Cheltuială adăugată cu succes!");
        #endregion Open Add Forms Button Click

        #region List Button Click
        private void Button_List_Click<ListForm>() where ListForm : Form, new()
        {
            ListForm form = new ListForm();

            form.ShowDialog();
        }

        private void Button_ListIncomes_Click(object sender, EventArgs e) => Button_List_Click<ListIncomesForm>();
        private void Button_ListCategories_Click(object sender, EventArgs e) => Button_List_Click<ListCategoriesForm>();
        private void Button_ListFrequencies_Click(object sender, EventArgs e) => Button_List_Click<ListFrequenciesForm>();
        private void Button_ListExpenses_Click(object sender, EventArgs e) => Button_List_Click<ListExpensesForm>();
        #endregion List Button Click

        private void Button_GenerateHistory_Click(object sender, EventArgs e)
        {
            HistoryForm form = new HistoryForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Utils.ShowInfoMessageBox("Documentul cu istoricul a fost generat cu succes!");
            }
        }

        private void Button_GenerateReport_Click(object sender, EventArgs e)
        {
            MonthlyReportForm form = new MonthlyReportForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Utils.ShowInfoMessageBox("Raportul a fost generat!");
            }
        }
    }
}

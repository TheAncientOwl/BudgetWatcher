using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;

namespace BudgetWatcher.Forms.List
{
    public partial class ListExpensesForm : Form
    {
        readonly List<Expense> m_Expenses = null;

        public ListExpensesForm()
        {
            InitializeComponent();

            m_Expenses = Manager.Instance.SelectAll<Expense>(Expense.TableName);

            foreach (var expense in m_Expenses)
            {
                ExpensesGridView.Rows.Add("modifică", "șterge", expense.Id, expense.Name, expense.Value, expense.Date.ToShortDateString(), expense.Category.Name, expense.Frequency.Name, expense.Details);
            }

            ExpensesGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ExpensesGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ExpensesGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ExpensesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Expense currentExpense = m_Expenses[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 0:
                    ExpenseForm form = new ExpenseForm();
                    form.SetDefaultFormProperties("Modifică cheltuiala", currentExpense);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        form.FillInData(currentExpense);
                        currentExpense.Update();

                        DataGridViewCellCollection cells = ExpensesGridView.Rows[e.RowIndex].Cells;
                        cells[2].Value = currentExpense.Id;
                        cells[3].Value = currentExpense.Name;
                        cells[4].Value = currentExpense.Value;
                        cells[5].Value = currentExpense.Date.ToShortDateString();
                        cells[6].Value = currentExpense.Category.Name;
                        cells[7].Value = currentExpense.Frequency.Name;
                        cells[8].Value = currentExpense.Details;

                        Utils.ShowInfoMessageBox("Cheltuială modificată cu succes!");
                    }
                    return;
                case 1:
                    currentExpense.Delete();
                    m_Expenses.RemoveAt(e.RowIndex);
                    ExpensesGridView.Rows.RemoveAt(e.RowIndex);
                    return;
            }
        }
    }
}

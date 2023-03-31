using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.List
{
    public partial class ListExpensesForm : Form
    {
        List<Expense> m_Expenses = null;

        public ListExpensesForm()
        {
            InitializeComponent();

            m_Expenses = Expense.FetchAll();

            foreach (var expense in m_Expenses)
            {
                ExpensesGridView.Rows.Add("modifică", expense.Id, expense.Name, expense.Value, expense.Date, expense.Details, expense.Category.Name, expense.Frequency.Name);
            }

            ExpensesGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ExpensesGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void ExpensesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // button clicked, open update form
            {
                Expense currentExpense = m_Expenses[e.RowIndex];

                ExpenseForm form = new ExpenseForm("Modifică cheltuiala", currentExpense);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.FillInData(currentExpense);
                    currentExpense.Update();

                    DataGridViewCellCollection cells = ExpensesGridView.Rows[e.RowIndex].Cells;
                    cells[1].Value = currentExpense.Id;
                    cells[2].Value = currentExpense.Name;
                    cells[3].Value = currentExpense.Value;
                    cells[4].Value = currentExpense.Date;
                    cells[5].Value = currentExpense.Details;
                    cells[6].Value = currentExpense.Category.Name;
                    cells[7].Value = currentExpense.Frequency.Name;

                    Utils.ShowInfoMessageBox("Cheltuială modificată cu succes!");
                }
            }
        }
    }
}

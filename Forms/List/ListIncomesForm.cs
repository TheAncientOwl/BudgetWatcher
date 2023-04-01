using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;

namespace BudgetWatcher.Forms.List
{
    public partial class ListIncomesForm : Form
    {
        readonly List<Income> m_Incomes = null;

        public ListIncomesForm()
        {
            InitializeComponent();

            m_Incomes = Manager.Instance.SelectAll<Income>(Income.TableName);

            foreach (var income in m_Incomes)
            {
                IncomesGridView.Rows.Add("modifică", income.Id, income.Name, income.Value);
                
            }

            IncomesGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            IncomesGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void IncomesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // button clicked, open update form
            {
                Income currentIncome = m_Incomes[e.RowIndex];

                IncomeForm form = new IncomeForm();
                form.SetDefaultFormProperties("Modifică venitul", currentIncome);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.FillInData(currentIncome);
                    currentIncome.Update();

                    DataGridViewCellCollection cells = IncomesGridView.Rows[e.RowIndex].Cells;
                    cells[1].Value = currentIncome.Id;
                    cells[2].Value = currentIncome.Name;
                    cells[3].Value = currentIncome.Value;

                    Utils.ShowInfoMessageBox("Venit modificat cu succes!");
                }
            }
        }
    }
}

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
                IncomesGridView.Rows.Add("modifică", "șterge", income.Id, income.Name, income.Value);

            }

            IncomesGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            IncomesGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void IncomesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Income currentIncome = m_Incomes[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 0:
                    IncomeForm form = new IncomeForm();
                    form.SetDefaultFormProperties("Modifică venitul", currentIncome);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        form.FillInData(currentIncome);
                        currentIncome.Update();

                        DataGridViewCellCollection cells = IncomesGridView.Rows[e.RowIndex].Cells;
                        cells[2].Value = currentIncome.Id;
                        cells[3].Value = currentIncome.Name;
                        cells[4].Value = currentIncome.Value;

                        Utils.ShowInfoMessageBox("Venit modificat cu succes!");
                    }
                    return;
                case 1:
                    if (Utils.ShowQuestionBox("Sigur doriți să ștergeți venitul?") == DialogResult.Yes)
                    {
                        currentIncome.Delete();
                        m_Incomes.RemoveAt(e.RowIndex);
                        IncomesGridView.Rows.RemoveAt(e.RowIndex);
                    }
                    return;
            }
        }
    }
}

using BudgetWatcher.Database.Schemas;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.List
{
    public partial class ListIncomesForm : Form
    {
        List<Income> m_Incomes = null;

        public ListIncomesForm()
        {
            InitializeComponent();

            m_Incomes = Income.FetchAll();

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
                MessageBox.Show("Hello!");
            }
        }
    }
}

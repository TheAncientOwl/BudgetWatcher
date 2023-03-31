using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.List
{
    public partial class ListFrequenciesForm : Form
    {
        List<ExpenseFrequency> m_Frequencies = null;

        public ListFrequenciesForm()
        {
            InitializeComponent();

            m_Frequencies = ExpenseFrequency.FetchAll();

            foreach (var category in m_Frequencies)
            {
                FrequenciesGridView.Rows.Add("modifică", category.Id, category.Name, category.Days);
            }

            FrequenciesGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            FrequenciesGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FrequenciesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // button clicked, open update form
            {
                ExpenseFrequency currentFrequency = m_Frequencies[e.RowIndex];

                FrequencyForm form = new FrequencyForm("Modifică frecvența", currentFrequency);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.FillInData(currentFrequency);
                    currentFrequency.Update();

                    DataGridViewCellCollection cells = FrequenciesGridView.Rows[e.RowIndex].Cells;
                    cells[1].Value = currentFrequency.Id;
                    cells[2].Value = currentFrequency.Name;
                    cells[3].Value = currentFrequency.Days;

                    Utils.ShowInfoMessageBox("Frecvență modificată cu succes!");
                }
            }
        }
    }
}

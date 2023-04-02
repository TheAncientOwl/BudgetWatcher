using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;

namespace BudgetWatcher.Forms.List
{
    public partial class ListFrequenciesForm : Form
    {
        readonly List<ExpenseFrequency> m_Frequencies = null;

        public ListFrequenciesForm()
        {
            InitializeComponent();

            m_Frequencies = Manager.Instance.SelectAll<ExpenseFrequency>(ExpenseFrequency.TableName);

            foreach (var category in m_Frequencies)
            {
                FrequenciesGridView.Rows.Add("modifică", "șterge", category.Id, category.Name, category.Days);
            }

            FrequenciesGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            FrequenciesGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void FrequenciesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            ExpenseFrequency currentFrequency = m_Frequencies[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 0:
                    FrequencyForm form = new FrequencyForm();
                    form.SetDefaultFormProperties("Modifică frecvența", currentFrequency);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        form.FillInData(currentFrequency);
                        currentFrequency.Update();

                        DataGridViewCellCollection cells = FrequenciesGridView.Rows[e.RowIndex].Cells;
                        cells[2].Value = currentFrequency.Id;
                        cells[3].Value = currentFrequency.Name;
                        cells[4].Value = currentFrequency.Days;

                        Utils.ShowInfoMessageBox("Frecvență modificată cu succes!");
                    }
                    return;
                case 1:
                    if (Utils.ShowQuestionBox("Sigur doriți să ștergeți frecvența?") == DialogResult.Yes)
                    {
                        currentFrequency.Delete();
                        m_Frequencies.RemoveAt(e.RowIndex);
                        FrequenciesGridView.Rows.RemoveAt(e.RowIndex);
                    }
                    return;
            }
        }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Data;

namespace BudgetWatcher.Forms.List
{
    public partial class ListCategoriesForm : Form
    {
        readonly List<ExpenseCategory> m_Categories = null;

        public ListCategoriesForm()
        {
            InitializeComponent();

            m_Categories = Manager.Instance.SelectAll<ExpenseCategory>(ExpenseCategory.TableName);

            foreach (var category in m_Categories)
            {
                CategoriesGridView.Rows.Add("modifică", "șterge", category.Id, category.Name, category.Description);
            }

            CategoriesGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void CategoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            ExpenseCategory currentCateogry = m_Categories[e.RowIndex];

            switch (e.ColumnIndex)
            {
                case 0:
                    CategoryForm form = new CategoryForm();
                    form.SetDefaultFormProperties("Modifică categoria", currentCateogry);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        form.FillInData(currentCateogry);
                        currentCateogry.Update();

                        DataGridViewCellCollection cells = CategoriesGridView.Rows[e.RowIndex].Cells;
                        cells[2].Value = currentCateogry.Id;
                        cells[3].Value = currentCateogry.Name;
                        cells[4].Value = currentCateogry.Description;

                        Utils.ShowInfoMessageBox("Categorie modificată cu succes!");
                    }
                    return;
                case 1:
                    if (Utils.ShowQuestionBox("Sigur doriți să ștergeți categoria?") == DialogResult.Yes)
                    {
                        currentCateogry.Delete();
                        m_Categories.RemoveAt(e.RowIndex);
                        CategoriesGridView.Rows.RemoveAt(e.RowIndex);
                    }
                    return;
            }
        }
    }
}

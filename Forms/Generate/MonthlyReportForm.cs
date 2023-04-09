using System;
using System.IO;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;

using Excel = Microsoft.Office.Interop.Excel;

namespace BudgetWatcher.Forms.Generate
{
    public partial class MonthlyReportForm : Form
    {
        public MonthlyReportForm()
        {
            InitializeComponent();
        }

        private void Button_Ok_Click(object sender, EventArgs e)
        {
            Button_Ok.Enabled = false;
            Button_Ok.Text = "Se generează raportul...";

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(Path.Combine(AppContext.BaseDirectory, "MontlhyReportTemplate.xlsx"));
            Excel.Worksheet incomesSheet = workbook.Sheets[1];
            Excel.Worksheet expensesSheet = workbook.Sheets[2];

            using (TableIterator<Expense> it = new TableIterator<Expense>(Expense.TableName))
            {
                DateTime pickedTime = DateTimePicker.Value;
                int line = 2;

                while (it.HasNext())
                {
                    DateTime date = (DateTime)it.GetField(Expense.Fields.Date);

                    if (date.Month == pickedTime.Month && date.Year == pickedTime.Year)
                    {
                        Expense expense = it.Value;

                        expensesSheet.Cells[line, 1].Value = expense.ID;
                        expensesSheet.Cells[line, 2].Value = expense.Name;
                        expensesSheet.Cells[line, 3].Value = expense.Value;
                        expensesSheet.Cells[line, 4].Value = expense.Date.ToShortDateString();
                        expensesSheet.Cells[line, 5].Value = expense.Category.Name;
                        expensesSheet.Cells[line, 6].Value = expense.Frequency.Name;
                        expensesSheet.Cells[line, 7].Value = expense.Details;

                        line++;
                    }

                    it.MoveNext();
                }
            }

            using (TableIterator<Income> it = new TableIterator<Income>(Income.TableName))
            {
                int line = 2;

                while (it.HasNext())
                {
                    Income income = it.Value;

                    incomesSheet.Cells[line, 1].Value = income.ID;
                    incomesSheet.Cells[line, 2].Value = income.Name;
                    incomesSheet.Cells[line, 3].Value = income.Value;

                    line++;

                    it.MoveNext();
                }
            }

            excelApp.DisplayAlerts = false;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel worksheet (*.xlsx)|*.xlsx|All files (*.*)|*.*\"'";
            saveFileDialog.Title = "Save report";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
            }

            workbook.Close();
            excelApp.Quit();
        }
    }
}

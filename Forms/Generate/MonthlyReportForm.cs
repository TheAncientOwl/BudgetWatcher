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

            TableIterator<Expense> expenseIt = new TableIterator<Expense>(Expense.TableName);
            DateTime pickedTime = DateTimePicker.Value;
            int expenseLine = 2;

            while (expenseIt.HasNext())
            {
                DateTime date = (DateTime)expenseIt.GetField(Expense.Fields.Date);

                if (date.Month == pickedTime.Month && date.Year == pickedTime.Year)
                {
                    Expense expense = expenseIt.Value;

                    expensesSheet.Cells[expenseLine, 1].Value = expense.ID;
                    expensesSheet.Cells[expenseLine, 2].Value = expense.Name;
                    expensesSheet.Cells[expenseLine, 3].Value = expense.Value;
                    expensesSheet.Cells[expenseLine, 4].Value = expense.Date.ToShortDateString();
                    expensesSheet.Cells[expenseLine, 5].Value = expense.Category.Name;
                    expensesSheet.Cells[expenseLine, 6].Value = expense.Frequency.Name;
                    expensesSheet.Cells[expenseLine, 7].Value = expense.Details;

                    expenseLine++;
                }

                expenseIt.MoveNext();
            }

            expenseIt.Close();

            TableIterator<Income> incomeIt = new TableIterator<Income>(Income.TableName);
            int incomeLine = 2;

            while (incomeIt.HasNext())
            {
                Income income = incomeIt.Value;

                incomesSheet.Cells[incomeLine, 1].Value = income.ID;
                incomesSheet.Cells[incomeLine, 2].Value = income.Name;
                incomesSheet.Cells[incomeLine, 3].Value = income.Value;

                incomeLine++;

                incomeIt.MoveNext();
            }

            incomeIt.Close();

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

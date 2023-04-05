using BudgetWatcher.Builders;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Database;
using System.Threading;
using System.Globalization;
using System.IO;
using BudgetWatcher.Forms.Feedback;

namespace BudgetWatcher.Forms.Generate
{
    public partial class HistoryForm : Form
    {
        static readonly CultureInfo DocCultureInfo = new CultureInfo("ro-RO");

        public HistoryForm()
        {
            InitializeComponent();
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (StartDateTimePicker.Value > FinalDateTimePicker.Value)
            {
                FinalDateTimePicker.Value = StartDateTimePicker.Value;
            }
        }

        private void FinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (FinalDateTimePicker.Value < StartDateTimePicker.Value)
            {
                StartDateTimePicker.Value = FinalDateTimePicker.Value;
            }
        }

        private void Button_Ok_Click(object sender, EventArgs e)
        {
            Button_Ok.Enabled = false;
            Button_Cancel.Enabled = false;
            StartDateTimePicker.Enabled = false;
            FinalDateTimePicker.Enabled = false;
            ChooseWordFilePath.Enabled = false;

            Button_Ok.Text = "Se salvează...";

            DateTime startDate = StartDateTimePicker.Value;
            DateTime finalDate = FinalDateTimePicker.Value;

            WordBuilder wordBuilder = new WordBuilder()
                .AddEmptyLines(1, 28)
                .AddTitle("Istoric cheltuieli")
                .AddEmptyLines(1)
                .AddSubtitle("Perioada: " + startDate.ToString("dd/MM/yyyy") + " - " + finalDate.ToString("dd/MM/yyyy"))
                .AddSubtitle("Realizat la data: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm"))
                .AddEmptyLines(1)
                .AddTableOfContents()
                .AddEmptyLines(1);

            List<Expense> expenseList = Manager.Instance.SelectAllExpenses(startDate, finalDate);

            int lastDay = -1;
            int lastMonth = -1;
            DateTime lastDate = DateTime.MinValue;
            List<Expense> dayExpenses = new List<Expense>();
            double total = 0;

            foreach (Expense expense in expenseList)
            {
                if (lastMonth != expense.Date.Month) // new month -> new heading 1
                {
                    wordBuilder
                        .AddHeading1(DocCultureInfo.TextInfo.ToTitleCase(expense.Date.ToString("MMMM", DocCultureInfo)) + " " + expense.Date.ToString("yyyy"))
                        .AddEmptyLines(1);

                    lastDay = -1;
                    lastMonth = expense.Date.Month;
                    dayExpenses.Clear();
                }

                if (lastDay != expense.Date.Day && lastDay != -1) // new day -> new heading 2 + add table
                {
                    double dayTotal = 0;
                    foreach (var dayExpense in dayExpenses)
                    {
                        dayTotal += dayExpense.Value;
                    }

                    wordBuilder
                        .AddHeading2(lastDate.ToString("dd/MM/yyyy", DocCultureInfo) + " - Total: " + dayTotal.ToString() + " RON")
                        .AddTable(dayExpenses)
                        .AddEmptyLines(1);

                    dayExpenses.Clear();
                    dayExpenses.Add(expense);
                }
                else
                {
                    dayExpenses.Add(expense);
                }

                lastDay = expense.Date.Day;
                lastDate = expense.Date;

                total += expense.Value;
            }

            if (dayExpenses.Count > 0)
            {
                double dayTotal = 0;
                foreach (var dayExpense in dayExpenses)
                {
                    dayTotal += dayExpense.Value;
                }

                wordBuilder
                    .AddHeading2(lastDate.ToString("dd/MM/yyyy", DocCultureInfo) + " - Total: " + dayTotal.ToString() + " RON")
                    .AddTable(dayExpenses)
                    .AddEmptyLines(1);
            }

            wordBuilder
                .UpdateTableOfContents()
                .SaveAs(Path.Combine(WordFilePath.Text, "Istoric_Cheltuieli_" + startDate.ToString("dd-MM-yyyy") + "_" + finalDate.ToString("dd-MM-yyyy") + ".docx"))
                .Close();
        }

        private void ChooseWordFilePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.UserProfile;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                WordFilePath.Text = folderBrowserDialog.SelectedPath;
                Button_Ok.Enabled = WordFilePath.Text.Length != 0 && Directory.Exists(WordFilePath.Text);
            }
        }
    }
}

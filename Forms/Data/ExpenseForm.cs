using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;

namespace BudgetWatcher.Forms.Data
{
    public partial class ExpenseForm : Form, IDatabaseObjectFiller<Expense>, ISetDefaultFormProperties<Expense>
    {
        readonly List<Tuple<int, string>> m_Categories;
        readonly List<Tuple<int, string>> m_Frequencies;

        public ExpenseForm()
        {
            InitializeComponent();

            // fetch categories and frequencies
            m_Categories = Manager.Instance.Peek(ExpenseCategory.TableName, ExpenseCategory.Fields.ID, ExpenseCategory.Fields.Name);
            m_Frequencies = Manager.Instance.Peek(ExpenseFrequency.TableName, ExpenseFrequency.Fields.ID, ExpenseFrequency.Fields.Name);

            foreach (var category in m_Categories)
            {
                CategoryComboBox.Items.Add(category.Item2);
            }

            foreach (var frequencies in m_Frequencies)
            {
                FrequencyComboBox.Items.Add(frequencies.Item2);
            }

            DateTimePicker.Value = DateTime.Now;
        }

        public void FillInData(Expense expense)
        {
            expense.Name = NameTextBox.Text;
            expense.Value = (double)ValueUpDown.Value;
            expense.Date = DateTimePicker.Value;
            expense.Details = DetailsTextBox.Text.Length == 0 ? "-" : DetailsTextBox.Text;
            expense.Frequency = new ExpenseFrequency(m_Frequencies[FrequencyComboBox.SelectedIndex].Item1);
            expense.Category = new ExpenseCategory(m_Categories[CategoryComboBox.SelectedIndex].Item1);
        }

        public void SetDefaultFormProperties(string formTitle, Expense defaultExpense)
        {
            Text = formTitle;

            NameTextBox.Text = defaultExpense.Name;
            ValueUpDown.Value = (decimal)defaultExpense.Value;
            DateTimePicker.Value = defaultExpense.Date;
            DetailsTextBox.Text = defaultExpense.Details;

            FrequencyComboBox.SelectedIndex = defaultExpense.Frequency == null ? -1 : m_Frequencies.FindIndex(
                (frequency) => frequency.Item1 == defaultExpense.Frequency.Id);

            CategoryComboBox.SelectedIndex = defaultExpense.Category == null ? -1 : m_Categories.FindIndex(
                (category) => category.Item1 == defaultExpense.Category.Id);
        }

        private void HandleButtonOkEnabledState()
        {
            Button_Ok.Enabled =
                FrequencyComboBox.SelectedIndex != -1 &&
                CategoryComboBox.SelectedIndex != -1 &&
                NameTextBox.Text.Length != 0;
        }

        private void FrequencyComboBox_SelectedIndexChanged(object sender, EventArgs e) => HandleButtonOkEnabledState();
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e) => HandleButtonOkEnabledState();

        private void NameTextBox_TextChanged(object sender, EventArgs e) => HandleButtonOkEnabledState();
    }
}

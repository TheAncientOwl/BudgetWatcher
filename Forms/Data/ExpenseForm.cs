using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;
using BudgetWatcher.Database.Schemas;

namespace BudgetWatcher.Forms.Data
{
    public partial class ExpenseForm : Form
    {
        readonly List<Tuple<int, string>> m_Categories;
        readonly List<Tuple<int, string>> m_Frequencies;

        public ExpenseForm(string formTitle, Expense defaultExpense)
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

            // fill in defaults
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

        public void FillInData(Expense expense)
        {
            expense.Name = NameTextBox.Text;
            expense.Value = (double)ValueUpDown.Value;
            expense.Date = DateTimePicker.Value;
            expense.Details = DetailsTextBox.Text.Length == 0 ? "-" : DetailsTextBox.Text;
            expense.Frequency = new ExpenseFrequency(m_Frequencies[FrequencyComboBox.SelectedIndex].Item1);
            expense.Category = new ExpenseCategory(m_Categories[CategoryComboBox.SelectedIndex].Item1);
        }

        public string NameData { get => NameTextBox.Text; }
        public double ValueData { get => (double)ValueUpDown.Value; }
        public DateTime DateData { get => DateTimePicker.Value; }
        public string DetailsData { get => DetailsTextBox.Text.Length == 0 ? "-" : DetailsTextBox.Text; }
        public int FrequencyIdData { get => m_Frequencies[FrequencyComboBox.SelectedIndex].Item1; }
        public int CategoryIdData { get => m_Categories[CategoryComboBox.SelectedIndex].Item1; }

        private void AddNewExpenseForm_Load(object sender, EventArgs e)
        {
            DateTimePicker.Value = DateTime.Now;
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

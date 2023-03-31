using System;
using System.Collections.Generic;
using System.Windows.Forms;

using BudgetWatcher.Database;

namespace BudgetWatcher.Forms.Data
{
    public partial class ExpenseForm : Form
    {
        readonly List<Tuple<int, string>> m_Categories;
        readonly List<Tuple<int, string>> m_Frequencies;

        public ExpenseForm()
        {
            InitializeComponent();

            m_Categories = Manager.Instance.PeekCategories();
            m_Frequencies = Manager.Instance.PeekFrequencies();

            foreach (var category in m_Categories)
            {
                CategoryComboBox.Items.Add(category.Item2);
            }

            foreach (var frequencies in m_Frequencies)
            {
                FrequencyComboBox.Items.Add(frequencies.Item2);
            }
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

using System;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.Data
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        public string NameData { get => NameTextBox.Text; }
        public string DescriptionData { get => DescriptionTextBox.Text.Length == 0 ? "-" : DescriptionTextBox.Text; }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Button_Ok.Enabled = NameTextBox.Text.Length != 0;
        }
    }
}

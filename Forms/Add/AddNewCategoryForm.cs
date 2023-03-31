using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetWatcher.Forms.Add
{
    public partial class AddNewCategoryForm : Form
    {
        public AddNewCategoryForm()
        {
            InitializeComponent();
        }

        public string NameData { get => NameTextBox.Text; }
        public string DescriptionData { get => DescriptionTextBox.Text; }
    }
}

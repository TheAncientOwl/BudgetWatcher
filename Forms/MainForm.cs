using BudgetWatcher.Database.Schemas;
using BudgetWatcher.Forms.Add;
using BudgetWatcher.Forms.Feedback;
using System;
using System.Windows.Forms;

namespace BudgetWatcher.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button_OpenAddIncomeForm_Click(object sender, EventArgs e)
        {
            AddNewIncomeForm form = new AddNewIncomeForm();
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                Income newIncome = new Income(form.NameData, form.ValueData);
                newIncome.Insert();

                InfoForm infoForm = new InfoForm("Venit adăugat cu succes!");
                
                if (infoForm.ShowDialog() == DialogResult.OK)
                {
                    infoForm.Close();
                }
            }
        }
    }
}

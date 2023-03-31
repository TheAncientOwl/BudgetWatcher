namespace BudgetWatcher.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_OpenAddIncomeForm = new System.Windows.Forms.Button();
            this.Button_OpenAddNewCategoryForm = new System.Windows.Forms.Button();
            this.Button_OpenAddNewFrequencyForm = new System.Windows.Forms.Button();
            this.Button_OpenAddNewExpenseForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_OpenAddIncomeForm
            // 
            this.Button_OpenAddIncomeForm.Location = new System.Drawing.Point(31, 101);
            this.Button_OpenAddIncomeForm.Name = "Button_OpenAddIncomeForm";
            this.Button_OpenAddIncomeForm.Size = new System.Drawing.Size(173, 56);
            this.Button_OpenAddIncomeForm.TabIndex = 0;
            this.Button_OpenAddIncomeForm.Text = "Adaugă un venit nou";
            this.Button_OpenAddIncomeForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddIncomeForm.Click += new System.EventHandler(this.Button_OpenAddIncomeForm_Click);
            // 
            // Button_OpenAddNewCategoryForm
            // 
            this.Button_OpenAddNewCategoryForm.Location = new System.Drawing.Point(31, 176);
            this.Button_OpenAddNewCategoryForm.Name = "Button_OpenAddNewCategoryForm";
            this.Button_OpenAddNewCategoryForm.Size = new System.Drawing.Size(173, 56);
            this.Button_OpenAddNewCategoryForm.TabIndex = 1;
            this.Button_OpenAddNewCategoryForm.Text = "Adaugă o categorie nouă";
            this.Button_OpenAddNewCategoryForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddNewCategoryForm.Click += new System.EventHandler(this.Button_OpenAddNewCategoryForm_Click);
            // 
            // Button_OpenAddNewFrequencyForm
            // 
            this.Button_OpenAddNewFrequencyForm.Location = new System.Drawing.Point(31, 258);
            this.Button_OpenAddNewFrequencyForm.Name = "Button_OpenAddNewFrequencyForm";
            this.Button_OpenAddNewFrequencyForm.Size = new System.Drawing.Size(173, 56);
            this.Button_OpenAddNewFrequencyForm.TabIndex = 2;
            this.Button_OpenAddNewFrequencyForm.Text = "Adaugă o frecvență nouă";
            this.Button_OpenAddNewFrequencyForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddNewFrequencyForm.Click += new System.EventHandler(this.Button_OpenAddNewFrequencyForm_Click);
            // 
            // Button_OpenAddNewExpenseForm
            // 
            this.Button_OpenAddNewExpenseForm.Location = new System.Drawing.Point(31, 26);
            this.Button_OpenAddNewExpenseForm.Name = "Button_OpenAddNewExpenseForm";
            this.Button_OpenAddNewExpenseForm.Size = new System.Drawing.Size(173, 56);
            this.Button_OpenAddNewExpenseForm.TabIndex = 3;
            this.Button_OpenAddNewExpenseForm.Text = "Adaugă o cheltuială nouă";
            this.Button_OpenAddNewExpenseForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddNewExpenseForm.Click += new System.EventHandler(this.Button_OpenAddNewExpenseForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 351);
            this.Controls.Add(this.Button_OpenAddNewExpenseForm);
            this.Controls.Add(this.Button_OpenAddNewFrequencyForm);
            this.Controls.Add(this.Button_OpenAddNewCategoryForm);
            this.Controls.Add(this.Button_OpenAddIncomeForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "BudgetWatcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OpenAddIncomeForm;
        private System.Windows.Forms.Button Button_OpenAddNewCategoryForm;
        private System.Windows.Forms.Button Button_OpenAddNewFrequencyForm;
        private System.Windows.Forms.Button Button_OpenAddNewExpenseForm;
    }
}
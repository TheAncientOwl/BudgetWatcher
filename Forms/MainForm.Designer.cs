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
            this.Button_ListIncomes = new System.Windows.Forms.Button();
            this.Button_ListCategories = new System.Windows.Forms.Button();
            this.Button_ListFrequencies = new System.Windows.Forms.Button();
            this.Button_ListExpenses = new System.Windows.Forms.Button();
            this.Button_GenerateReport = new System.Windows.Forms.Button();
            this.Button_GenerateHistory = new System.Windows.Forms.Button();
            this.AddLabel = new System.Windows.Forms.Label();
            this.ListLabel = new System.Windows.Forms.Label();
            this.GenerateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_OpenAddIncomeForm
            // 
            this.Button_OpenAddIncomeForm.Location = new System.Drawing.Point(183, 62);
            this.Button_OpenAddIncomeForm.Name = "Button_OpenAddIncomeForm";
            this.Button_OpenAddIncomeForm.Size = new System.Drawing.Size(120, 56);
            this.Button_OpenAddIncomeForm.TabIndex = 0;
            this.Button_OpenAddIncomeForm.Text = "venit";
            this.Button_OpenAddIncomeForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddIncomeForm.Click += new System.EventHandler(this.Button_OpenAddIncomeForm_Click);
            // 
            // Button_OpenAddNewCategoryForm
            // 
            this.Button_OpenAddNewCategoryForm.Location = new System.Drawing.Point(31, 136);
            this.Button_OpenAddNewCategoryForm.Name = "Button_OpenAddNewCategoryForm";
            this.Button_OpenAddNewCategoryForm.Size = new System.Drawing.Size(120, 56);
            this.Button_OpenAddNewCategoryForm.TabIndex = 1;
            this.Button_OpenAddNewCategoryForm.Text = "categorie";
            this.Button_OpenAddNewCategoryForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddNewCategoryForm.Click += new System.EventHandler(this.Button_OpenAddNewCategoryForm_Click);
            // 
            // Button_OpenAddNewFrequencyForm
            // 
            this.Button_OpenAddNewFrequencyForm.Location = new System.Drawing.Point(183, 136);
            this.Button_OpenAddNewFrequencyForm.Name = "Button_OpenAddNewFrequencyForm";
            this.Button_OpenAddNewFrequencyForm.Size = new System.Drawing.Size(120, 56);
            this.Button_OpenAddNewFrequencyForm.TabIndex = 2;
            this.Button_OpenAddNewFrequencyForm.Text = "frecvență";
            this.Button_OpenAddNewFrequencyForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddNewFrequencyForm.Click += new System.EventHandler(this.Button_OpenAddNewFrequencyForm_Click);
            // 
            // Button_OpenAddNewExpenseForm
            // 
            this.Button_OpenAddNewExpenseForm.Location = new System.Drawing.Point(31, 62);
            this.Button_OpenAddNewExpenseForm.Name = "Button_OpenAddNewExpenseForm";
            this.Button_OpenAddNewExpenseForm.Size = new System.Drawing.Size(120, 56);
            this.Button_OpenAddNewExpenseForm.TabIndex = 3;
            this.Button_OpenAddNewExpenseForm.Text = "cheltuială";
            this.Button_OpenAddNewExpenseForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddNewExpenseForm.Click += new System.EventHandler(this.Button_OpenAddNewExpenseForm_Click);
            // 
            // Button_ListIncomes
            // 
            this.Button_ListIncomes.Location = new System.Drawing.Point(555, 62);
            this.Button_ListIncomes.Name = "Button_ListIncomes";
            this.Button_ListIncomes.Size = new System.Drawing.Size(120, 56);
            this.Button_ListIncomes.TabIndex = 4;
            this.Button_ListIncomes.Text = "veniturile";
            this.Button_ListIncomes.UseVisualStyleBackColor = true;
            this.Button_ListIncomes.Click += new System.EventHandler(this.Button_ListIncomes_Click);
            // 
            // Button_ListCategories
            // 
            this.Button_ListCategories.Location = new System.Drawing.Point(399, 136);
            this.Button_ListCategories.Name = "Button_ListCategories";
            this.Button_ListCategories.Size = new System.Drawing.Size(120, 56);
            this.Button_ListCategories.TabIndex = 5;
            this.Button_ListCategories.Text = "categoriile";
            this.Button_ListCategories.UseVisualStyleBackColor = true;
            this.Button_ListCategories.Click += new System.EventHandler(this.Button_ListCategories_Click);
            // 
            // Button_ListFrequencies
            // 
            this.Button_ListFrequencies.Location = new System.Drawing.Point(555, 136);
            this.Button_ListFrequencies.Name = "Button_ListFrequencies";
            this.Button_ListFrequencies.Size = new System.Drawing.Size(120, 56);
            this.Button_ListFrequencies.TabIndex = 6;
            this.Button_ListFrequencies.Text = "frecvențele";
            this.Button_ListFrequencies.UseVisualStyleBackColor = true;
            this.Button_ListFrequencies.Click += new System.EventHandler(this.Button_ListFrequencies_Click);
            // 
            // Button_ListExpenses
            // 
            this.Button_ListExpenses.Location = new System.Drawing.Point(399, 62);
            this.Button_ListExpenses.Name = "Button_ListExpenses";
            this.Button_ListExpenses.Size = new System.Drawing.Size(120, 56);
            this.Button_ListExpenses.TabIndex = 7;
            this.Button_ListExpenses.Text = "cheltuielile";
            this.Button_ListExpenses.UseVisualStyleBackColor = true;
            this.Button_ListExpenses.Click += new System.EventHandler(this.Button_ListExpenses_Click);
            // 
            // Button_GenerateReport
            // 
            this.Button_GenerateReport.Location = new System.Drawing.Point(368, 279);
            this.Button_GenerateReport.Name = "Button_GenerateReport";
            this.Button_GenerateReport.Size = new System.Drawing.Size(120, 56);
            this.Button_GenerateReport.TabIndex = 8;
            this.Button_GenerateReport.Text = "raport";
            this.Button_GenerateReport.UseVisualStyleBackColor = true;
            // 
            // Button_GenerateHistory
            // 
            this.Button_GenerateHistory.Location = new System.Drawing.Point(211, 279);
            this.Button_GenerateHistory.Name = "Button_GenerateHistory";
            this.Button_GenerateHistory.Size = new System.Drawing.Size(120, 56);
            this.Button_GenerateHistory.TabIndex = 9;
            this.Button_GenerateHistory.Text = "istoric";
            this.Button_GenerateHistory.UseVisualStyleBackColor = true;
            this.Button_GenerateHistory.Click += new System.EventHandler(this.Button_GenerateHistory_Click);
            // 
            // AddLabel
            // 
            this.AddLabel.AutoSize = true;
            this.AddLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddLabel.Location = new System.Drawing.Point(126, 24);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(72, 22);
            this.AddLabel.TabIndex = 10;
            this.AddLabel.Text = "Adaugă";
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLabel.Location = new System.Drawing.Point(500, 24);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(76, 22);
            this.ListLabel.TabIndex = 11;
            this.ListLabel.Text = "Listează";
            // 
            // GenerateLabel
            // 
            this.GenerateLabel.AutoSize = true;
            this.GenerateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateLabel.Location = new System.Drawing.Point(301, 234);
            this.GenerateLabel.Name = "GenerateLabel";
            this.GenerateLabel.Size = new System.Drawing.Size(98, 22);
            this.GenerateLabel.TabIndex = 12;
            this.GenerateLabel.Text = "Generează";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 385);
            this.Controls.Add(this.GenerateLabel);
            this.Controls.Add(this.ListLabel);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.Button_GenerateHistory);
            this.Controls.Add(this.Button_GenerateReport);
            this.Controls.Add(this.Button_ListExpenses);
            this.Controls.Add(this.Button_ListFrequencies);
            this.Controls.Add(this.Button_ListCategories);
            this.Controls.Add(this.Button_ListIncomes);
            this.Controls.Add(this.Button_OpenAddNewExpenseForm);
            this.Controls.Add(this.Button_OpenAddNewFrequencyForm);
            this.Controls.Add(this.Button_OpenAddNewCategoryForm);
            this.Controls.Add(this.Button_OpenAddIncomeForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BudgetWatcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_OpenAddIncomeForm;
        private System.Windows.Forms.Button Button_OpenAddNewCategoryForm;
        private System.Windows.Forms.Button Button_OpenAddNewFrequencyForm;
        private System.Windows.Forms.Button Button_OpenAddNewExpenseForm;
        private System.Windows.Forms.Button Button_ListIncomes;
        private System.Windows.Forms.Button Button_ListCategories;
        private System.Windows.Forms.Button Button_ListFrequencies;
        private System.Windows.Forms.Button Button_ListExpenses;
        private System.Windows.Forms.Button Button_GenerateReport;
        private System.Windows.Forms.Button Button_GenerateHistory;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.Label GenerateLabel;
    }
}
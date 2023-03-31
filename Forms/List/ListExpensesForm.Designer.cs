namespace BudgetWatcher.Forms.List
{
    partial class ListExpensesForm
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
            this.ExpensesGridView = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExpensesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExpensesGridView
            // 
            this.ExpensesGridView.AllowUserToAddRows = false;
            this.ExpensesGridView.AllowUserToDeleteRows = false;
            this.ExpensesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ExpensesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExpensesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpensesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.ID,
            this.Name_,
            this.Value,
            this.Date,
            this.Description,
            this.Category,
            this.Frequency});
            this.ExpensesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpensesGridView.Location = new System.Drawing.Point(0, 0);
            this.ExpensesGridView.Name = "ExpensesGridView";
            this.ExpensesGridView.ReadOnly = true;
            this.ExpensesGridView.RowHeadersWidth = 51;
            this.ExpensesGridView.RowTemplate.Height = 24;
            this.ExpensesGridView.Size = new System.Drawing.Size(1435, 450);
            this.ExpensesGridView.TabIndex = 2;
            this.ExpensesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpensesGridView_CellContentClick);
            // 
            // EditButton
            // 
            this.EditButton.HeaderText = "Modifică";
            this.EditButton.MinimumWidth = 6;
            this.EditButton.Name = "EditButton";
            this.EditButton.ReadOnly = true;
            this.EditButton.Width = 55;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 55;
            // 
            // Name_
            // 
            this.Name_.HeaderText = "Denumire";
            this.Name_.MinimumWidth = 6;
            this.Name_.Name = "Name_";
            this.Name_.ReadOnly = true;
            this.Name_.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Valoare";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Dată";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 180;
            // 
            // Description
            // 
            this.Description.HeaderText = "Descriere";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 180;
            // 
            // Category
            // 
            this.Category.HeaderText = "Categorie";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 125;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Frecvență";
            this.Frequency.MinimumWidth = 6;
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Width = 125;
            // 
            // ListExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 450);
            this.Controls.Add(this.ExpensesGridView);
            this.Name = "ListExpensesForm";
            this.Text = "Cheltuieli";
            ((System.ComponentModel.ISupportInitialize)(this.ExpensesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ExpensesGridView;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
    }
}
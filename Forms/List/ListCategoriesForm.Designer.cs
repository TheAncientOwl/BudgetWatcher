namespace BudgetWatcher.Forms.List
{
    partial class ListCategoriesForm
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
            this.CategoriesGridView = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoriesGridView
            // 
            this.CategoriesGridView.AllowUserToAddRows = false;
            this.CategoriesGridView.AllowUserToDeleteRows = false;
            this.CategoriesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CategoriesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CategoriesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoriesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.ID,
            this.Name_,
            this.Description});
            this.CategoriesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesGridView.Location = new System.Drawing.Point(0, 0);
            this.CategoriesGridView.Name = "CategoriesGridView";
            this.CategoriesGridView.ReadOnly = true;
            this.CategoriesGridView.RowHeadersWidth = 51;
            this.CategoriesGridView.RowTemplate.Height = 24;
            this.CategoriesGridView.Size = new System.Drawing.Size(800, 450);
            this.CategoriesGridView.TabIndex = 1;
            this.CategoriesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoriesGridView_CellContentClick);
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
            // Description
            // 
            this.Description.HeaderText = "Descriere";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // ListCategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CategoriesGridView);
            this.Name = "ListCategoriesForm";
            this.Text = "Categorii de cheltuieli";
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CategoriesGridView;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}
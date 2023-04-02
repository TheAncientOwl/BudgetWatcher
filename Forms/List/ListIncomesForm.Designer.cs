namespace BudgetWatcher.Forms.List
{
    partial class ListIncomesForm
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
            this.IncomesGridView = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.IncomesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // IncomesGridView
            // 
            this.IncomesGridView.AllowUserToAddRows = false;
            this.IncomesGridView.AllowUserToDeleteRows = false;
            this.IncomesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.IncomesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IncomesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IncomesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditButton,
            this.ID,
            this.Name_,
            this.Value});
            this.IncomesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IncomesGridView.Location = new System.Drawing.Point(15, 15);
            this.IncomesGridView.Name = "IncomesGridView";
            this.IncomesGridView.ReadOnly = true;
            this.IncomesGridView.RowHeadersWidth = 51;
            this.IncomesGridView.RowTemplate.Height = 24;
            this.IncomesGridView.Size = new System.Drawing.Size(621, 298);
            this.IncomesGridView.TabIndex = 0;
            this.IncomesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IncomesGridView_CellContentClick);
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
            this.Value.Width = 115;
            // 
            // ListIncomesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 328);
            this.Controls.Add(this.IncomesGridView);
            this.Name = "ListIncomesForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venituri";
            ((System.ComponentModel.ISupportInitialize)(this.IncomesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IncomesGridView;
        private System.Windows.Forms.DataGridViewButtonColumn EditButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
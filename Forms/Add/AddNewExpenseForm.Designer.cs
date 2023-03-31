namespace BudgetWatcher.Forms.Add
{
    partial class AddNewExpenseForm
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
            this.Button_Ok = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.DetailsLabel = new System.Windows.Forms.Label();
            this.DetailsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Ok
            // 
            this.Button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Ok.Enabled = false;
            this.Button_Ok.Location = new System.Drawing.Point(55, 308);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(86, 46);
            this.Button_Ok.TabIndex = 6;
            this.Button_Ok.Text = "Ok";
            this.Button_Ok.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(228, 308);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(86, 46);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(20, 36);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(65, 16);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "Denumire";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(126, 32);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(247, 22);
            this.NameTextBox.TabIndex = 9;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(20, 82);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(55, 16);
            this.ValueLabel.TabIndex = 10;
            this.ValueLabel.Text = "Valoare";
            // 
            // ValueUpDown
            // 
            this.ValueUpDown.DecimalPlaces = 2;
            this.ValueUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ValueUpDown.Location = new System.Drawing.Point(126, 79);
            this.ValueUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ValueUpDown.Name = "ValueUpDown";
            this.ValueUpDown.Size = new System.Drawing.Size(247, 22);
            this.ValueUpDown.TabIndex = 11;
            this.ValueUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ValueUpDown.ThousandsSeparator = true;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(20, 141);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(36, 16);
            this.DateLabel.TabIndex = 12;
            this.DateLabel.Text = "Data";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.CustomFormat = "";
            this.DateTimePicker.Location = new System.Drawing.Point(126, 134);
            this.DateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(247, 22);
            this.DateTimePicker.TabIndex = 13;
            // 
            // FrequencyLabel
            // 
            this.FrequencyLabel.AutoSize = true;
            this.FrequencyLabel.Location = new System.Drawing.Point(20, 194);
            this.FrequencyLabel.Name = "FrequencyLabel";
            this.FrequencyLabel.Size = new System.Drawing.Size(67, 16);
            this.FrequencyLabel.TabIndex = 14;
            this.FrequencyLabel.Text = "Frecvență";
            // 
            // FrequencyComboBox
            // 
            this.FrequencyComboBox.FormattingEnabled = true;
            this.FrequencyComboBox.Location = new System.Drawing.Point(126, 193);
            this.FrequencyComboBox.Name = "FrequencyComboBox";
            this.FrequencyComboBox.Size = new System.Drawing.Size(247, 24);
            this.FrequencyComboBox.TabIndex = 15;
            this.FrequencyComboBox.SelectedIndexChanged += new System.EventHandler(this.FrequencyComboBox_SelectedIndexChanged);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(20, 243);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(66, 16);
            this.CategoryLabel.TabIndex = 16;
            this.CategoryLabel.Text = "Categorie";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(126, 242);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(247, 24);
            this.CategoryComboBox.TabIndex = 17;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // DetailsLabel
            // 
            this.DetailsLabel.AutoSize = true;
            this.DetailsLabel.Location = new System.Drawing.Point(481, 33);
            this.DetailsLabel.Name = "DetailsLabel";
            this.DetailsLabel.Size = new System.Drawing.Size(49, 16);
            this.DetailsLabel.TabIndex = 18;
            this.DetailsLabel.Text = "Details";
            // 
            // DetailsTextBox
            // 
            this.DetailsTextBox.Location = new System.Drawing.Point(408, 60);
            this.DetailsTextBox.Multiline = true;
            this.DetailsTextBox.Name = "DetailsTextBox";
            this.DetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailsTextBox.Size = new System.Drawing.Size(196, 294);
            this.DetailsTextBox.TabIndex = 19;
            // 
            // AddNewExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 400);
            this.Controls.Add(this.DetailsTextBox);
            this.Controls.Add(this.DetailsLabel);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.FrequencyComboBox);
            this.Controls.Add(this.FrequencyLabel);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.ValueUpDown);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewExpenseForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "Adaugă o cheltuială nouă";
            this.Load += new System.EventHandler(this.AddNewExpenseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Ok;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.NumericUpDown ValueUpDown;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Label FrequencyLabel;
        private System.Windows.Forms.ComboBox FrequencyComboBox;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label DetailsLabel;
        private System.Windows.Forms.TextBox DetailsTextBox;
    }
}
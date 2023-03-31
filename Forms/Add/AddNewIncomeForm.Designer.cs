namespace BudgetWatcher.Forms.Add
{
    partial class AddNewIncomeForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ValueUpDown = new System.Windows.Forms.NumericUpDown();
            this.Button_Ok = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(36, 39);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(65, 16);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Denumire";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(36, 81);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(55, 16);
            this.ValueLabel.TabIndex = 1;
            this.ValueLabel.Text = "Valoare";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(150, 36);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(204, 22);
            this.NameTextBox.TabIndex = 2;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // ValueUpDown
            // 
            this.ValueUpDown.DecimalPlaces = 2;
            this.ValueUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ValueUpDown.Location = new System.Drawing.Point(150, 75);
            this.ValueUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ValueUpDown.Name = "ValueUpDown";
            this.ValueUpDown.Size = new System.Drawing.Size(204, 22);
            this.ValueUpDown.TabIndex = 3;
            this.ValueUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ValueUpDown.ThousandsSeparator = true;
            // 
            // Button_Ok
            // 
            this.Button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Ok.Enabled = false;
            this.Button_Ok.Location = new System.Drawing.Point(67, 128);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(86, 46);
            this.Button_Ok.TabIndex = 4;
            this.Button_Ok.Text = "Ok";
            this.Button_Ok.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(239, 128);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(86, 46);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // AddNewIncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 203);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Ok);
            this.Controls.Add(this.ValueUpDown);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ValueLabel);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewIncomeForm";
            this.Text = "Adaugă un venit nou";
            ((System.ComponentModel.ISupportInitialize)(this.ValueUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.NumericUpDown ValueUpDown;
        private System.Windows.Forms.Button Button_Ok;
        private System.Windows.Forms.Button Button_Cancel;
    }
}
namespace BudgetWatcher.Forms.Add
{
    partial class AddNewFrequencyForm
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
            this.DaysLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.DaysUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DaysUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Ok
            // 
            this.Button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Ok.Enabled = false;
            this.Button_Ok.Location = new System.Drawing.Point(65, 140);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(86, 46);
            this.Button_Ok.TabIndex = 5;
            this.Button_Ok.Text = "Ok";
            this.Button_Ok.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(235, 140);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(86, 46);
            this.Button_Cancel.TabIndex = 6;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(21, 34);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(65, 16);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Denumire";
            // 
            // DaysLabel
            // 
            this.DaysLabel.AutoSize = true;
            this.DaysLabel.Location = new System.Drawing.Point(21, 73);
            this.DaysLabel.Name = "DaysLabel";
            this.DaysLabel.Size = new System.Drawing.Size(94, 16);
            this.DaysLabel.TabIndex = 8;
            this.DaysLabel.Text = "Perioada (zile)";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(166, 34);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(220, 22);
            this.NameTextBox.TabIndex = 9;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // DaysUpDown
            // 
            this.DaysUpDown.Location = new System.Drawing.Point(166, 73);
            this.DaysUpDown.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.DaysUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DaysUpDown.Name = "DaysUpDown";
            this.DaysUpDown.Size = new System.Drawing.Size(220, 22);
            this.DaysUpDown.TabIndex = 10;
            this.DaysUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DaysUpDown.ThousandsSeparator = true;
            this.DaysUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddNewFrequencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 221);
            this.Controls.Add(this.DaysUpDown);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.DaysLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddNewFrequencyForm";
            this.Text = "AddNewFrequencyForm";
            ((System.ComponentModel.ISupportInitialize)(this.DaysUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Ok;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DaysLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.NumericUpDown DaysUpDown;
    }
}
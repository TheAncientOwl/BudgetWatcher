namespace BudgetWatcher.Forms.Generate
{
    partial class HistoryForm
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
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartLabel = new System.Windows.Forms.Label();
            this.FinalDate = new System.Windows.Forms.Label();
            this.Button_Ok = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.WordFilePath = new System.Windows.Forms.TextBox();
            this.ChooseWordFilePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(150, 34);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(277, 22);
            this.StartDateTimePicker.TabIndex = 0;
            this.StartDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // FinalDateTimePicker
            // 
            this.FinalDateTimePicker.Location = new System.Drawing.Point(150, 84);
            this.FinalDateTimePicker.Name = "FinalDateTimePicker";
            this.FinalDateTimePicker.Size = new System.Drawing.Size(277, 22);
            this.FinalDateTimePicker.TabIndex = 1;
            this.FinalDateTimePicker.ValueChanged += new System.EventHandler(this.FinalDateTimePicker_ValueChanged);
            // 
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(45, 39);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(77, 16);
            this.StartLabel.TabIndex = 2;
            this.StartLabel.Text = "Data inițială";
            // 
            // FinalDate
            // 
            this.FinalDate.AutoSize = true;
            this.FinalDate.Location = new System.Drawing.Point(45, 84);
            this.FinalDate.Name = "FinalDate";
            this.FinalDate.Size = new System.Drawing.Size(71, 16);
            this.FinalDate.TabIndex = 3;
            this.FinalDate.Text = "Data finală";
            // 
            // Button_Ok
            // 
            this.Button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Ok.Enabled = false;
            this.Button_Ok.Location = new System.Drawing.Point(82, 219);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(104, 64);
            this.Button_Ok.TabIndex = 6;
            this.Button_Ok.Text = "Ok";
            this.Button_Ok.UseVisualStyleBackColor = true;
            this.Button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(276, 219);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(104, 64);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // WordFilePath
            // 
            this.WordFilePath.Location = new System.Drawing.Point(163, 155);
            this.WordFilePath.Name = "WordFilePath";
            this.WordFilePath.ReadOnly = true;
            this.WordFilePath.Size = new System.Drawing.Size(278, 22);
            this.WordFilePath.TabIndex = 8;
            // 
            // ChooseWordFilePath
            // 
            this.ChooseWordFilePath.Location = new System.Drawing.Point(27, 132);
            this.ChooseWordFilePath.Name = "ChooseWordFilePath";
            this.ChooseWordFilePath.Size = new System.Drawing.Size(121, 68);
            this.ChooseWordFilePath.TabIndex = 9;
            this.ChooseWordFilePath.Text = "Alegeti locația unde doriți să salvați fișierul";
            this.ChooseWordFilePath.UseVisualStyleBackColor = true;
            this.ChooseWordFilePath.Click += new System.EventHandler(this.ChooseWordFilePath_Click);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 304);
            this.Controls.Add(this.ChooseWordFilePath);
            this.Controls.Add(this.WordFilePath);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Ok);
            this.Controls.Add(this.FinalDate);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.FinalDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generează istoric";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker FinalDateTimePicker;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label FinalDate;
        private System.Windows.Forms.Button Button_Ok;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.TextBox WordFilePath;
        private System.Windows.Forms.Button ChooseWordFilePath;
    }
}
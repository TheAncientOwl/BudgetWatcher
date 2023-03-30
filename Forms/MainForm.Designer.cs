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
            this.SuspendLayout();
            // 
            // Button_OpenAddIncomeForm
            // 
            this.Button_OpenAddIncomeForm.Location = new System.Drawing.Point(12, 21);
            this.Button_OpenAddIncomeForm.Name = "Button_OpenAddIncomeForm";
            this.Button_OpenAddIncomeForm.Size = new System.Drawing.Size(146, 56);
            this.Button_OpenAddIncomeForm.TabIndex = 0;
            this.Button_OpenAddIncomeForm.Text = "Adaugă un venit nou";
            this.Button_OpenAddIncomeForm.UseVisualStyleBackColor = true;
            this.Button_OpenAddIncomeForm.Click += new System.EventHandler(this.Button_OpenAddIncomeForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_OpenAddIncomeForm);
            this.Name = "MainForm";
            this.Text = "BudgetWatcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OpenAddIncomeForm;
    }
}
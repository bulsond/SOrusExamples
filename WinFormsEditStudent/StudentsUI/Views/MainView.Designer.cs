namespace StudentsUI.Views
{
    partial class MainView
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
            this._dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this._comboBoxGroups = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewStudents
            // 
            this._dataGridViewStudents.AllowUserToAddRows = false;
            this._dataGridViewStudents.AllowUserToDeleteRows = false;
            this._dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewStudents.Location = new System.Drawing.Point(145, 103);
            this._dataGridViewStudents.Name = "_dataGridViewStudents";
            this._dataGridViewStudents.ReadOnly = true;
            this._dataGridViewStudents.Size = new System.Drawing.Size(240, 150);
            this._dataGridViewStudents.TabIndex = 0;
            // 
            // _comboBoxGroups
            // 
            this._comboBoxGroups.FormattingEnabled = true;
            this._comboBoxGroups.Location = new System.Drawing.Point(205, 59);
            this._comboBoxGroups.Name = "_comboBoxGroups";
            this._comboBoxGroups.Size = new System.Drawing.Size(121, 21);
            this._comboBoxGroups.TabIndex = 1;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 381);
            this.Controls.Add(this._comboBoxGroups);
            this.Controls.Add(this._dataGridViewStudents);
            this.Name = "MainView";
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewStudents;
        private System.Windows.Forms.ComboBox _comboBoxGroups;
    }
}
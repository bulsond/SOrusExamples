namespace DataBase1.Views
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
            this._comboBoxGroups = new System.Windows.Forms.ComboBox();
            this._dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroupNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonAddStudent = new System.Windows.Forms.Button();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._statusLabelCountStudents = new System.Windows.Forms.ToolStripStatusLabel();
            this._buttonEditStudent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewStudents)).BeginInit();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _comboBoxGroups
            // 
            this._comboBoxGroups.FormattingEnabled = true;
            this._comboBoxGroups.Location = new System.Drawing.Point(204, 24);
            this._comboBoxGroups.Name = "_comboBoxGroups";
            this._comboBoxGroups.Size = new System.Drawing.Size(121, 21);
            this._comboBoxGroups.TabIndex = 3;
            // 
            // _dataGridViewStudents
            // 
            this._dataGridViewStudents.AllowUserToAddRows = false;
            this._dataGridViewStudents.AllowUserToDeleteRows = false;
            this._dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnLastName,
            this.ColumnFirstName,
            this.ColumnGroupNumber});
            this._dataGridViewStudents.Location = new System.Drawing.Point(27, 63);
            this._dataGridViewStudents.MultiSelect = false;
            this._dataGridViewStudents.Name = "_dataGridViewStudents";
            this._dataGridViewStudents.ReadOnly = true;
            this._dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewStudents.Size = new System.Drawing.Size(523, 212);
            this._dataGridViewStudents.TabIndex = 2;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.DataPropertyName = "Number";
            this.ColumnNumber.HeaderText = "н/п";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 50;
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.DataPropertyName = "FirstName";
            this.ColumnLastName.HeaderText = "Фамилия";
            this.ColumnLastName.Name = "ColumnLastName";
            this.ColumnLastName.ReadOnly = true;
            this.ColumnLastName.Width = 200;
            // 
            // ColumnFirstName
            // 
            this.ColumnFirstName.DataPropertyName = "LastName";
            this.ColumnFirstName.HeaderText = "Имя";
            this.ColumnFirstName.Name = "ColumnFirstName";
            this.ColumnFirstName.ReadOnly = true;
            this.ColumnFirstName.Width = 150;
            // 
            // ColumnGroupNumber
            // 
            this.ColumnGroupNumber.DataPropertyName = "GroupNumber";
            this.ColumnGroupNumber.HeaderText = "Группа";
            this.ColumnGroupNumber.Name = "ColumnGroupNumber";
            this.ColumnGroupNumber.ReadOnly = true;
            this.ColumnGroupNumber.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Студенты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Группа";
            // 
            // _buttonAddStudent
            // 
            this._buttonAddStudent.Location = new System.Drawing.Point(27, 313);
            this._buttonAddStudent.Name = "_buttonAddStudent";
            this._buttonAddStudent.Size = new System.Drawing.Size(114, 23);
            this._buttonAddStudent.TabIndex = 7;
            this._buttonAddStudent.Text = "Новый студент";
            this._buttonAddStudent.UseVisualStyleBackColor = true;
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabelCountStudents});
            this._statusStrip.Location = new System.Drawing.Point(0, 428);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(573, 22);
            this._statusStrip.TabIndex = 8;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _statusLabelCountStudents
            // 
            this._statusLabelCountStudents.Name = "_statusLabelCountStudents";
            this._statusLabelCountStudents.Size = new System.Drawing.Size(118, 17);
            this._statusLabelCountStudents.Text = "toolStripStatusLabel1";
            // 
            // _buttonEditStudent
            // 
            this._buttonEditStudent.Location = new System.Drawing.Point(147, 313);
            this._buttonEditStudent.Name = "_buttonEditStudent";
            this._buttonEditStudent.Size = new System.Drawing.Size(155, 23);
            this._buttonEditStudent.TabIndex = 7;
            this._buttonEditStudent.Text = "Редактировать студента";
            this._buttonEditStudent.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 450);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._buttonEditStudent);
            this.Controls.Add(this._buttonAddStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._comboBoxGroups);
            this.Controls.Add(this._dataGridViewStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewStudents)).EndInit();
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxGroups;
        private System.Windows.Forms.DataGridView _dataGridViewStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroupNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _buttonAddStudent;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabelCountStudents;
        private System.Windows.Forms.Button _buttonEditStudent;
    }
}
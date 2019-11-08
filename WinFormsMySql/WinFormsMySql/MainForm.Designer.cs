namespace WinFormsMySql
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
            this._groupBoxEmployee = new System.Windows.Forms.GroupBox();
            this._buttonPrev = new System.Windows.Forms.Button();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonNext = new System.Windows.Forms.Button();
            this._buttonRemove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxPhone = new System.Windows.Forms.TextBox();
            this._textBoxLastName = new System.Windows.Forms.TextBox();
            this._textBoxFirstName = new System.Windows.Forms.TextBox();
            this._dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this._columnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._buttonSave = new System.Windows.Forms.Button();
            this._groupBoxEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // _groupBoxEmployee
            // 
            this._groupBoxEmployee.Controls.Add(this._buttonPrev);
            this._groupBoxEmployee.Controls.Add(this._buttonSave);
            this._groupBoxEmployee.Controls.Add(this._buttonAdd);
            this._groupBoxEmployee.Controls.Add(this._buttonNext);
            this._groupBoxEmployee.Controls.Add(this._buttonRemove);
            this._groupBoxEmployee.Controls.Add(this.label3);
            this._groupBoxEmployee.Controls.Add(this.label2);
            this._groupBoxEmployee.Controls.Add(this.label1);
            this._groupBoxEmployee.Controls.Add(this._textBoxPhone);
            this._groupBoxEmployee.Controls.Add(this._textBoxLastName);
            this._groupBoxEmployee.Controls.Add(this._textBoxFirstName);
            this._groupBoxEmployee.Location = new System.Drawing.Point(23, 25);
            this._groupBoxEmployee.Name = "_groupBoxEmployee";
            this._groupBoxEmployee.Size = new System.Drawing.Size(291, 200);
            this._groupBoxEmployee.TabIndex = 0;
            this._groupBoxEmployee.TabStop = false;
            this._groupBoxEmployee.Text = "Сотрудник";
            // 
            // _buttonPrev
            // 
            this._buttonPrev.Location = new System.Drawing.Point(76, 156);
            this._buttonPrev.Name = "_buttonPrev";
            this._buttonPrev.Size = new System.Drawing.Size(75, 23);
            this._buttonPrev.TabIndex = 6;
            this._buttonPrev.Text = "Назад";
            this._buttonPrev.UseVisualStyleBackColor = true;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Location = new System.Drawing.Point(34, 121);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(75, 23);
            this._buttonAdd.TabIndex = 4;
            this._buttonAdd.Text = "Добавить";
            this._buttonAdd.UseVisualStyleBackColor = true;
            // 
            // _buttonNext
            // 
            this._buttonNext.Location = new System.Drawing.Point(166, 156);
            this._buttonNext.Name = "_buttonNext";
            this._buttonNext.Size = new System.Drawing.Size(75, 23);
            this._buttonNext.TabIndex = 7;
            this._buttonNext.Text = "Вперед";
            this._buttonNext.UseVisualStyleBackColor = true;
            // 
            // _buttonRemove
            // 
            this._buttonRemove.Location = new System.Drawing.Point(196, 121);
            this._buttonRemove.Name = "_buttonRemove";
            this._buttonRemove.Size = new System.Drawing.Size(75, 23);
            this._buttonRemove.TabIndex = 5;
            this._buttonRemove.Text = "Удалить";
            this._buttonRemove.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Телефон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // _textBoxPhone
            // 
            this._textBoxPhone.Location = new System.Drawing.Point(96, 80);
            this._textBoxPhone.Name = "_textBoxPhone";
            this._textBoxPhone.Size = new System.Drawing.Size(154, 20);
            this._textBoxPhone.TabIndex = 3;
            // 
            // _textBoxLastName
            // 
            this._textBoxLastName.Location = new System.Drawing.Point(96, 54);
            this._textBoxLastName.Name = "_textBoxLastName";
            this._textBoxLastName.Size = new System.Drawing.Size(154, 20);
            this._textBoxLastName.TabIndex = 2;
            // 
            // _textBoxFirstName
            // 
            this._textBoxFirstName.Location = new System.Drawing.Point(96, 28);
            this._textBoxFirstName.Name = "_textBoxFirstName";
            this._textBoxFirstName.Size = new System.Drawing.Size(154, 20);
            this._textBoxFirstName.TabIndex = 1;
            // 
            // _dataGridViewEmployees
            // 
            this._dataGridViewEmployees.AllowUserToAddRows = false;
            this._dataGridViewEmployees.AllowUserToDeleteRows = false;
            this._dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnNumber,
            this._columnFirstName,
            this._columnLastName,
            this._columnPhone});
            this._dataGridViewEmployees.Location = new System.Drawing.Point(337, 25);
            this._dataGridViewEmployees.Name = "_dataGridViewEmployees";
            this._dataGridViewEmployees.ReadOnly = true;
            this._dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewEmployees.Size = new System.Drawing.Size(496, 200);
            this._dataGridViewEmployees.TabIndex = 1;
            // 
            // _columnNumber
            // 
            this._columnNumber.HeaderText = "№";
            this._columnNumber.Name = "_columnNumber";
            this._columnNumber.ReadOnly = true;
            this._columnNumber.Width = 50;
            // 
            // _columnFirstName
            // 
            this._columnFirstName.HeaderText = "Имя";
            this._columnFirstName.Name = "_columnFirstName";
            this._columnFirstName.ReadOnly = true;
            this._columnFirstName.Width = 150;
            // 
            // _columnLastName
            // 
            this._columnLastName.HeaderText = "Фамилия";
            this._columnLastName.Name = "_columnLastName";
            this._columnLastName.ReadOnly = true;
            this._columnLastName.Width = 150;
            // 
            // _columnPhone
            // 
            this._columnPhone.HeaderText = "Телефон";
            this._columnPhone.Name = "_columnPhone";
            this._columnPhone.ReadOnly = true;
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(115, 121);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 23);
            this._buttonSave.TabIndex = 4;
            this._buttonSave.Text = "Сохранить";
            this._buttonSave.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 261);
            this.Controls.Add(this._dataGridViewEmployees);
            this.Controls.Add(this._groupBoxEmployee);
            this.Name = "MainForm";
            this.Text = "Form1";
            this._groupBoxEmployee.ResumeLayout(false);
            this._groupBoxEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewEmployees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupBoxEmployee;
        private System.Windows.Forms.Button _buttonPrev;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.Button _buttonNext;
        private System.Windows.Forms.Button _buttonRemove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxPhone;
        private System.Windows.Forms.TextBox _textBoxLastName;
        private System.Windows.Forms.TextBox _textBoxFirstName;
        private System.Windows.Forms.DataGridView _dataGridViewEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPhone;
        private System.Windows.Forms.Button _buttonSave;
    }
}


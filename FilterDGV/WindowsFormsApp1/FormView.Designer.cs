namespace WindowsFormsApp1
{
    partial class FormView
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
            this._dataGridViewPeople = new System.Windows.Forms.DataGridView();
            this.ColumnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._textBoxFindFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxFindLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._textBoxFindAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewPeople
            // 
            this._dataGridViewPeople.AllowUserToAddRows = false;
            this._dataGridViewPeople.AllowUserToDeleteRows = false;
            this._dataGridViewPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFirstName,
            this.ColumnLastName,
            this.ColumnAge});
            this._dataGridViewPeople.Location = new System.Drawing.Point(61, 80);
            this._dataGridViewPeople.Name = "_dataGridViewPeople";
            this._dataGridViewPeople.ReadOnly = true;
            this._dataGridViewPeople.Size = new System.Drawing.Size(467, 286);
            this._dataGridViewPeople.TabIndex = 0;
            // 
            // ColumnFirstName
            // 
            this.ColumnFirstName.DataPropertyName = "FirstName";
            this.ColumnFirstName.HeaderText = "Имя";
            this.ColumnFirstName.Name = "ColumnFirstName";
            this.ColumnFirstName.ReadOnly = true;
            this.ColumnFirstName.Width = 150;
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.DataPropertyName = "LastName";
            this.ColumnLastName.HeaderText = "Фамилия";
            this.ColumnLastName.Name = "ColumnLastName";
            this.ColumnLastName.ReadOnly = true;
            this.ColumnLastName.Width = 200;
            // 
            // ColumnAge
            // 
            this.ColumnAge.DataPropertyName = "Age";
            this.ColumnAge.HeaderText = "Возраст";
            this.ColumnAge.Name = "ColumnAge";
            this.ColumnAge.ReadOnly = true;
            this.ColumnAge.Width = 70;
            // 
            // _textBoxFindFirstName
            // 
            this._textBoxFindFirstName.Location = new System.Drawing.Point(120, 22);
            this._textBoxFindFirstName.Name = "_textBoxFindFirstName";
            this._textBoxFindFirstName.Size = new System.Drawing.Size(111, 20);
            this._textBoxFindFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Поиск по Имени";
            // 
            // _textBoxFindLastName
            // 
            this._textBoxFindLastName.Location = new System.Drawing.Point(299, 22);
            this._textBoxFindLastName.Name = "_textBoxFindLastName";
            this._textBoxFindLastName.Size = new System.Drawing.Size(140, 20);
            this._textBoxFindLastName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилии";
            // 
            // _textBoxFindAge
            // 
            this._textBoxFindAge.Location = new System.Drawing.Point(503, 22);
            this._textBoxFindAge.Name = "_textBoxFindAge";
            this._textBoxFindAge.Size = new System.Drawing.Size(62, 20);
            this._textBoxFindAge.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Старше";
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 393);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._textBoxFindAge);
            this.Controls.Add(this._textBoxFindLastName);
            this.Controls.Add(this._textBoxFindFirstName);
            this.Controls.Add(this._dataGridViewPeople);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAge;
        private System.Windows.Forms.TextBox _textBoxFindFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxFindLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBoxFindAge;
        private System.Windows.Forms.Label label3;
    }
}


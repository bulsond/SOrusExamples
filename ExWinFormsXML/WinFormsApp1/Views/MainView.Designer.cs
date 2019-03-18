namespace WinFormsApp1.Views
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
            this._dataGridViewPeople = new System.Windows.Forms.DataGridView();
            this._columnPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPersonSurename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPersonBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPersonSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPersonWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._buttonAddPerson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewPeople
            // 
            this._dataGridViewPeople.AllowUserToAddRows = false;
            this._dataGridViewPeople.AllowUserToDeleteRows = false;
            this._dataGridViewPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnPersonName,
            this._columnPersonSurename,
            this._columnPersonBirthday,
            this._columnPersonSex,
            this._columnPersonWeight});
            this._dataGridViewPeople.Location = new System.Drawing.Point(26, 26);
            this._dataGridViewPeople.Name = "_dataGridViewPeople";
            this._dataGridViewPeople.ReadOnly = true;
            this._dataGridViewPeople.Size = new System.Drawing.Size(545, 214);
            this._dataGridViewPeople.TabIndex = 0;
            // 
            // _columnPersonName
            // 
            this._columnPersonName.HeaderText = "Имя";
            this._columnPersonName.Name = "_columnPersonName";
            this._columnPersonName.ReadOnly = true;
            // 
            // _columnPersonSurename
            // 
            this._columnPersonSurename.HeaderText = "Фамилия";
            this._columnPersonSurename.Name = "_columnPersonSurename";
            this._columnPersonSurename.ReadOnly = true;
            // 
            // _columnPersonBirthday
            // 
            this._columnPersonBirthday.HeaderText = "Дата рождения";
            this._columnPersonBirthday.Name = "_columnPersonBirthday";
            this._columnPersonBirthday.ReadOnly = true;
            // 
            // _columnPersonSex
            // 
            this._columnPersonSex.HeaderText = "Пол";
            this._columnPersonSex.Name = "_columnPersonSex";
            this._columnPersonSex.ReadOnly = true;
            // 
            // _columnPersonWeight
            // 
            this._columnPersonWeight.HeaderText = "Вес";
            this._columnPersonWeight.Name = "_columnPersonWeight";
            this._columnPersonWeight.ReadOnly = true;
            // 
            // _buttonAddPerson
            // 
            this._buttonAddPerson.Location = new System.Drawing.Point(256, 263);
            this._buttonAddPerson.Name = "_buttonAddPerson";
            this._buttonAddPerson.Size = new System.Drawing.Size(75, 23);
            this._buttonAddPerson.TabIndex = 1;
            this._buttonAddPerson.Text = "Добавить";
            this._buttonAddPerson.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 319);
            this.Controls.Add(this._buttonAddPerson);
            this.Controls.Add(this._dataGridViewPeople);
            this.Name = "MainView";
            this.Text = "MainView";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewPeople)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPersonSurename;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPersonBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPersonSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPersonWeight;
        private System.Windows.Forms.Button _buttonAddPerson;
    }
}
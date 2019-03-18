namespace WinFormsApp1.Views
{
    partial class EditView
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxSurename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this._textBoxWeight = new System.Windows.Forms.TextBox();
            this._buttonOK = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._radioButtonMale = new System.Windows.Forms.RadioButton();
            this._radioButtonFemale = new System.Windows.Forms.RadioButton();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._textBoxSex = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // _textBoxSurename
            // 
            this._textBoxSurename.Location = new System.Drawing.Point(120, 69);
            this._textBoxSurename.Name = "_textBoxSurename";
            this._textBoxSurename.Size = new System.Drawing.Size(200, 20);
            this._textBoxSurename.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Имя";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(120, 43);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(200, 20);
            this._textBoxName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Пол";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата рождения";
            // 
            // _dateTimePickerBirthday
            // 
            this._dateTimePickerBirthday.Location = new System.Drawing.Point(120, 124);
            this._dateTimePickerBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this._dateTimePickerBirthday.Name = "_dateTimePickerBirthday";
            this._dateTimePickerBirthday.Size = new System.Drawing.Size(200, 20);
            this._dateTimePickerBirthday.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Вес в кг.";
            // 
            // _textBoxWeight
            // 
            this._textBoxWeight.Location = new System.Drawing.Point(120, 152);
            this._textBoxWeight.Name = "_textBoxWeight";
            this._textBoxWeight.Size = new System.Drawing.Size(57, 20);
            this._textBoxWeight.TabIndex = 1;
            // 
            // _buttonOK
            // 
            this._buttonOK.Location = new System.Drawing.Point(152, 203);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 23);
            this._buttonOK.TabIndex = 4;
            this._buttonOK.Text = "OK";
            this._buttonOK.UseVisualStyleBackColor = true;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(247, 203);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 4;
            this._buttonCancel.Text = "Отмена";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._textBoxSex);
            this.panel1.Controls.Add(this._radioButtonFemale);
            this.panel1.Controls.Add(this._radioButtonMale);
            this.panel1.Location = new System.Drawing.Point(122, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 23);
            this.panel1.TabIndex = 5;
            // 
            // _radioButtonMale
            // 
            this._radioButtonMale.AutoSize = true;
            this._radioButtonMale.Location = new System.Drawing.Point(3, 3);
            this._radioButtonMale.Name = "_radioButtonMale";
            this._radioButtonMale.Size = new System.Drawing.Size(34, 17);
            this._radioButtonMale.TabIndex = 0;
            this._radioButtonMale.Text = "М";
            this._radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // _radioButtonFemale
            // 
            this._radioButtonFemale.AutoSize = true;
            this._radioButtonFemale.Location = new System.Drawing.Point(54, 3);
            this._radioButtonFemale.Name = "_radioButtonFemale";
            this._radioButtonFemale.Size = new System.Drawing.Size(36, 17);
            this._radioButtonFemale.TabIndex = 1;
            this._radioButtonFemale.Text = "Ж";
            this._radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // _textBoxSex
            // 
            this._textBoxSex.Enabled = false;
            this._textBoxSex.Location = new System.Drawing.Point(106, 1);
            this._textBoxSex.Name = "_textBoxSex";
            this._textBoxSex.Size = new System.Drawing.Size(92, 20);
            this._textBoxSex.TabIndex = 2;
            // 
            // EditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 252);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonOK);
            this.Controls.Add(this._dateTimePickerBirthday);
            this.Controls.Add(this._textBoxWeight);
            this.Controls.Add(this._textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._textBoxSurename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditView";
            this.Text = "EditView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxSurename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _dateTimePickerBirthday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _textBoxWeight;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton _radioButtonFemale;
        private System.Windows.Forms.RadioButton _radioButtonMale;
        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.TextBox _textBoxSex;
    }
}
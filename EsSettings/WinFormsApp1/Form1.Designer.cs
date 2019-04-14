namespace WinFormsApp1
{
    partial class Form1
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
            this._buttonSaveInput = new System.Windows.Forms.Button();
            this._buttonReadOutput = new System.Windows.Forms.Button();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this._numericUpDownInput = new System.Windows.Forms.NumericUpDown();
            this._textBoxInput = new System.Windows.Forms.TextBox();
            this._dateTimePickerInput = new System.Windows.Forms.DateTimePicker();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this._dateTimePickerOutput = new System.Windows.Forms.DateTimePicker();
            this._textBoxOutput = new System.Windows.Forms.TextBox();
            this._numericUpDownOutput = new System.Windows.Forms.NumericUpDown();
            this.groupBoxInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownInput)).BeginInit();
            this.groupBoxOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonSaveInput
            // 
            this._buttonSaveInput.Location = new System.Drawing.Point(172, 221);
            this._buttonSaveInput.Name = "_buttonSaveInput";
            this._buttonSaveInput.Size = new System.Drawing.Size(75, 23);
            this._buttonSaveInput.TabIndex = 1;
            this._buttonSaveInput.Text = "Сохранить";
            this._buttonSaveInput.UseVisualStyleBackColor = true;
            // 
            // _buttonReadOutput
            // 
            this._buttonReadOutput.Location = new System.Drawing.Point(481, 221);
            this._buttonReadOutput.Name = "_buttonReadOutput";
            this._buttonReadOutput.Size = new System.Drawing.Size(75, 23);
            this._buttonReadOutput.TabIndex = 2;
            this._buttonReadOutput.Text = "Прочитать";
            this._buttonReadOutput.UseVisualStyleBackColor = true;
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this._dateTimePickerInput);
            this.groupBoxInput.Controls.Add(this._textBoxInput);
            this.groupBoxInput.Controls.Add(this._numericUpDownInput);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 12);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(235, 191);
            this.groupBoxInput.TabIndex = 3;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Сохранение";
            // 
            // _numericUpDownInput
            // 
            this._numericUpDownInput.Location = new System.Drawing.Point(14, 31);
            this._numericUpDownInput.Name = "_numericUpDownInput";
            this._numericUpDownInput.Size = new System.Drawing.Size(61, 20);
            this._numericUpDownInput.TabIndex = 1;
            // 
            // _textBoxInput
            // 
            this._textBoxInput.Location = new System.Drawing.Point(14, 76);
            this._textBoxInput.Name = "_textBoxInput";
            this._textBoxInput.Size = new System.Drawing.Size(188, 20);
            this._textBoxInput.TabIndex = 2;
            // 
            // _dateTimePickerInput
            // 
            this._dateTimePickerInput.Location = new System.Drawing.Point(14, 127);
            this._dateTimePickerInput.Name = "_dateTimePickerInput";
            this._dateTimePickerInput.Size = new System.Drawing.Size(200, 20);
            this._dateTimePickerInput.TabIndex = 3;
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this._dateTimePickerOutput);
            this.groupBoxOutput.Controls.Add(this._textBoxOutput);
            this.groupBoxOutput.Controls.Add(this._numericUpDownOutput);
            this.groupBoxOutput.Location = new System.Drawing.Point(321, 12);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(235, 191);
            this.groupBoxOutput.TabIndex = 4;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Чтение";
            // 
            // _dateTimePickerOutput
            // 
            this._dateTimePickerOutput.Location = new System.Drawing.Point(14, 127);
            this._dateTimePickerOutput.Name = "_dateTimePickerOutput";
            this._dateTimePickerOutput.Size = new System.Drawing.Size(200, 20);
            this._dateTimePickerOutput.TabIndex = 3;
            // 
            // _textBoxOutput
            // 
            this._textBoxOutput.Location = new System.Drawing.Point(14, 76);
            this._textBoxOutput.Name = "_textBoxOutput";
            this._textBoxOutput.Size = new System.Drawing.Size(188, 20);
            this._textBoxOutput.TabIndex = 2;
            // 
            // _numericUpDownOutput
            // 
            this._numericUpDownOutput.Location = new System.Drawing.Point(14, 31);
            this._numericUpDownOutput.Name = "_numericUpDownOutput";
            this._numericUpDownOutput.Size = new System.Drawing.Size(61, 20);
            this._numericUpDownOutput.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 259);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxInput);
            this.Controls.Add(this._buttonReadOutput);
            this.Controls.Add(this._buttonSaveInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownInput)).EndInit();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numericUpDownOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _buttonSaveInput;
        private System.Windows.Forms.Button _buttonReadOutput;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.DateTimePicker _dateTimePickerInput;
        private System.Windows.Forms.TextBox _textBoxInput;
        private System.Windows.Forms.NumericUpDown _numericUpDownInput;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.DateTimePicker _dateTimePickerOutput;
        private System.Windows.Forms.TextBox _textBoxOutput;
        private System.Windows.Forms.NumericUpDown _numericUpDownOutput;
    }
}


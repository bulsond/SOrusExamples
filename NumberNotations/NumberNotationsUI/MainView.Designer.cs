namespace NumberNotationsUI
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
            this._textBoxOutput = new System.Windows.Forms.TextBox();
            this._comboBoxOutput = new System.Windows.Forms.ComboBox();
            this._textBoxInput = new System.Windows.Forms.TextBox();
            this._comboBoxInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _textBoxOutput
            // 
            this._textBoxOutput.Location = new System.Drawing.Point(201, 61);
            this._textBoxOutput.Name = "_textBoxOutput";
            this._textBoxOutput.ReadOnly = true;
            this._textBoxOutput.Size = new System.Drawing.Size(231, 20);
            this._textBoxOutput.TabIndex = 5;
            // 
            // _comboBoxOutput
            // 
            this._comboBoxOutput.FormattingEnabled = true;
            this._comboBoxOutput.Location = new System.Drawing.Point(12, 61);
            this._comboBoxOutput.Name = "_comboBoxOutput";
            this._comboBoxOutput.Size = new System.Drawing.Size(173, 21);
            this._comboBoxOutput.TabIndex = 6;
            // 
            // _textBoxInput
            // 
            this._textBoxInput.Location = new System.Drawing.Point(201, 12);
            this._textBoxInput.Name = "_textBoxInput";
            this._textBoxInput.Size = new System.Drawing.Size(231, 20);
            this._textBoxInput.TabIndex = 3;
            // 
            // _comboBoxInput
            // 
            this._comboBoxInput.FormattingEnabled = true;
            this._comboBoxInput.Location = new System.Drawing.Point(12, 12);
            this._comboBoxInput.Name = "_comboBoxInput";
            this._comboBoxInput.Size = new System.Drawing.Size(173, 21);
            this._comboBoxInput.TabIndex = 4;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 114);
            this.Controls.Add(this._textBoxOutput);
            this.Controls.Add(this._comboBoxOutput);
            this.Controls.Add(this._textBoxInput);
            this.Controls.Add(this._comboBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textBoxOutput;
        private System.Windows.Forms.ComboBox _comboBoxOutput;
        private System.Windows.Forms.TextBox _textBoxInput;
        private System.Windows.Forms.ComboBox _comboBoxInput;
    }
}


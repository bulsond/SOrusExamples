namespace WinFormsEditTests.Forms
{
    partial class FormChallenge
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
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxName = new System.Windows.Forms.TextBox();
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название задания";
            // 
            // _textBoxName
            // 
            this._textBoxName.Location = new System.Drawing.Point(26, 38);
            this._textBoxName.Name = "_textBoxName";
            this._textBoxName.Size = new System.Drawing.Size(261, 20);
            this._textBoxName.TabIndex = 1;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Location = new System.Drawing.Point(120, 112);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 2;
            this._buttonCancel.Text = "Отмена";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOk
            // 
            this._buttonOk.Location = new System.Drawing.Point(212, 112);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(75, 23);
            this._buttonOk.TabIndex = 3;
            this._buttonOk.Text = "OK";
            this._buttonOk.UseVisualStyleBackColor = true;
            // 
            // FormChallenge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 168);
            this.Controls.Add(this._buttonOk);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._textBoxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChallenge";
            this.Text = "FormChallenge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxName;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.Button _buttonOk;
    }
}
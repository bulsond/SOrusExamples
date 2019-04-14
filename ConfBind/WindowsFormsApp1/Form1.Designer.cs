namespace WindowsFormsApp1
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
            this._comboBoxKeys = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _comboBoxKeys
            // 
            this._comboBoxKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxKeys.FormattingEnabled = true;
            this._comboBoxKeys.Location = new System.Drawing.Point(62, 26);
            this._comboBoxKeys.Name = "_comboBoxKeys";
            this._comboBoxKeys.Size = new System.Drawing.Size(121, 21);
            this._comboBoxKeys.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 95);
            this.Controls.Add(this._comboBoxKeys);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox _comboBoxKeys;
    }
}


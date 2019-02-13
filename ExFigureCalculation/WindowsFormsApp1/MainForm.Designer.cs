namespace WindowsFormsApp1
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
            this._comboBoxFigures = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._panelOutput = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _comboBoxFigures
            // 
            this._comboBoxFigures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxFigures.FormattingEnabled = true;
            this._comboBoxFigures.Location = new System.Drawing.Point(75, 21);
            this._comboBoxFigures.Name = "_comboBoxFigures";
            this._comboBoxFigures.Size = new System.Drawing.Size(154, 21);
            this._comboBoxFigures.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фигура";
            // 
            // _panelOutput
            // 
            this._panelOutput.Location = new System.Drawing.Point(12, 68);
            this._panelOutput.Name = "_panelOutput";
            this._panelOutput.Size = new System.Drawing.Size(330, 241);
            this._panelOutput.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 321);
            this.Controls.Add(this._panelOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._comboBoxFigures);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _comboBoxFigures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel _panelOutput;
    }
}


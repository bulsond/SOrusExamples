namespace UIdb
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
            this._pictureBoxOutput = new System.Windows.Forms.PictureBox();
            this._listBoxNames = new System.Windows.Forms.ListBox();
            this._textBoxDesc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBoxOutput
            // 
            this._pictureBoxOutput.Location = new System.Drawing.Point(264, 12);
            this._pictureBoxOutput.Name = "_pictureBoxOutput";
            this._pictureBoxOutput.Size = new System.Drawing.Size(524, 342);
            this._pictureBoxOutput.TabIndex = 0;
            this._pictureBoxOutput.TabStop = false;
            // 
            // _listBoxNames
            // 
            this._listBoxNames.FormattingEnabled = true;
            this._listBoxNames.Location = new System.Drawing.Point(12, 12);
            this._listBoxNames.Name = "_listBoxNames";
            this._listBoxNames.Size = new System.Drawing.Size(213, 368);
            this._listBoxNames.TabIndex = 1;
            // 
            // _textBoxDesc
            // 
            this._textBoxDesc.Location = new System.Drawing.Point(264, 360);
            this._textBoxDesc.Name = "_textBoxDesc";
            this._textBoxDesc.ReadOnly = true;
            this._textBoxDesc.Size = new System.Drawing.Size(524, 20);
            this._textBoxDesc.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this._textBoxDesc);
            this.Controls.Add(this._listBoxNames);
            this.Controls.Add(this._pictureBoxOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBoxOutput;
        private System.Windows.Forms.ListBox _listBoxNames;
        private System.Windows.Forms.TextBox _textBoxDesc;
    }
}


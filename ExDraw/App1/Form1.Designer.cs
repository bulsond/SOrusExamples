namespace App1
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
            this._listBoxFigures = new System.Windows.Forms.ListBox();
            this._panelCanvas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _listBoxFigures
            // 
            this._listBoxFigures.FormattingEnabled = true;
            this._listBoxFigures.Location = new System.Drawing.Point(23, 23);
            this._listBoxFigures.Name = "_listBoxFigures";
            this._listBoxFigures.Size = new System.Drawing.Size(97, 160);
            this._listBoxFigures.TabIndex = 0;
            // 
            // _panelCanvas
            // 
            this._panelCanvas.BackColor = System.Drawing.SystemColors.Window;
            this._panelCanvas.Location = new System.Drawing.Point(159, 23);
            this._panelCanvas.Name = "_panelCanvas";
            this._panelCanvas.Size = new System.Drawing.Size(573, 392);
            this._panelCanvas.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 447);
            this.Controls.Add(this._panelCanvas);
            this.Controls.Add(this._listBoxFigures);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _listBoxFigures;
        private System.Windows.Forms.Panel _panelCanvas;
    }
}


namespace WinFormsAngleSharp
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
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxAddress = new System.Windows.Forms.TextBox();
            this._buttonGet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._textBoxHeader = new System.Windows.Forms.TextBox();
            this._textBoxParagraphs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес: ";
            // 
            // _textBoxAddress
            // 
            this._textBoxAddress.Location = new System.Drawing.Point(62, 6);
            this._textBoxAddress.Name = "_textBoxAddress";
            this._textBoxAddress.Size = new System.Drawing.Size(526, 20);
            this._textBoxAddress.TabIndex = 1;
            // 
            // _buttonGet
            // 
            this._buttonGet.Location = new System.Drawing.Point(594, 6);
            this._buttonGet.Name = "_buttonGet";
            this._buttonGet.Size = new System.Drawing.Size(75, 23);
            this._buttonGet.TabIndex = 2;
            this._buttonGet.Text = "Получить";
            this._buttonGet.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Заголовок страницы: ";
            // 
            // _textBoxHeader
            // 
            this._textBoxHeader.Location = new System.Drawing.Point(137, 86);
            this._textBoxHeader.Name = "_textBoxHeader";
            this._textBoxHeader.Size = new System.Drawing.Size(532, 20);
            this._textBoxHeader.TabIndex = 4;
            // 
            // _textBoxParagraphs
            // 
            this._textBoxParagraphs.Location = new System.Drawing.Point(15, 139);
            this._textBoxParagraphs.Multiline = true;
            this._textBoxParagraphs.Name = "_textBoxParagraphs";
            this._textBoxParagraphs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textBoxParagraphs.Size = new System.Drawing.Size(654, 284);
            this._textBoxParagraphs.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 450);
            this.Controls.Add(this._textBoxParagraphs);
            this.Controls.Add(this._textBoxHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._buttonGet);
            this.Controls.Add(this._textBoxAddress);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxAddress;
        private System.Windows.Forms.Button _buttonGet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBoxHeader;
        private System.Windows.Forms.TextBox _textBoxParagraphs;
    }
}


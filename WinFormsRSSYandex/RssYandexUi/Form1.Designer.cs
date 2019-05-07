namespace RssYandexUi
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
            this._buttonGet = new System.Windows.Forms.Button();
            this._richTextBoxFromYa = new System.Windows.Forms.RichTextBox();
            this._buttonClear = new System.Windows.Forms.Button();
            this._buttonBD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _buttonGet
            // 
            this._buttonGet.Location = new System.Drawing.Point(12, 12);
            this._buttonGet.Name = "_buttonGet";
            this._buttonGet.Size = new System.Drawing.Size(133, 23);
            this._buttonGet.TabIndex = 0;
            this._buttonGet.Text = "Получить у Яндекса";
            this._buttonGet.UseVisualStyleBackColor = true;
            // 
            // _richTextBoxFromYa
            // 
            this._richTextBoxFromYa.Location = new System.Drawing.Point(12, 52);
            this._richTextBoxFromYa.Name = "_richTextBoxFromYa";
            this._richTextBoxFromYa.Size = new System.Drawing.Size(776, 354);
            this._richTextBoxFromYa.TabIndex = 1;
            this._richTextBoxFromYa.Text = "";
            // 
            // _buttonClear
            // 
            this._buttonClear.Location = new System.Drawing.Point(166, 12);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new System.Drawing.Size(97, 23);
            this._buttonClear.TabIndex = 0;
            this._buttonClear.Text = "Убрать";
            this._buttonClear.UseVisualStyleBackColor = true;
            // 
            // _buttonBD
            // 
            this._buttonBD.Location = new System.Drawing.Point(283, 12);
            this._buttonBD.Name = "_buttonBD";
            this._buttonBD.Size = new System.Drawing.Size(119, 23);
            this._buttonBD.TabIndex = 0;
            this._buttonBD.Text = "Получить из БД";
            this._buttonBD.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this._richTextBoxFromYa);
            this.Controls.Add(this._buttonBD);
            this.Controls.Add(this._buttonClear);
            this.Controls.Add(this._buttonGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonGet;
        private System.Windows.Forms.RichTextBox _richTextBoxFromYa;
        private System.Windows.Forms.Button _buttonClear;
        private System.Windows.Forms.Button _buttonBD;
    }
}


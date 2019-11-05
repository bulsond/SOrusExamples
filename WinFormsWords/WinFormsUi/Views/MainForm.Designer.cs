namespace WinFormsUi.Views
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
            this._richTextBox = new System.Windows.Forms.RichTextBox();
            this._dataGridViewWords = new System.Windows.Forms.DataGridView();
            this._buttonShowWords = new System.Windows.Forms.Button();
            this._dataGridViewWord = new System.Windows.Forms.DataGridView();
            this._columnWordsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordsValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordsTF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordsIDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordsTFIDF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnWordDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._buttonNewText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewWord)).BeginInit();
            this.SuspendLayout();
            // 
            // _richTextBox
            // 
            this._richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._richTextBox.Location = new System.Drawing.Point(12, 12);
            this._richTextBox.Name = "_richTextBox";
            this._richTextBox.Size = new System.Drawing.Size(926, 324);
            this._richTextBox.TabIndex = 2;
            this._richTextBox.Text = "";
            // 
            // _dataGridViewWords
            // 
            this._dataGridViewWords.AllowUserToAddRows = false;
            this._dataGridViewWords.AllowUserToDeleteRows = false;
            this._dataGridViewWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnWordsNumber,
            this._columnWordsValue,
            this._columnWordsTF,
            this._columnWordsIDF,
            this._columnWordsTFIDF});
            this._dataGridViewWords.Location = new System.Drawing.Point(12, 357);
            this._dataGridViewWords.Name = "_dataGridViewWords";
            this._dataGridViewWords.ReadOnly = true;
            this._dataGridViewWords.Size = new System.Drawing.Size(550, 367);
            this._dataGridViewWords.TabIndex = 4;
            // 
            // _buttonShowWords
            // 
            this._buttonShowWords.Location = new System.Drawing.Point(964, 357);
            this._buttonShowWords.Name = "_buttonShowWords";
            this._buttonShowWords.Size = new System.Drawing.Size(155, 23);
            this._buttonShowWords.TabIndex = 1;
            this._buttonShowWords.Text = "Вывести слова";
            this._buttonShowWords.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewWord
            // 
            this._dataGridViewWord.AllowUserToAddRows = false;
            this._dataGridViewWord.AllowUserToDeleteRows = false;
            this._dataGridViewWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewWord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnWordStart,
            this._columnWordEnd,
            this._columnWordDelta});
            this._dataGridViewWord.Location = new System.Drawing.Point(593, 357);
            this._dataGridViewWord.Name = "_dataGridViewWord";
            this._dataGridViewWord.ReadOnly = true;
            this._dataGridViewWord.Size = new System.Drawing.Size(345, 367);
            this._dataGridViewWord.TabIndex = 5;
            // 
            // _columnWordsNumber
            // 
            this._columnWordsNumber.HeaderText = "№";
            this._columnWordsNumber.Name = "_columnWordsNumber";
            this._columnWordsNumber.ReadOnly = true;
            this._columnWordsNumber.Width = 50;
            // 
            // _columnWordsValue
            // 
            this._columnWordsValue.HeaderText = "Слово";
            this._columnWordsValue.Name = "_columnWordsValue";
            this._columnWordsValue.ReadOnly = true;
            this._columnWordsValue.Width = 150;
            // 
            // _columnWordsTF
            // 
            this._columnWordsTF.HeaderText = "TF";
            this._columnWordsTF.Name = "_columnWordsTF";
            this._columnWordsTF.ReadOnly = true;
            // 
            // _columnWordsIDF
            // 
            this._columnWordsIDF.HeaderText = "IDF";
            this._columnWordsIDF.Name = "_columnWordsIDF";
            this._columnWordsIDF.ReadOnly = true;
            // 
            // _columnWordsTFIDF
            // 
            this._columnWordsTFIDF.HeaderText = "TFIDF";
            this._columnWordsTFIDF.Name = "_columnWordsTFIDF";
            this._columnWordsTFIDF.ReadOnly = true;
            // 
            // _columnWordStart
            // 
            this._columnWordStart.HeaderText = "N1";
            this._columnWordStart.Name = "_columnWordStart";
            this._columnWordStart.ReadOnly = true;
            // 
            // _columnWordEnd
            // 
            this._columnWordEnd.HeaderText = "N2";
            this._columnWordEnd.Name = "_columnWordEnd";
            this._columnWordEnd.ReadOnly = true;
            // 
            // _columnWordDelta
            // 
            this._columnWordDelta.HeaderText = "Δ";
            this._columnWordDelta.Name = "_columnWordDelta";
            this._columnWordDelta.ReadOnly = true;
            // 
            // _buttonNewText
            // 
            this._buttonNewText.Location = new System.Drawing.Point(964, 12);
            this._buttonNewText.Name = "_buttonNewText";
            this._buttonNewText.Size = new System.Drawing.Size(155, 23);
            this._buttonNewText.TabIndex = 6;
            this._buttonNewText.Text = "Вставить новый текст";
            this._buttonNewText.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 736);
            this.Controls.Add(this._buttonNewText);
            this.Controls.Add(this._dataGridViewWord);
            this.Controls.Add(this._dataGridViewWords);
            this.Controls.Add(this._richTextBox);
            this.Controls.Add(this._buttonShowWords);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewWord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox _richTextBox;
        private System.Windows.Forms.DataGridView _dataGridViewWords;
        private System.Windows.Forms.Button _buttonShowWords;
        private System.Windows.Forms.DataGridView _dataGridViewWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordsValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordsTF;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordsIDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordsTFIDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnWordDelta;
        private System.Windows.Forms.Button _buttonNewText;
    }
}
namespace WinFormsEditTests.Forms
{
    partial class FormMain
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
            this._buttonQuestionAdd = new System.Windows.Forms.Button();
            this._buttonQuestionDelete = new System.Windows.Forms.Button();
            this._treeView = new System.Windows.Forms.TreeView();
            this._comboBoxType = new System.Windows.Forms.ComboBox();
            this._textBoxQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._numericScore = new System.Windows.Forms.NumericUpDown();
            this._panel = new System.Windows.Forms.Panel();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonChallengeAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._numericScore)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonQuestionAdd
            // 
            this._buttonQuestionAdd.Location = new System.Drawing.Point(19, 442);
            this._buttonQuestionAdd.Name = "_buttonQuestionAdd";
            this._buttonQuestionAdd.Size = new System.Drawing.Size(161, 23);
            this._buttonQuestionAdd.TabIndex = 0;
            this._buttonQuestionAdd.Text = "Вопрос добавить";
            this._buttonQuestionAdd.UseVisualStyleBackColor = true;
            // 
            // _buttonQuestionDelete
            // 
            this._buttonQuestionDelete.Location = new System.Drawing.Point(19, 471);
            this._buttonQuestionDelete.Name = "_buttonQuestionDelete";
            this._buttonQuestionDelete.Size = new System.Drawing.Size(161, 23);
            this._buttonQuestionDelete.TabIndex = 0;
            this._buttonQuestionDelete.Text = "Вопрос удалить";
            this._buttonQuestionDelete.UseVisualStyleBackColor = true;
            // 
            // _treeView
            // 
            this._treeView.Location = new System.Drawing.Point(12, 56);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(173, 347);
            this._treeView.TabIndex = 1;
            // 
            // _comboBoxType
            // 
            this._comboBoxType.FormattingEnabled = true;
            this._comboBoxType.Location = new System.Drawing.Point(12, 29);
            this._comboBoxType.Name = "_comboBoxType";
            this._comboBoxType.Size = new System.Drawing.Size(173, 21);
            this._comboBoxType.TabIndex = 2;
            // 
            // _textBoxQuestion
            // 
            this._textBoxQuestion.Location = new System.Drawing.Point(267, 66);
            this._textBoxQuestion.Multiline = true;
            this._textBoxQuestion.Name = "_textBoxQuestion";
            this._textBoxQuestion.Size = new System.Drawing.Size(373, 64);
            this._textBoxQuestion.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Вопрос";
            // 
            // _textBoxTitle
            // 
            this._textBoxTitle.Location = new System.Drawing.Point(267, 30);
            this._textBoxTitle.Name = "_textBoxTitle";
            this._textBoxTitle.Size = new System.Drawing.Size(373, 20);
            this._textBoxTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Баллы за ответ";
            // 
            // _numericScore
            // 
            this._numericScore.Location = new System.Drawing.Point(356, 143);
            this._numericScore.Name = "_numericScore";
            this._numericScore.Size = new System.Drawing.Size(120, 20);
            this._numericScore.TabIndex = 5;
            // 
            // _panel
            // 
            this._panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panel.Location = new System.Drawing.Point(267, 175);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(373, 228);
            this._panel.TabIndex = 6;
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(417, 413);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 23);
            this._buttonSave.TabIndex = 0;
            this._buttonSave.Text = "Сохранить";
            this._buttonSave.UseVisualStyleBackColor = true;
            // 
            // _buttonChallengeAdd
            // 
            this._buttonChallengeAdd.Location = new System.Drawing.Point(19, 409);
            this._buttonChallengeAdd.Name = "_buttonChallengeAdd";
            this._buttonChallengeAdd.Size = new System.Drawing.Size(161, 23);
            this._buttonChallengeAdd.TabIndex = 0;
            this._buttonChallengeAdd.Text = "Задание добавить";
            this._buttonChallengeAdd.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 513);
            this.Controls.Add(this._panel);
            this.Controls.Add(this._numericScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._textBoxTitle);
            this.Controls.Add(this._textBoxQuestion);
            this.Controls.Add(this._comboBoxType);
            this.Controls.Add(this._treeView);
            this.Controls.Add(this._buttonQuestionDelete);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._buttonChallengeAdd);
            this.Controls.Add(this._buttonQuestionAdd);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._numericScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _buttonQuestionAdd;
        private System.Windows.Forms.Button _buttonQuestionDelete;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.ComboBox _comboBoxType;
        private System.Windows.Forms.TextBox _textBoxQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _numericScore;
        private System.Windows.Forms.Panel _panel;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Button _buttonChallengeAdd;
    }
}


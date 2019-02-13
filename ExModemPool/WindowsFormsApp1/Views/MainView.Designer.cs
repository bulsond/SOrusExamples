namespace WindowsFormsApp1.Views
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
            this._listBoxModems = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._listBoxPhoneNumbers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this._buttonStartCalling = new System.Windows.Forms.Button();
            this._buttonCancelCalling = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._listBoxLogs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _listBoxModems
            // 
            this._listBoxModems.FormattingEnabled = true;
            this._listBoxModems.Location = new System.Drawing.Point(44, 29);
            this._listBoxModems.Name = "_listBoxModems";
            this._listBoxModems.Size = new System.Drawing.Size(88, 147);
            this._listBoxModems.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Модемы";
            // 
            // _listBoxPhoneNumbers
            // 
            this._listBoxPhoneNumbers.FormattingEnabled = true;
            this._listBoxPhoneNumbers.Location = new System.Drawing.Point(141, 29);
            this._listBoxPhoneNumbers.Name = "_listBoxPhoneNumbers";
            this._listBoxPhoneNumbers.Size = new System.Drawing.Size(179, 147);
            this._listBoxPhoneNumbers.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(138, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номера телефонов";
            // 
            // _buttonStartCalling
            // 
            this._buttonStartCalling.Location = new System.Drawing.Point(47, 421);
            this._buttonStartCalling.Name = "_buttonStartCalling";
            this._buttonStartCalling.Size = new System.Drawing.Size(123, 23);
            this._buttonStartCalling.TabIndex = 5;
            this._buttonStartCalling.Text = "Начать обзвон";
            this._buttonStartCalling.UseVisualStyleBackColor = true;
            // 
            // _buttonCancelCalling
            // 
            this._buttonCancelCalling.Location = new System.Drawing.Point(199, 421);
            this._buttonCancelCalling.Name = "_buttonCancelCalling";
            this._buttonCancelCalling.Size = new System.Drawing.Size(123, 23);
            this._buttonCancelCalling.TabIndex = 5;
            this._buttonCancelCalling.Text = "Отменить обзвон";
            this._buttonCancelCalling.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(44, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Журнал";
            // 
            // _listBoxLogs
            // 
            this._listBoxLogs.FormattingEnabled = true;
            this._listBoxLogs.Location = new System.Drawing.Point(45, 207);
            this._listBoxLogs.Name = "_listBoxLogs";
            this._listBoxLogs.Size = new System.Drawing.Size(275, 199);
            this._listBoxLogs.TabIndex = 7;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 463);
            this.Controls.Add(this._listBoxLogs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._buttonCancelCalling);
            this.Controls.Add(this._buttonStartCalling);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._listBoxPhoneNumbers);
            this.Controls.Add(this._listBoxModems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "MainView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _listBoxModems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox _listBoxPhoneNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _buttonStartCalling;
        private System.Windows.Forms.Button _buttonCancelCalling;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox _listBoxLogs;
    }
}
namespace WindowsFormsApp1
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
            this._textBoxSaveFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._buttonSelectFolder = new System.Windows.Forms.Button();
            this._folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._radioButton10Gb = new System.Windows.Forms.RadioButton();
            this._radioButton1Gb = new System.Windows.Forms.RadioButton();
            this._radioButton100Mb = new System.Windows.Forms.RadioButton();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._buttonStartDownload = new System.Windows.Forms.Button();
            this._buttonCancelDownload = new System.Windows.Forms.Button();
            this._labelProgress = new System.Windows.Forms.Label();
            this._groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _textBoxSaveFolder
            // 
            this._textBoxSaveFolder.Location = new System.Drawing.Point(133, 29);
            this._textBoxSaveFolder.Name = "_textBoxSaveFolder";
            this._textBoxSaveFolder.ReadOnly = true;
            this._textBoxSaveFolder.Size = new System.Drawing.Size(484, 20);
            this._textBoxSaveFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сохранить в папку:";
            // 
            // _buttonSelectFolder
            // 
            this._buttonSelectFolder.Location = new System.Drawing.Point(632, 27);
            this._buttonSelectFolder.Name = "_buttonSelectFolder";
            this._buttonSelectFolder.Size = new System.Drawing.Size(75, 23);
            this._buttonSelectFolder.TabIndex = 0;
            this._buttonSelectFolder.Text = "Выбрать";
            this._buttonSelectFolder.UseVisualStyleBackColor = true;
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._radioButton10Gb);
            this._groupBox.Controls.Add(this._radioButton1Gb);
            this._groupBox.Controls.Add(this._radioButton100Mb);
            this._groupBox.Location = new System.Drawing.Point(26, 86);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(200, 141);
            this._groupBox.TabIndex = 3;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Выбор файла";
            // 
            // _radioButton10Gb
            // 
            this._radioButton10Gb.AutoSize = true;
            this._radioButton10Gb.Location = new System.Drawing.Point(36, 100);
            this._radioButton10Gb.Name = "_radioButton10Gb";
            this._radioButton10Gb.Size = new System.Drawing.Size(52, 17);
            this._radioButton10Gb.TabIndex = 2;
            this._radioButton10Gb.Text = "10 Гб";
            this._radioButton10Gb.UseVisualStyleBackColor = true;
            // 
            // _radioButton1Gb
            // 
            this._radioButton1Gb.AutoSize = true;
            this._radioButton1Gb.Location = new System.Drawing.Point(36, 64);
            this._radioButton1Gb.Name = "_radioButton1Gb";
            this._radioButton1Gb.Size = new System.Drawing.Size(46, 17);
            this._radioButton1Gb.TabIndex = 1;
            this._radioButton1Gb.Text = "1 Гб";
            this._radioButton1Gb.UseVisualStyleBackColor = true;
            // 
            // _radioButton100Mb
            // 
            this._radioButton100Mb.AutoSize = true;
            this._radioButton100Mb.Checked = true;
            this._radioButton100Mb.Location = new System.Drawing.Point(36, 28);
            this._radioButton100Mb.Name = "_radioButton100Mb";
            this._radioButton100Mb.Size = new System.Drawing.Size(61, 17);
            this._radioButton100Mb.TabIndex = 0;
            this._radioButton100Mb.TabStop = true;
            this._radioButton100Mb.Text = "100 Mб";
            this._radioButton100Mb.UseVisualStyleBackColor = true;
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(286, 204);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(331, 23);
            this._progressBar.TabIndex = 4;
            // 
            // _buttonStartDownload
            // 
            this._buttonStartDownload.Enabled = false;
            this._buttonStartDownload.Location = new System.Drawing.Point(345, 138);
            this._buttonStartDownload.Name = "_buttonStartDownload";
            this._buttonStartDownload.Size = new System.Drawing.Size(75, 23);
            this._buttonStartDownload.TabIndex = 1;
            this._buttonStartDownload.Text = "Скачать";
            this._buttonStartDownload.UseVisualStyleBackColor = true;
            // 
            // _buttonCancelDownload
            // 
            this._buttonCancelDownload.Enabled = false;
            this._buttonCancelDownload.Location = new System.Drawing.Point(477, 138);
            this._buttonCancelDownload.Name = "_buttonCancelDownload";
            this._buttonCancelDownload.Size = new System.Drawing.Size(75, 23);
            this._buttonCancelDownload.TabIndex = 2;
            this._buttonCancelDownload.Text = "Отменить";
            this._buttonCancelDownload.UseVisualStyleBackColor = true;
            // 
            // _labelProgress
            // 
            this._labelProgress.AutoSize = true;
            this._labelProgress.Location = new System.Drawing.Point(345, 185);
            this._labelProgress.Name = "_labelProgress";
            this._labelProgress.Size = new System.Drawing.Size(0, 13);
            this._labelProgress.TabIndex = 5;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 296);
            this.Controls.Add(this._labelProgress);
            this.Controls.Add(this._buttonCancelDownload);
            this.Controls.Add(this._buttonStartDownload);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this._buttonSelectFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._textBoxSaveFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Form1";
            this._groupBox.ResumeLayout(false);
            this._groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox _textBoxSaveFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _buttonSelectFolder;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Button _buttonStartDownload;
        private System.Windows.Forms.Button _buttonCancelDownload;
        private System.Windows.Forms.RadioButton _radioButton10Gb;
        private System.Windows.Forms.RadioButton _radioButton1Gb;
        private System.Windows.Forms.RadioButton _radioButton100Mb;
        private System.Windows.Forms.Label _labelProgress;
    }
}


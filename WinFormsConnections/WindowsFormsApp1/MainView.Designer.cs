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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this._treeViewDevices = new System.Windows.Forms.TreeView();
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this._buttonCheckAll = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _treeViewDevices
            // 
            this._treeViewDevices.ImageIndex = 0;
            this._treeViewDevices.ImageList = this._imageList;
            this._treeViewDevices.Location = new System.Drawing.Point(25, 23);
            this._treeViewDevices.Name = "_treeViewDevices";
            this._treeViewDevices.SelectedImageIndex = 0;
            this._treeViewDevices.Size = new System.Drawing.Size(322, 171);
            this._treeViewDevices.TabIndex = 0;
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "laptop.png");
            this._imageList.Images.SetKeyName(1, "laptopOff.png");
            this._imageList.Images.SetKeyName(2, "laptopOn.png");
            this._imageList.Images.SetKeyName(3, "laptopblack.png");
            // 
            // _buttonCheckAll
            // 
            this._buttonCheckAll.Location = new System.Drawing.Point(70, 223);
            this._buttonCheckAll.Name = "_buttonCheckAll";
            this._buttonCheckAll.Size = new System.Drawing.Size(104, 23);
            this._buttonCheckAll.TabIndex = 1;
            this._buttonCheckAll.Text = "Проверить все";
            this._buttonCheckAll.UseVisualStyleBackColor = true;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Enabled = false;
            this._buttonCancel.Location = new System.Drawing.Point(200, 223);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(104, 23);
            this._buttonCancel.TabIndex = 1;
            this._buttonCancel.Text = "Отменить";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 273);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonCheckAll);
            this.Controls.Add(this._treeViewDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _treeViewDevices;
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.Button _buttonCheckAll;
        private System.Windows.Forms.Button _buttonCancel;
    }
}


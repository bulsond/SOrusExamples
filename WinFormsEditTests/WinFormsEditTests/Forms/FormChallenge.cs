using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsEditTests.Forms
{
    public partial class FormChallenge : Form
    {
        private string name;

        public FormChallenge()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавить задание";

            this.CancelButton = _buttonCancel;
            _buttonOk.DialogResult = DialogResult.OK;
            this.AcceptButton = _buttonOk;
        }

        public string Name
        { 
            get => _textBoxName.Text;
            set => _textBoxName.Text = value;
        }
    }
}

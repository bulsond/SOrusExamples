using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsUi.Interfaces;

namespace WinFormsUi.Views
{
    public partial class MainForm : Form, IMainForm
    {
        //источники данных для таблиц
        private BindingSource _bsWords = new BindingSource();
        private BindingSource _bsWord = new BindingSource();

        public event EventHandler ShowWordsClicked;
        public event EventHandler InputOutputTextChanged;

        public MainForm()
        {
            InitializeComponent();

            //кнопки и др.события
            _buttonNewText.Click += (s, e) =>
            {
                _richTextBox.Text = String.Empty;
                _richTextBox.Paste();
                InputOutputTextChanged?.Invoke(this, e);
            };
            _buttonShowWords.Click += (s, e) => ShowWordsClicked?.Invoke(this, e);

            //привязки у таблицы слов
            _bsWords.DataSource = typeof(ITFIDFWord);
            _dataGridViewWords.AutoGenerateColumns = false;
            _dataGridViewWords.DataSource = _bsWords;
            _columnWordsNumber.DataPropertyName = nameof(ITFIDFWord.OrderNumber);
            _columnWordsValue.DataPropertyName = nameof(ITFIDFWord.Value);
            _columnWordsTF.DataPropertyName = nameof(ITFIDFWord.TermFrequency);
            _columnWordsIDF.DataPropertyName = nameof(ITFIDFWord.InverseDocumentFrequency);
            _columnWordsTFIDF.DataPropertyName = nameof(ITFIDFWord.TFIDF);

            //привязки у таблицы позиций слова
            _bsWord.DataSource = _bsWords;
            _bsWord.DataMember = nameof(ITFIDFWord.Positions);
            _dataGridViewWord.AutoGenerateColumns = false;
            _dataGridViewWord.DataSource = _bsWord;
            _columnWordStart.DataPropertyName = nameof(IWordPosition.Start);
            _columnWordEnd.DataPropertyName = nameof(IWordPosition.End);
            _columnWordDelta.DataPropertyName = nameof(IWordPosition.Delta);
        }

        public string InputOutputText
        { 
            get => _richTextBox.Text;
            set => _richTextBox.Text = value;
        }

        public List<ITFIDFWord> Words
        {
            get => _bsWords.List as List<ITFIDFWord>;
            set => _bsWords.DataSource = value;
        }

    }
}

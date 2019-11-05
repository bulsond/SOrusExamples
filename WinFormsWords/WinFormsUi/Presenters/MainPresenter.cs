using System;
using System.Collections.Generic;
using System.Linq;
using WinFormsUi.Interfaces;

namespace WinFormsUi.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private string _currentText = String.Empty;

        public IMainForm Form { get; }
        public ITokenService TokenService { get; }
        public IWordService WordService { get; }

        public MainPresenter(IMainForm form, ITokenService tokenService, IWordService wordService)
        {
            Form = form ?? throw new ArgumentNullException(nameof(form));
            TokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            WordService = wordService ?? throw new ArgumentNullException(nameof(wordService));

            Form.InputOutputTextChanged += Form_InputOutputTextChanged;
            Form.ShowWordsClicked += Form_ShowWordsClicked;
        }

        private void Form_ShowWordsClicked(object sender, EventArgs e)
        {
            var tokens = TokenService.GetTokens(_currentText);
            Form.InputOutputText = String.Join("", tokens.Select(t => t.TokenValue).ToArray());

            var countSentences = TokenService.GetCountSentences(tokens);
            var words = WordService.GetTFIDFWords(tokens, countSentences);

            Form.Words = words;
        }

        private void Form_InputOutputTextChanged(object sender, EventArgs e)
        {
            _currentText = Form.InputOutputText;
            Form.Words = new List<ITFIDFWord>();
        }
    }
}

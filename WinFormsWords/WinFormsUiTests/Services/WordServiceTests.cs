using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsUi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsUi.Interfaces;
using WinFormsUiTests.Stubs;
using WinFormsUi.Models;

namespace WinFormsUi.Services.Tests
{
    [TestClass()]
    public class WordServiceTests
    {
        private IWordService _service;

        [TestInitialize]
        public void WordServiceCtor()
        {
            _service = new WordService();
        }

        [TestMethod]
        public void GetWordsWithDuplicates_7WordTokens_Returns7WordsWithDuplicatesList()
        {
            ITokenService tokenService = new StubTokenService();
            var tokens = tokenService.GetTokens("");

            List<IWord> words = _service.GetWordsWithDuplicates(tokens);

            Assert.AreEqual(7, words.Count);
        }

        [TestMethod]
        public void GetWords_7WordTokens_Returns5WordsWithoutDuplicatesList()
        {
            ITokenService tokenService = new StubTokenService();
            var tokens = tokenService.GetTokens(String.Empty);

            List<IWord> words = _service.GetWords(tokens);

            Assert.AreEqual(5, words.Count);
            Assert.AreEqual(2, words.First(w => w.Value == "второе").Positions.Count());
            Assert.AreEqual(2, words.First(w => w.Value == "третье").Positions.Count());
        }

        [TestMethod]
        public void GetTFIDFWords_7WordTokens_Returns5TFIDFWordsList()
        {
            ITokenService tokenService = new StubTokenService();
            var tokens = tokenService.GetTokens(String.Empty);
            var countSentences = tokenService.GetCountSentences(tokens);

            List<ITFIDFWord> words = _service.GetTFIDFWords(tokens, countSentences);

            Assert.AreEqual(5, words.Count);
        }
    }
}
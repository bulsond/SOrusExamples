using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsUi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsUi.Services.Tokens;
using WinFormsUi.Interfaces;

namespace WinFormsUiTests.Services.Tests
{
    [TestClass()]
    public class TokenServiceTests
    {
        private ITokenService _service;

        [TestInitialize]
        public void TokenServiceCtor()
        {
            _service = new TokenService();
        }

        [TestMethod]
        public void GetTokens_Number_ListWithNumberToken()
        {
            string text = "1";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 1);
            Assert.IsInstanceOfType(tokens.First(), typeof(NumberToken));
        }

        [TestMethod]
        public void GetTokens_Word_ListWithWordToken()
        {
            string text = "слово";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 1);
            Assert.IsInstanceOfType(tokens.First(), typeof(WordToken));
            Assert.AreEqual(text.Length, tokens.First().Value.Length);
        }

        [TestMethod]
        public void GetTokens_Space_ListWithSpaceToken()
        {
            string text = " ";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 1);
            Assert.IsInstanceOfType(tokens.First(), typeof(SpaceToken));
            Assert.AreEqual(text.Length, tokens.First().Value.Length);
        }

        [TestMethod]
        public void GetTokens_Comma_ListWithSignToken()
        {
            string text = ",";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 1);
            Assert.IsInstanceOfType(tokens.First(), typeof(SignToken));
            Assert.AreEqual(text.Length, tokens.First().Value.Length);
        }

        [TestMethod]
        public void GetTokens_Period_ListWithSignToken()
        {
            string text = ".";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 1);
            Assert.IsInstanceOfType(tokens.First(), typeof(SignToken));
            Assert.AreEqual(text.Length, tokens.First().Value.Length);
        }

        [TestMethod]
        public void GetTokens_Parenthesis_ListWithSignToken()
        {
            string text = "(";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 1);
            Assert.IsInstanceOfType(tokens.First(), typeof(SignToken));
            Assert.AreEqual(text.Length, tokens.First().Value.Length);
        }

        [TestMethod]
        public void GetTokens_NumberAndWord_ListWith2Tokens()
        {
            string text = "1слово";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 2);
            Assert.IsInstanceOfType(tokens.First(), typeof(NumberToken));
            Assert.IsInstanceOfType(tokens.Last(), typeof(WordToken));
        }

        [TestMethod]
        public void GetTokens_WordAndNumber_ListWith2Tokens()
        {
            string text = "слово1";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 2);
            Assert.IsInstanceOfType(tokens.First(), typeof(WordToken));
            Assert.IsInstanceOfType(tokens.Last(), typeof(NumberToken));
        }

        [TestMethod]
        public void GetTokens_NumberSpaceWord_ListWith3Tokens()
        {
            string text = "1 слово";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 3);
            Assert.IsInstanceOfType(tokens.First(), typeof(NumberToken));
            Assert.IsInstanceOfType(tokens.Last(), typeof(WordToken));
        }

        [TestMethod]
        public void GetTokens_NumberSpaceWordSpace_ListWith4Tokens()
        {
            string text = "1 слово ";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 4);
            Assert.IsInstanceOfType(tokens.First(), typeof(NumberToken));
            Assert.IsInstanceOfType(tokens.Last(), typeof(SpaceToken));
        }

        [TestMethod]
        public void GetTokens_WordSpaceWord_ListWith3Tokens()
        {
            string text = "первое второе";

            List<IToken> tokens = _service.GetTokens(text);

            Assert.IsTrue(tokens.Count == 3);
            Assert.IsInstanceOfType(tokens.First(), typeof(WordToken));
            Assert.IsInstanceOfType(tokens.Last(), typeof(WordToken));
        }

        [TestMethod]
        public void GetTokens_WordSpaceWord_FirstWordHasPosition0SecondWordHasPosition7()
        {
            string text = "первое второе";
            var firstPosition = 0;
            var secondPosition = 7;

            List<IToken> tokens = _service.GetTokens(text);
            var actualFirstPosition = tokens.First().Position;
            var actualSecondPosition = tokens.Last().Position;

            Assert.AreEqual(firstPosition, actualFirstPosition);
            Assert.AreEqual(secondPosition, actualSecondPosition);
        }

        [TestMethod]
        public void GetCountSentences_3Sentences_CountEquals3()
        {
            string text = "Первое предложение. Второе предложение. Третье предложение.";
            List<IToken> tokens = _service.GetTokens(text);

            int countSentences = _service.GetCountSentences(tokens);

            Assert.AreEqual(3, countSentences);
        }
    }
}
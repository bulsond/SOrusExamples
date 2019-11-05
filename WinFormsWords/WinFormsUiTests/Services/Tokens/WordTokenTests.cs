using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsUi.Services.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsUi.Services.Tokens.Tests
{
    [TestClass()]
    public class WordTokenTests
    {
        [TestMethod()]
        public void WordTokenCtor()
        {
            string value = "mouse";
            int position = 22;
            int orderNumber = 1;
            string tokenValue = $"<{value}:{position}:{orderNumber}>";

            WordToken token = new WordToken(position, value, orderNumber);

            Assert.AreEqual(tokenValue, token.TokenValue);
        }

        [TestMethod()]
        public void WordTokenCtor_WithСapitalLetter_ValueHasLowerCase()
        {
            string input = "Mouse";
            string value = "mouse";
            int position = 22;
            int orderNumber = 1;
            string tokenValue = $"<{value}:{position}:{orderNumber}>";

            WordToken token = new WordToken(position, input, orderNumber);

            Assert.AreEqual(value, token.Value);
        }
    }
}
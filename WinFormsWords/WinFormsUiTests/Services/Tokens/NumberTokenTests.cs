using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsUi.Services.Tokens;

namespace WinFormsUiTests.Services.Tokens.Tests
{
    [TestClass()]
    public class NumberTokenTests
    {
        [TestMethod()]
        public void NumberTokenCtor()
        {
            string value = "1";
            int position = 22;
            string tokenValue = $@"[number:{position}]";

            NumberToken token = new NumberToken(position, value);

            Assert.AreEqual(tokenValue, token.TokenValue);
            Assert.AreEqual(value, token.Value);
            Assert.AreEqual(position, token.Position);
        }
    }
}
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
    public class SpaceTokenTests
    {
        [TestMethod()]
        public void SpaceTokenCtor()
        {
            string value = " ";
            int position = 22;
            string tokenValue = $@"[space:{position}]";

            SpaceToken token = new SpaceToken(position);

            Assert.AreEqual(tokenValue, token.TokenValue);
            Assert.AreEqual(value, token.Value);
            Assert.AreEqual(position, token.Position);
        }
    }
}
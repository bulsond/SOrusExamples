using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsUi.Models.Tests
{
    [TestClass()]
    public class WordTests
    {
        [TestMethod()]
        public void WordTestCtor()
        {
            string value = "слово";
            int position = 22;
            int orderNumber = 3;

            Word word = new Word(value, position, orderNumber);
            int actualPosition = word.Positions.First();
            int actualOrderNumber = word.OrderNumbers.First();

            Assert.IsNotNull(word);
            Assert.AreEqual(value, word.Value);
            Assert.AreEqual(value.Length, word.Length);
            Assert.AreEqual(position, actualPosition);
            Assert.AreEqual(orderNumber, actualOrderNumber);
        }

        [TestMethod]
        public void AddDuplicate_WithTheSamePositionAndOrderNumber_HasOnePositionAndNumber()
        {
            string value = "слово";
            int position = 22;
            int orderNumber = 3;
            Word word = new Word(value, position, orderNumber);

            word.AddDuplicate(position, orderNumber);
            int actualPositionCount = word.Positions.Count();
            int actualOrderNumberCount = word.OrderNumbers.Count();

            Assert.AreEqual(1, actualPositionCount);
            Assert.AreEqual(1, actualOrderNumberCount);
        }

        [TestMethod]
        public void AddDuplicate_With2PositionAndOrderNumber_Has2PositionAndNumber()
        {
            string value = "слово";
            int position1 = 22;
            int position2 = 42;
            int orderNumber1 = 3;
            int orderNumber2 = 23;
            Word word = new Word(value, position1, orderNumber1);

            word.AddDuplicate(position2, orderNumber2);
            int actualPositionCount = word.Positions.Count();
            int actualOrderNumberCount = word.OrderNumbers.Count();

            Assert.AreEqual(2, actualPositionCount);
            Assert.AreEqual(2, actualOrderNumberCount);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberNotationsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberNotationsUI.Models.Tests
{
    [TestClass()]
    public class NotationServiceTests
    {
        [TestMethod()]
        public void NotationServiceCtor()
        {
            INotationService service = new NotationService();

            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void GetNotationsNames()
        {
            INotationService service = new NotationService();

            List<string> names = service.GetNotationsNames();

            Assert.IsNotNull(names);
            Assert.AreEqual(3, names.Count);
        }

        [TestMethod()]
        public void GetNotationValue_DecimalToBinary()
        {
            string inputNotation = "Десятичная";
            int inputValue = 2;
            string outputNotation = "Двоичная";
            string outputResult = "10";
            INotationService service = new NotationService();

            string result = service.GetNotationValue(inputNotation, inputValue.ToString(), outputNotation);

            Assert.IsFalse(String.IsNullOrEmpty(result));
            Assert.AreEqual(outputResult, result);
        }

        [TestMethod()]
        public void GetNotationValue_DecimalToBinary_WithWrongInputNotation()
        {
            string inputNotation = "Десчная";
            int inputValue = 2;
            string outputNotation = "Двоичная";
            INotationService service = new NotationService();

            string result = service.GetNotationValue(inputNotation, inputValue.ToString(), outputNotation);

            Assert.IsTrue(String.IsNullOrEmpty(result));
        }

        [TestMethod()]
        public void GetNotationValue_DecimalToBinary_WithWrongOutputNotation()
        {
            string inputNotation = "Десятичная";
            int inputValue = 2;
            string outputNotation = "Двная";
            INotationService service = new NotationService();

            string result = service.GetNotationValue(inputNotation, inputValue.ToString(), outputNotation);

            Assert.IsTrue(String.IsNullOrEmpty(result));
        }
    }
}
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
    public class DecimalNotationTests
    {
        [TestMethod()]
        public void DecimalNotationCtor()
        {
            var name = "Десятичная";

            INotation notation = new DecimalNotation();

            Assert.IsNotNull(notation);
            Assert.AreEqual(name, notation.Name);
        }

        [TestMethod()]
        public void SetValueIntInput()
        {
            int value = 10;
            string sValue = "10";
            INotation notation = new DecimalNotation();

            notation.SetValue(value);

            Assert.AreEqual(value, notation.ValueInt);
            Assert.AreEqual(sValue, notation.ValueString);
        }

        [TestMethod()]
        public void SetValueTestStringInput()
        {
            int value = 10;
            string sValue = "10";
            INotation notation = new DecimalNotation();

            bool result = notation.SetValue(sValue);

            Assert.IsTrue(result);
            Assert.AreEqual(value, notation.ValueInt);
            Assert.AreEqual(sValue, notation.ValueString);
        }

        [TestMethod()]
        public void SetValueTestStringInputWrong()
        {
            int value = 10;
            string sValue = "X10";
            INotation notation = new DecimalNotation();

            bool result = notation.SetValue(sValue);

            Assert.IsFalse(result);
            Assert.AreNotEqual(value, notation.ValueInt);
            Assert.AreNotEqual(sValue, notation.ValueString);
        }
    }
}
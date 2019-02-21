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
    public class HexNotationTests
    {
        [TestMethod()]
        public void HexNotationCtor()
        {
            var name = "Шестнадцатеричная";

            INotation notation = new HexNotation();

            Assert.IsNotNull(notation);
            Assert.AreEqual(name, notation.Name);
        }

        [TestMethod()]
        public void SetValueIntInput()
        {
            int value = 16;
            string sValue = "10";
            INotation notation = new HexNotation();

            notation.SetValue(value);

            Assert.AreEqual(value, notation.ValueInt);
            Assert.AreEqual(sValue, notation.ValueString);
        }

        [TestMethod()]
        public void SetValueStringInput()
        {
            int value = 15;
            string sValue = "f";
            INotation notation = new HexNotation();

            bool result = notation.SetValue(sValue);

            Assert.IsTrue(result);
            Assert.AreEqual(value, notation.ValueInt);
            Assert.AreEqual(sValue, notation.ValueString);
        }

        [TestMethod()]
        public void SetValueTestStringInputWrong()
        {
            int value = 15;
            string sValue = "fx";
            INotation notation = new HexNotation();

            bool result = notation.SetValue(sValue);

            Assert.IsFalse(result);
            Assert.AreNotEqual(value, notation.ValueInt);
            Assert.AreNotEqual(sValue, notation.ValueString);
        }
    }
}
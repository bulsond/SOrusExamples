using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcUI.Models.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initialization()
        {
            _calculator = new Calculator();
        }

        [TestMethod()]
        public void ZeroTest()
        {
            _calculator.Zero();

            Assert.AreEqual("0", _calculator.Output);
        }

        [TestMethod()]
        public void OneTest()
        {
            _calculator.One();

            Assert.AreEqual("1", _calculator.Output);
        }

        [TestMethod()]
        public void TwoTest()
        {
            _calculator.Two();

            Assert.AreEqual("2", _calculator.Output);
        }

        [TestMethod()]
        public void ThreeTest()
        {
            _calculator.Three();

            Assert.AreEqual("3", _calculator.Output);
        }

        [TestMethod()]
        public void FourTest()
        {
            _calculator.Four();

            Assert.AreEqual("4", _calculator.Output);
        }

        [TestMethod()]
        public void FiveTest()
        {
            _calculator.Five();

            Assert.AreEqual("5", _calculator.Output);
        }

        [TestMethod()]
        public void SixTest()
        {
            _calculator.Six();

            Assert.AreEqual("6", _calculator.Output);
        }

        [TestMethod()]
        public void SevenTest()
        {
            _calculator.Seven();

            Assert.AreEqual("7", _calculator.Output);
        }

        [TestMethod()]
        public void EightTest()
        {
            _calculator.Eight();

            Assert.AreEqual("8", _calculator.Output);
        }

        [TestMethod()]
        public void NineTest()
        {
            _calculator.Nine();

            Assert.AreEqual("9", _calculator.Output);
        }

        [TestMethod()]
        public void DecimalPointTest()
        {
            _calculator.Zero();
            _calculator.DecimalPoint();

            Assert.AreEqual("0,", _calculator.Output);
        }

        [TestMethod()]
        public void AdditionTest()
        {
            _calculator.One();
            _calculator.Addition();

            Assert.AreEqual('+', _calculator.Operation);
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            _calculator.One();
            _calculator.Subtraction();

            Assert.AreEqual('-', _calculator.Operation);
        }

        [TestMethod()]
        public void OneOperation()
        {
            _calculator.One();
            _calculator.Addition();
            _calculator.Two();
            _calculator.EqualSign();

            Assert.AreEqual("3", _calculator.Output);
        }

        [TestMethod()]
        public void TwoOperations()
        {
            _calculator.One();
            _calculator.Addition();
            _calculator.One();
            _calculator.Subtraction();
            _calculator.One();
            _calculator.EqualSign();

            Assert.AreEqual("1", _calculator.Output);
        }

        [TestMethod()]
        public void OneOperationAfterAnotherOne()
        {
            _calculator.One();
            _calculator.Addition();
            _calculator.Two();
            _calculator.EqualSign();

            _calculator.Subtraction();
            _calculator.Three();
            _calculator.EqualSign();

            Assert.AreEqual("0", _calculator.Output);
        }

        [TestMethod()]
        public void ClearTest()
        {
            _calculator.Clear();

            Assert.AreEqual(String.Empty, _calculator.Output);
            Assert.AreEqual('N', _calculator.Operation);
        }
    }
}
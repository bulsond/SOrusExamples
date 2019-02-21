using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberNotationsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberNotationsUI.Tests
{
    [TestClass()]
    public class MainViewModelTests
    {
        [TestMethod()]
        public void MainViewModelCtor()
        {
            MainViewModel viewModel = new MainViewModel();

            Assert.IsNotNull(viewModel);
            Assert.AreEqual(3, viewModel.InputNotations.Count);
            Assert.AreEqual(3, viewModel.OutputNotations.Count);
            Assert.AreEqual(0, viewModel.SelectedInputNotation);
            Assert.AreEqual(0, viewModel.SelectedOutputNotation);
        }

        [TestMethod]
        public void DecimalNotationInputToDecimalNotationOutput()
        {
            string notation = "Десятичная";
            int input = 10;
            MainViewModel viewModel = new MainViewModel();

            int indexInputNotation = viewModel.InputNotations.FindIndex(n => n == notation);
            int indexOutputNotation = viewModel.OutputNotations.FindIndex(n => n == notation);
            viewModel.SelectedInputNotation = indexInputNotation;
            viewModel.SelectedOutputNotation = indexOutputNotation;
            viewModel.Input = input.ToString();
            string result = viewModel.Output;

            Assert.AreEqual(input.ToString(), result);
        }

        [TestMethod]
        public void DecimalNotationInputToHexNotationOutput()
        {
            string notationInput = "Десятичная";
            string notationOutput = "Шестнадцатеричная";
            string input = "15";
            string output = "f";
            MainViewModel viewModel = new MainViewModel();

            int indexInputNotation = viewModel.InputNotations.FindIndex(n => n == notationInput);
            int indexOutputNotation = viewModel.OutputNotations.FindIndex(n => n == notationOutput);
            viewModel.SelectedInputNotation = indexInputNotation;
            viewModel.SelectedOutputNotation = indexOutputNotation;
            viewModel.Input = input;
            string result = viewModel.Output;

            Assert.AreEqual(output, result);
        }
    }
}
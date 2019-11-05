using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsUi.Interfaces;

namespace WinFormsUi.Models.Tests
{
    [TestClass()]
    public class TFIDFWordTests
    {
        [TestMethod()]
        public void CreateFromWordCtor()
        {
            string value = "слово";
            int position = 22;
            int orderNumber = 3;
            Word word = new Word(value, position, orderNumber);
            int countSentences = 33;

            ITFIDFWord tFIDFWord = TFIDFWord.CreateFromWord(word, countSentences);

            Assert.IsInstanceOfType(tFIDFWord, typeof(TFIDFWord));
            Assert.IsTrue(tFIDFWord.TermFrequency > 0);
            Assert.IsTrue(tFIDFWord.InverseDocumentFrequency > 0);
            Assert.IsTrue(tFIDFWord.TFIDF > 0);
        }
    }
}
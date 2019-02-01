using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models.Tests
{
    [TestClass()]
    public class VasyaTests
    {
        [TestMethod()]
        public void VasyaTestCtor()
        {
            Vasya vasya = new Vasya();

            Assert.IsNotNull(vasya);
            Assert.IsTrue(vasya.State is NotFreezedWater);
            Assert.AreEqual(0, vasya.CountSteps);
        }

        [TestMethod()]
        public void FreezeWaterTest()
        {
            Vasya vasya = new Vasya();

            vasya.FreezeWater();

            Assert.IsTrue(vasya.State is FreezedWater);
        }

        [TestMethod()]
        public void WalkOnWaterWhenNotFreezedWaterTest()
        {
            int steps = 20;
            Vasya vasya = new Vasya();

            vasya.WalkOnWater(steps);

            Assert.IsTrue(vasya.State is NotFreezedWater);
            Assert.AreNotEqual(steps, vasya.CountSteps);
        }

        [TestMethod()]
        public void WalkOnWaterWhenFreezedWaterTest()
        {
            int steps = 20;
            Vasya vasya = new Vasya();

            vasya.FreezeWater();
            vasya.WalkOnWater(steps);

            Assert.IsTrue(vasya.State is FreezedWater);
            Assert.AreEqual(steps, vasya.CountSteps);
        }
    }
}
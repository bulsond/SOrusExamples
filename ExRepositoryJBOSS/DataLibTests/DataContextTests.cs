using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibTests.Moks;
using DataLib.Models;

namespace DataLib.Tests
{
    [TestClass()]
    public class DataContextTests
    {
        private MockConnection _mockConnection;

        [TestInitialize]
        public void Initialization()
        {
            var ipAddress = "192.168.10.100";
            var port = "4040";
            var sid = "db12c";
            var userName = "TestUser";
            var userId = 123;

            _mockConnection =
                new MockConnection(ipAddress, port, sid, userName, userId);
        }

        [TestMethod()]
        public void DataContextCtor()
        {
            DataContext dataContext = new DataContext(_mockConnection);

            Assert.IsNotNull(dataContext);
            Assert.IsNotNull(dataContext.Connection);
            Assert.IsNotNull(dataContext.LabRepository);
            Assert.IsNotNull(dataContext.KnchRepository);
        }

        [TestMethod()]
        public async Task GetAllLabs()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var countRecords = 3;
            var lab = new Lab { Id = 345, Description = "testlab3" };

            IEnumerable<Lab> labs = await dataContext.LabRepository.GetAsync();

            Assert.IsNotNull(labs);
            Assert.AreEqual(countRecords, labs.Count());
            Assert.AreEqual(lab.Id, labs.Last().Id);
            Assert.AreEqual(lab.Description, labs.Last().Description);
        }

        [TestMethod()]
        public async Task GetLabById()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 345, Description = "testlab3" };

            Lab resLab = await dataContext.LabRepository.GetAsync(lab.Id);

            Assert.IsNotNull(resLab);
            Assert.AreEqual(lab.Id, resLab.Id);
            Assert.AreEqual(lab.Description, resLab.Description);
        }

        [TestMethod()]
        public async Task InsertLab()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 0, Description = "testlab4" };

            int insert = await dataContext.LabRepository.AddAsync(lab);

            Assert.AreEqual(0, insert);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public async Task InsertLabWithWrongId()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 345, Description = "testlab3" };

            int insert = await dataContext.LabRepository.AddAsync(lab);
        }

        [TestMethod()]
        public async Task UpdatetLab()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 345, Description = "testlab3" };

            int update = await dataContext.LabRepository.UpdateAsync(lab);

            Assert.AreEqual(0, update);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public async Task UpdatetLabWithWrongId()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 0, Description = "testlab3" };

            int update = await dataContext.LabRepository.UpdateAsync(lab);
        }

        [TestMethod()]
        public async Task RemoveLab()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 345, Description = "testlab3" };

            int update = await dataContext.LabRepository.RemoveAsync(lab);

            Assert.AreEqual(0, update);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public async Task RemoveLabWithWrongId()
        {
            DataContext dataContext = new DataContext(_mockConnection);
            var lab = new Lab { Id = 0, Description = "testlab3" };

            int update = await dataContext.LabRepository.RemoveAsync(lab);
        }
    }
}
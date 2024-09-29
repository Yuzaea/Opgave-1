global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Opgave_1;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
namespace RepoTest

{
    [TestClass]
    public class UnitTest1
    {
        private TrophiesRepository _repository;

        [TestInitialize]
        public void vroom()
        {
        _repository = new TrophiesRepository();



        }
        [TestMethod]
        public void Getall()
        {
            var result = _repository.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
        }
        [TestMethod]
        public void GetById()
        {
            var result = _repository.GetById(1);
            Assert.AreEqual("Badminton", result.Competition);
        }
        [TestMethod]
        public void RemoveNonExistant() { 
        var initialcount = _repository.GetAll().Count;
        _repository.Remove(690);
            var newCount = _repository.GetAll().Count;
            Assert.AreEqual(initialcount, newCount);
        }
        [TestMethod]
        public void Remove()
        {
            var initialcount = _repository.GetAll().Count;
            _repository.Remove(1);

            var newCount = _repository.GetAll().Count;
            Assert.AreEqual(initialcount -1, newCount);
        }

        [TestMethod]
        public void Update()
        {
            var updatedTrophy = new Trophy { Competition = "Updated", Year = 2000 };
            var result = _repository.Update(1, updatedTrophy);
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated", result.Competition);
            Assert.AreEqual(2000, result.Year);
        }
        [TestMethod]
        public void UpdateInvalidID()
        {
            var updatedTrophy = new Trophy { Competition = "Updated", Year = 2023 };

            var result = _repository.Update(999, updatedTrophy);

            Assert.IsNull(result);
        }
        [TestMethod]
        public void AddMultipleSameComps()
        {
            var trophy1 = new Trophy { Competition = "Duplicate", Year = 2023 };
            var trophy2 = new Trophy { Competition = "Duplicate", Year = 2022 };

            _repository.Add(trophy1);
            _repository.Add(trophy2);

            var result = _repository.GetAll().Count(t => t.Competition == "Duplicate");

            Assert.AreEqual(2, result);
        }
[TestMethod]
        [DataRow(2020)]
        [DataRow(2019)]
        [DataRow(2000)]

public void FilterByYear(int filterYear)
        {
            var result = _repository.Get(filterYear);

            Assert.IsTrue(result.All(t => t.Year == filterYear));
        }
        [TestMethod]
        public void FilterByComp()
        {
            var result = _repository.Get(orderBy: "competition").ToList();

            Assert.IsTrue(result.SequenceEqual(result.OrderBy(t => t.Competition)));
        }
    }
}
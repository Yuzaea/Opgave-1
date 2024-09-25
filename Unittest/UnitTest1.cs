global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Opgave_1;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;

namespace Opgave_1_test
{
    [TestClass]
    public class UnitTest1
    {


        private readonly Trophy _validTrophy = new() { Id = 1, Competition = "Valid", Year = 2022 };
        private readonly Trophy _shortCompetition = new() { Id = 2, Competition = "NO", Year = 2022 }; // Too short
        private readonly Trophy _NullCompetition = new() { Id = 3, Competition = null, Year = 2022 }; // NUll comp
        private readonly Trophy _yearLow = new() { Id = 4, Competition = "Valid", Year = 1970 }; // Too low
        private readonly Trophy _yearHigh = new() { Id = 5, Competition = "Valid", Year = 2024 }; // Too high
        private readonly Trophy _lowerLimitYearTrophy = new() { Id = 6, Competition = "Valid", Year = 1971 }; // Lower Limit
        private readonly Trophy _upperLimitYearTrophy = new() { Id = 7, Competition = "Valid", Year = 2023 }; // Upper Limit

        //Competitions
        [TestMethod]
        public void ValidateCompetition_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _NullCompetition.ValidateCompetition());

        }
        [TestMethod]
        public void ValidateCompetition_Short()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _shortCompetition.ValidateCompetition());

        }
        [TestMethod]
        public void ValidateCompetition_Valid()
        {
           _validTrophy.ValidateCompetition();

        }

        //Year
        [TestMethod]
        public void ValidateYear_Less()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> _yearLow.ValdidateYear());

        }
        [TestMethod]
        public void ValidateYear_Greater()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _yearHigh.ValdidateYear());

        }
        [TestMethod]
        public void ValidateYear_LowerLimit()
        {
            _lowerLimitYearTrophy.ValdidateYear();

        }
        [TestMethod]
        public void ValidateYear_UpperLimit()
        {
            _upperLimitYearTrophy.ValdidateYear();

        }
        [TestMethod]
        [DataRow(1980)]
        [DataRow(2000)]
        [DataRow(2020)]
        public void ValidateYear_Valid(int year)
        {
            var trophy = new Trophy { Id = 8, Competition = "Valid", Year = year };

            trophy.ValdidateYear();

        }
        [TestMethod]
        public void ValidateToString()
        {
            // Arrange
            var trophyWithId = new Trophy { Id = 8, Competition = "Valid", Year = 2023 };

            // Act
            var result = trophyWithId.ToString();

            // Assert
            Assert.AreEqual("ID8 CompetitionValid Year2023", result);
        }
        [TestMethod]
        public void ValidateValidate()
        {
            _validTrophy.Validate();

        }
    }
}
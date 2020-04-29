using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.BusinessObjects;

namespace UseCases.UnitTests.BusinessObjects
{
    [TestClass]
    public class ExplicitScoreTests
    {
        [TestMethod]
        [DataRow(false, false, false, 0)]
        [DataRow(true, true, true, 100)]
        [DataRow(true, false, true, 66)]
        public void ExplicitScoreValue_VaryingExplicitSongs_ReturnsCorrectScore(bool isSong1Explicit,
                                                                                bool isSong2Explicit,
                                                                                bool isSong3Explicit,
                                                                                int expectedScore)
        {
            //Arrange
            var track1 = new Track { IsExplicit = isSong1Explicit };
            var track2 = new Track { IsExplicit = isSong2Explicit };
            var track3 = new Track { IsExplicit = isSong3Explicit };

            var trackList = new List<Track> { track1, track2, track3 };

            var explicitScore = new ExplicitScore(trackList);

            //Act
            var result = explicitScore.ExplicitScoreValue;

            //Assert
            Assert.AreEqual(expectedScore, result);
        }
    }
}

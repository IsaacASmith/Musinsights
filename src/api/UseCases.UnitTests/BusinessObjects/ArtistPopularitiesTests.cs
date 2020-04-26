using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.BusinessObjects;

namespace UseCases.UnitTests.BusinessObjects
{
    [TestClass]
    public class ArtistPopularitiesTests
    {
        [TestMethod]
        [DataRow(50, 80, 5, 45)]
        [DataRow(2, 2, 3, 2)]
        [DataRow(0, 0, 0, 0)]
        [DataRow(100, 100, 100, 100)]
        public void TotalPopularityScore_VaryingPopularities_ReturnsCorrectValue(int popularity1,
                                                                                 int popularity2,
                                                                                 int popularity3,
                                                                                 int expectedScore)
        {
            //Arrange
            var artistList = GetDefaultCorrelatedArtistList().ToList();
            artistList[0].Popularity = popularity1;
            artistList[1].Popularity = popularity2;
            artistList[2].Popularity = popularity3;

            var artistPopularities = new ArtistPopularities(artistList);

            //Act
            var result = artistPopularities.TotalPopularityScore;

            //Assert
            Assert.AreEqual(expectedScore, result);
        }

        private IEnumerable<Artist> GetDefaultCorrelatedArtistList()
        {
            var artist1 = new Artist
            {
                Id = "123",
                Popularity = 50
            };

            var artist2 = new Artist
            {
                Id = "456",
                Popularity = 80
            };

            var artist3 = new Artist
            {
                Id = "789",
                Popularity = 5
            };

            return new List<Artist>
            {
                artist1, artist2, artist3
            };
        }
    }
}

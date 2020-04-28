using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.BusinessObjects;

namespace UseCases.UnitTests.BusinessObjects
{
    [TestClass]
    public class TopGenresTests
    {
        [TestMethod]
        public void GetTopGenres_VariousGenres_ReturnsCorrectList()
        {
            //Arrange
            var artist1 = new Artist
            {
                RelatedGenres =
                {
                    { "rock", "rock" },
                    { "r&b", "r&b" },
                    { "Metal", "Metal" },
                    { "Country", "Country" },
                    { "Folk", "Folk" },
                }
            };

            var artist2 = new Artist
            {
                RelatedGenres =
                {
                    { "rock", "rock" },
                    { "r&b", "r&b" }
                }
            };

            var artist3 = new Artist
            {
                RelatedGenres = { { "Rock", "Rock" } }
            };

            var artistList = new List<Artist> { artist1, artist2, artist3 };

            var topGenres = new TopGenres(artistList);

            //Act
            var result = topGenres.GetTopGenres(5).ToList();

            //Assert
            Assert.AreEqual("Rock", result[0]);
            Assert.AreEqual("R&B", result[1]);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using UseCases.BusinessObjects;

namespace UseCases.UnitTests.BusinessObjects
{
    [TestClass]
    public class ArtistTests
    {
        [TestMethod]
        public void GetCorrelationToArtist_SomeCorrelations_ReturnsCorrectValue()
        {
            //Arrange
            var artist1 = new Artist
            {
                RelatedGenres = 
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            var artist2 = new Artist
            {
                RelatedGenres =
                {
                    { "Soul", "Soul" },
                    { "Metal", "Metal" },
                    { "R&B", "R&B" }
                }
            };

            //Act
            var correlation = artist1.GetCorrelationToArtist(artist2);

            //Assert
            Assert.AreEqual(1, correlation);
        }

        [TestMethod]
        public void GetCorrelationToArtist_NoCorrelations_ReturnsZero()
        {
            //Arrange
            var artist1 = new Artist
            {
                RelatedGenres =
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            var artist2 = new Artist
            {
                RelatedGenres =
                {
                    { "Rock", "Rock" },
                    { "Metal", "Metal" },
                    { "Alternative", "Alternative" }
                }
            };

            //Act
            var correlation = artist1.GetCorrelationToArtist(artist2);

            //Assert
            Assert.AreEqual(0, correlation);
        }
    }
}

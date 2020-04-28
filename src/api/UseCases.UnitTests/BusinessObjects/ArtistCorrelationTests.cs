using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases.BusinessObjects;

namespace UseCases.UnitTests.BusinessObjects
{
    [TestClass]
    public class ArtistCorrelationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NotEnoughArtists_ThrowsException()
        {
            //Arrange
            var artistList = new List<Artist>
            {
                new Artist()
            };

            //Act
            new ArtistCorrelations(artistList);
        }

        [TestMethod]
        public void TotalCorrelations_SomeCorrelations_ReturnsCorrectValues()
        {
            //Arrange
            var artistList = GetDefaultCorrelatedArtistList();

            var correlations = new ArtistCorrelations(artistList);

            //Act
            var correlationScore = correlations.TotalCorrelations;

            //Assert
            Assert.AreEqual(2, correlationScore);
        }

        [TestMethod]
        public void TotalCorrelations_AllCorrelated_ReturnsAllCorrelations()
        {
            //Arrange
            var artistList = GetFullyCorrelatedArtistList();

            var correlations = new ArtistCorrelations(artistList);

            //Act
            var correlationScore = correlations.TotalCorrelations;

            //Assert
            Assert.AreEqual(6, correlationScore);
        }

        [TestMethod]
        public void TotalCorrelations_NoCorrelated_ReturnsZero()
        {
            //Arrange
            var artistList = GetNoCorrelatedArtistList();

            var correlations = new ArtistCorrelations(artistList);

            //Act
            var correlationScore = correlations.TotalCorrelations;

            //Assert
            Assert.AreEqual(0, correlationScore);
        }

        [TestMethod]
        public void TotalCorrelationScore_SomeCorrelations_ReturnsCorrectValues()
        {
            //Arrange
            var artistList = GetDefaultCorrelatedArtistList();

            var correlations = new ArtistCorrelations(artistList);

            //Act
            var correlationScore = correlations.TotalCorrelationScore;

            //Assert
            Assert.AreEqual(33, correlationScore);
        }

        [TestMethod]
        public void TotalCorrelationScore_AllCorrelated_Returns100()
        {
            //Arrange
            var artistList = GetFullyCorrelatedArtistList();

            var correlations = new ArtistCorrelations(artistList);

            //Act
            var correlationScore = correlations.TotalCorrelationScore;

            //Assert
            Assert.AreEqual(100, correlationScore);
        }

        [TestMethod]
        public void TotalCorrelationScore_NoCorrelated_ReturnsZero()
        {
            //Arrange
            var artistList = GetFullyCorrelatedArtistList();

            var correlations = new ArtistCorrelations(artistList);

            //Act
            var correlationScore = correlations.TotalCorrelationScore;

            //Assert
            Assert.AreEqual(100, correlationScore);
        }


        private IEnumerable<Artist> GetDefaultCorrelatedArtistList()
        {
            var artist1 = new Artist
            {
                Id = "123",
                RelatedGenres =
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            var artist2 = new Artist
            {
                Id = "456",
                RelatedGenres =
                {
                    { "Soul", "Soul" },
                    { "Metal", "Metal" },
                    { "R&B", "R&B" }
                }
            };

            var artist3 = new Artist
            {
                Id = "789",
                RelatedGenres =
                {
                    { "Country", "Country" },
                }
            };

            return new List<Artist>
            {
                artist1, artist2, artist3
            };
        }

        private IEnumerable<Artist> GetFullyCorrelatedArtistList()
        {
            var artist1 = new Artist
            {
                Id = "123",
                RelatedGenres =
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            var artist2 = new Artist
            {
                Id = "456",
                RelatedGenres =
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            var artist3 = new Artist
            {
                Id = "789",
                RelatedGenres =
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            return new List<Artist>
            {
                artist1, artist2, artist3
            };
        }

        private IEnumerable<Artist> GetNoCorrelatedArtistList()
        {
            var artist1 = new Artist
            {
                Id = "123",
                RelatedGenres =
                {
                    { "Hip Hop", "Hip Hop" },
                    { "R&B", "R&B" },
                    { "Soul", "Soul" },
                }
            };

            var artist2 = new Artist
            {
                Id = "456",
                RelatedGenres =
                {
                    { "Metal", "Metal" },
                }
            };

            var artist3 = new Artist
            {
                Id = "789",
                RelatedGenres =
                {
                    { "Country", "Country" },
                }
            };

            return new List<Artist>
            {
                artist1, artist2, artist3
            };
        }
    }
}

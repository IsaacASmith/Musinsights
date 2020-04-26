using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCases.BusinessObjects
{
    public class ArtistPopularities
    {
        private IEnumerable<Artist> _artists { get; set; }

        public ArtistPopularities(IEnumerable<Artist> artists)
        {
            _artists = artists;
        }

        private int PopularityPossible
        {
            get
            {
                return _artists.Count() * 100;
            }
        }

        public int TotalPopularityScore
        {
            get
            {
                double totalPopularity = _artists.Sum(e => e.Popularity);

                return (int)Math.Round((totalPopularity / (double)PopularityPossible) * 100, 0);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace UseCases.BusinessObjects
{
    public class ArtistCorrelations
    {
        private Dictionary<Artist, Dictionary<Artist, int>> _artistCorrelations { get; set; } = new Dictionary<Artist, Dictionary<Artist, int>>();

        public ArtistCorrelations(IEnumerable<Artist> artists)
        {
            foreach (var artist in artists)
            {
                _artistCorrelations.Add(artist, new Dictionary<Artist, int>());
                foreach(var artistToCorrelate in artists)
                {
                    if (artistToCorrelate.Id != artist.Id)
                    {
                        var correlationValue = artist.GetCorrelationToArtist(artistToCorrelate);

                        _artistCorrelations[artist].Add(artistToCorrelate, correlationValue);
                    }
                }
            }
        }

        public int TotalCorrelations
        {
            get
            {
                int totalCorrelations = 0;
                foreach (var artistCorrelation in _artistCorrelations)
                {
                    totalCorrelations += artistCorrelation.Value.Sum(e => e.Value);
                }

                return totalCorrelations;
            }
        }

        public int TotalPossibleCorrelations
        {
            get
            {
                return (int)Math.Pow(_artistCorrelations.Count, 2) - _artistCorrelations.Count;
            }
        }

        public int TotalCorrelationScore
        {
            get
            {
                if(_artistCorrelations.Count < 2)
                {
                    return 0;
                }

                var correlationScore = (double)TotalCorrelations / (double) TotalPossibleCorrelations * 100;

                return (int)Math.Round(correlationScore, 0);
            }
        }
    }

    public class ArtistCorrelation
    {
        public int Correlation { get; set; }
    }
}

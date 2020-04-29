using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCases.BusinessObjects
{
    public class ExplicitScore
    {
        private readonly IEnumerable<Track> _tracks;

        public ExplicitScore(IEnumerable<Track> tracks)
        {
            if (!tracks.Any())
            {
                throw new ArgumentException("Specify at least one track to get an explicit score.");
            }
            _tracks = tracks;
        }

        public int ExplicitScoreValue
        {
            get
            {
                return (int)Math.Round(_tracks.Sum(e => e.IsExplicit ? 1 : 0) / (decimal)_tracks.Count() * 100, 2);
            }
        }
    }
}

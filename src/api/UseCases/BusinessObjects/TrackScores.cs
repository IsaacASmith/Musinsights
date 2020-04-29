using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCases.BusinessObjects
{
    public class TrackScores
    {
        private IEnumerable<Track> _tracks { get; set; }
        public TrackScores(IEnumerable<Track> tracks)
        {
            _tracks = tracks;
        }

        public int DanceabilityScore
        {
            get
            {
                if (!_tracks.Any())
                {
                    return 0;
                }
                return (int)Math.Round(_tracks.Select(e => e.AudioFeatures).Sum(e => e.Danceability) / _tracks.Count() * 100, 0);
            }
        }

        public int EnergyScore
        {
            get
            {
                if (!_tracks.Any())
                {
                    return 0;
                }
                return (int)Math.Round(_tracks.Select(e => e.AudioFeatures).Sum(e => e.Energy) / _tracks.Count() * 100, 0);
            }
        }

        public int PositivityScore
        {
            get
            {
                if (!_tracks.Any())
                {
                    return 0;
                }
                return (int)Math.Round(_tracks.Select(e => e.AudioFeatures).Sum(e => e.Valence) / _tracks.Count() * 100, 0);
            }
        }

        public int ExplicitScore
        {
            get
            {
                if (!_tracks.Any())
                {
                    return 0;
                }
                return (int)Math.Round(_tracks.Sum(e => e.IsExplicit ? 1 : 0) / (decimal)_tracks.Count() * 100, 0);
            }
        }
    }
}

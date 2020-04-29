using System;

namespace UseCases.BusinessObjects
{
    public class Track
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsExplicit { get; set; }
        public int DurationMs { get; set; }
        public int Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }

        public TrackAudioFeatures AudioFeatures { get; set; }
    }
}

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

        public double Acousticness { get; set; }
        public double Danceability { get; set; }
        public double Energy { get; set; }
        public double Instrumentalness { get; set; }
        public double Liveness { get; set; }
        public double Loudness { get; set; }
        public double Mode { get; set; }
        public double Speechiness { get; set; }
        public double Tempo { get; set; }
        public double Valence { get; set; }
    }
}

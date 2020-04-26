using System;
using System.Collections.Generic;

namespace UseCases.BusinessObjects
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public Dictionary<string, string> RelatedGenres { get; set; } = new Dictionary<string, string>();

        public int GetCorrelationToArtist(Artist secondArtist)
        {
            foreach(var genre in RelatedGenres)
            {
                if (secondArtist.RelatedGenres.ContainsKey(genre.Key))
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}

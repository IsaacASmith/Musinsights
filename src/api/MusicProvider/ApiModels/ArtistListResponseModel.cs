using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UseCases.BusinessObjects;

namespace MusicProvider.ApiModels
{
    public class ArtistListResponseModel
    {
        public IEnumerable<ArtistResponseModel> Items { get; set; }
    }

    public class ArtistResponseModel
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public IEnumerable<string> Genres { get; set; }

        public Artist ToArtist()
        {
            return new Artist
            {
                Id = Uri,
                Name = Name,
                Popularity = Popularity,
                RelatedGenres = Genres.ToDictionary(e => e)
            };
        }
    }
}

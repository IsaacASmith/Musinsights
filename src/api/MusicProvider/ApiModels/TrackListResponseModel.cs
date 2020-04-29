using System;
using System.Collections.Generic;
using System.Text;
using UseCases.BusinessObjects;

namespace MusicProvider.ApiModels
{
    public class TrackListResponseModel
    {
        public IEnumerable<TrackResponseModel> Items { get; set; }
    }

    public class TrackResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Duration_MS { get; set; }
        public bool Explicit { get; set; }
        public int Popularity { get; set; }
        public AlbumResponseModel Album { get; set; }

        public Track ToTrack()
        {
            return new Track
            {
                Id = Id,
                Name = Name,
                IsExplicit = Explicit,
                Popularity = Popularity,
                DurationMs = Duration_MS,
                ReleaseDate = Album.GetReleaseDateTime()
            };
        }
    }

    public class AlbumResponseModel
    {
        public string Release_Date { get; set; }
        public string Release_Date_Precision { get; set; }

        public DateTime GetReleaseDateTime()
        {
            if(Release_Date_Precision == "month")
            {
                var releaseDatePieces = Release_Date.Split("-");
                return new DateTime(int.Parse(releaseDatePieces[0]), int.Parse(releaseDatePieces[1]), 1);
            }

            if(Release_Date_Precision == "year")
            {
                var releaseDatePieces = Release_Date.Split("-");
                return new DateTime(int.Parse(releaseDatePieces[0]), 1, 1);
            }

            return DateTime.Parse(Release_Date);
        }
    }
}

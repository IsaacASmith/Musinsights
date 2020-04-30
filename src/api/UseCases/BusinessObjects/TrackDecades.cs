using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCases.BusinessObjects
{
    public class TrackDecades
    {
        public Dictionary<int, int> DecadeCounts { get; } = new Dictionary<int, int>();

        public TrackDecades(IEnumerable<Track> tracks)
        {
            var minReleaseDecade = GetDecade(tracks.Min(e => e.ReleaseDate));
            var maxReleaseDecade = GetDecade(tracks.Max(e => e.ReleaseDate));

            for(int i = minReleaseDecade; i <= maxReleaseDecade; i += 10)
            {
                DecadeCounts.Add(i, 0);
            }

            foreach(var track in tracks)
            {
                DecadeCounts[GetDecade(track.ReleaseDate)] += 1;
            }
        }

        private int GetDecade(DateTime dateTime)
        {
            return dateTime.AddYears(-1 * (dateTime.Year % 10)).Year;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UseCases.BusinessObjects
{
    public class TopGenres
    {
        private IEnumerable<string> _orderedGenres { get; set; } = new List<string>();

        public TopGenres(IEnumerable<Artist> artistsOrderedByTop)
        {
            var _genreScores = new Dictionary<string, double>();

            int i = 0;
            foreach (var artist in artistsOrderedByTop)
            {
                foreach(var genre in artist.RelatedGenres)
                {
                    if (!_genreScores.ContainsKey(genre.Key))
                    {
                        _genreScores.Add(genre.Key, 0);
                    }
                    _genreScores[genre.Key] += 1 * (1 - .01 * i);
                }
                i += 1;
            }

            _orderedGenres = _genreScores.OrderByDescending(e => e.Value).Select(e => GetCapitalized(e.Key));
        }

        public IEnumerable<string> GetTopGenres(int count = 5)
        {
            return _orderedGenres.Take(Math.Min(count, _orderedGenres.Count()));
        }

        private string GetCapitalized(string value)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(value);
        }
    }
}

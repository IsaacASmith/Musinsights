using System;
using System.Collections.Generic;
using System.Text;
using UseCases.BusinessObjects;

namespace MusicProvider.ApiModels
{
    public class AudioFeaturesResponseModel
    {
        public IEnumerable<AudioFeatureResponseModel> Audio_Features { get; set; }
    }

    public class AudioFeatureResponseModel
    {
        public string Id { get; set; }
        public decimal Danceability { get; set; }
        public decimal Energy { get; set; }
        public decimal Loudness { get; set; }
        public decimal Speechiness { get; set; }
        public decimal Acousticness { get; set; }
        public decimal Instrumentalness { get; set; }
        public decimal Liveness { get; set; }
        public decimal Valence { get; set; }
        public decimal Tempo { get; set; }
        public decimal Mode { get; set; }

        public TrackAudioFeatures ToBusinessObject()
        {
            return new TrackAudioFeatures
            {
                Danceability = Danceability,
                Energy = Energy,
                Loudness = Loudness,
                Speechiness = Speechiness,
                Acousticness = Acousticness,
                Instrumentalness = Instrumentalness,
                Liveness = Liveness,
                Valence = Valence,
                Tempo = Tempo,
                Mode = Mode
            };
        }
    }
}

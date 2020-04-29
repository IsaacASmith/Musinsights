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
        public double Danceability { get; set; }
        public double Energy { get; set; }
        public double Loudness { get; set; }
        public double Speechiness { get; set; }
        public double Acousticness { get; set; }
        public double Instrumentalness { get; set; }
        public double Liveness { get; set; }
        public double Valence { get; set; }
        public double Tempo { get; set; }
        public double Mode { get; set; }

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

<template>
    <div class="time-based-insight">
        <div class="high-level-stats">
            <div class="high-level-stat">
                <p>Genre Diversity Score:</p>
                <p>{{insight.diversityScore}}</p>
            </div>
            <div class="high-level-stat">
                <p>Artist Mainstream Score:</p>
                <p>{{insight.mainstreamScore}}</p>
            </div>
            <div class="high-level-stat">
                 <p>Explicit Lyric Score:</p>
                <p>{{insight.explicitScore}}</p>
            </div>
        </div>
        <div class="data-list">
            <h3>Your Top Artists</h3>
            <p v-for="(artist, index) in insight.topArtists" :key="artist">{{index + 1}}. {{artist}}</p>
        </div>
        <div class="data-list">
            <h3>Your Top Songs</h3>
            <p v-for="(song, index) in insight.topTracks" :key="song">{{index + 1}}. {{song}}</p>
        </div>
        <div class="data-list">
            <h3>Your Top Genres</h3>
            <p v-for="(genre, index) in insight.topGenres" :key="genre">{{index + 1}}. {{genre}}</p>
        </div>
    </div>
</template>

<script>
export default {
  name: 'TimeBasedInsight',
  props: ['insight']
}
</script>

<style scoped>
  .time-based-insight {
    width: 100%;
  }

  .high-level-stats {
      width: 100%;
      display: flex;
      flex-direction: row;
      flex-wrap:wrap;
      justify-content: center;
      background-color: #1d2935;
      padding: 20px 8px;
      border-radius: 10px;
      box-shadow: 2px 2px 3px #131a21;
  }

  .high-level-stat {
      font-size: 10pt;
      margin: 10px;
      width: 120px;
      padding: 8px;
      padding-bottom: 0;
      border-radius: 5px;
      background-color: #344a5f;
      margin-bottom: 10px;
      box-shadow: 2px 2px 3px #131a21;
      display: flex;
      flex-direction: column;
      justify-content: space-between;
  }

  .data-list{
      margin-top: 15px;
      text-align: left;
      background-color: #1d2935;
      padding: 5px 25px;
      border-radius: 10px;
      box-shadow: 2px 2px 3px #131a21;
  }

  .data-list h3 {
      margin-top: 20px;
      margin-bottom: 20px;
  }
</style>

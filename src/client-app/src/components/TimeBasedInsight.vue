<template>
    <div class="time-based-insight">
        <div class="high-level-stats">
            <HighLevelStat :value="insight.diversityScore" maxValue="100" title="Genre Diversity Score" uniqueId="div-score"/>
            <HighLevelStat :value="insight.mainstreamScore" maxValue="100" title="Mainstream Score" uniqueId="mainstream-score"/>
            <HighLevelStat :value="insight.positivityScore" maxValue="100" title="Positivity Score" uniqueId="positivity-score"/>
            <HighLevelStat :value="insight.danceabilityScore" maxValue="100" title="Danceability Score" uniqueId="danceability-score"/>
            <HighLevelStat :value="insight.energyScore" maxValue="100" title="Energy Score" uniqueId="energy-score"/>
            <HighLevelStat :value="insight.explicitScore" maxValue="100" title="Explicit Lyric Score" uniqueId="explicit-score"/>
        </div>
        <div class="data-list-container">
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
    </div>
</template>

<script>
import HighLevelStat from '../components/HighLevelStat'

export default {
  name: 'TimeBasedInsight',
  props: ['insight'],
  components: {
    HighLevelStat
  }
}
</script>

<style scoped>
  .loading-status {
    margin-bottom: 35px;
  }

  .data-list-container {
    display: flex;
    flex-direction: column;
  }

  .time-based-insight {
    width: 100%;
  }

  .high-level-stats {
      width: 100%;
      display: flex;
      flex-direction: column;
      justify-content: center;
      background-color: #1d2935;
      padding: 20px 8px;
      padding-bottom: 5px;
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
      width: 100%;
  }

  .data-list h3 {
      margin-top: 20px;
      margin-bottom: 20px;
  }

  @media screen and (min-width: 1100px) {
    .high-level-stats {
      flex-direction: row;
      flex-wrap:wrap;
      justify-content: space-between;
    }

    .data-list-container {
      flex-direction: row;
    }

    .data-list:last-child {
      margin-right: 0;
    }
    .data-list {
      margin-right: 30px;
    }
  }
</style>

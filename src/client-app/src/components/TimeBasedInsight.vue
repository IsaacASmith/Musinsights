<template>
    <div class="time-based-insight">
        <div class="high-level-stats">
            <div class="high-level-stat">
                <p>Genre Diversity Score:</p>
                <p>{{insight.diversityScore}}</p>
            </div>
            <div class="high-level-stat">
                <p>Artist Obscurity Score:</p>
                <p>{{insight.obscurityScore}}</p>
            </div>
        </div>
        <div class="artist-list">
            <h3>Your Top Artists</h3>
            <p v-for="(artist, index) in insight.topArtists" :key="artist">{{index + 1}}. {{artist}}</p>
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
      background-color: rgb(25, 25, 26);
      padding: 0 25px;
      padding-top: 20px;
      border-radius: 10px;
      box-shadow: 1px 1px 3px black;
  }

  .high-level-stat {
      margin: 0 20px;
  }

  .artist-list{
      margin-top: 15px;
      text-align: left;
      background-color: rgb(25, 25, 26);
      padding: 5px 25px;
      border-radius: 10px;
      box-shadow: 1px 1px 3px black;
  }

  .artist-list h3 {
      margin-top: 20px;
      margin-bottom: 20px;
  }
</style>

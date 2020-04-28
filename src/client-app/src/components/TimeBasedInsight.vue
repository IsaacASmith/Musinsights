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
  }

  .high-level-stat {
      margin: 0 20px;
  }
</style>

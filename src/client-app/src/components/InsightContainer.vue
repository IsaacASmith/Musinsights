<template>
    <div>
      <h3 class="title">Music Insights</h3>
      <v-select
        v-model="selectedTimeRange"
        :items="timeRangeOptions"
        item-text="desc"
        item-value="name"
        label="Select Time Range"
        :color="'#2c3e50'"
        outline
        solo
        persistent-hint
        full-width
        class="time-range-select"
      ></v-select>
      <TimeBasedInsight v-if="userInsights.length > 2" :insight="selectedInsight"/>
    </div>
</template>

<script>
import TimeBasedInsight from './TimeBasedInsight'

export default {
  name: 'InsightContainer',
  components: {
    TimeBasedInsight
  },
  data () {
    return {
      selectedTimeRange: 'ShortTerm',
      timeRangeOptions: [
        { desc: 'Past Month', name: 'ShortTerm' },
        { desc: 'Past 6 Months', name: 'MediumTerm' },
        { desc: 'All Time', name: 'LongTerm' }
      ]
    }
  },
  props: ['userInsights'],
  computed: {
    selectedInsight () {
      if (this.userInsights.length < 3) {
        return
      }
      console.log(this.userInsights.filter(insight => {
        return insight.timeRange === this.selectedTimeRange
      }))
      return this.userInsights.filter(insight => {
        return insight.timeRange === this.selectedTimeRange
      })[0]
    }
  }
}
</script>

<style scoped>
  .title {
    margin-bottom: 30px;
    text-align: left;
  }

  .time-range-select {
    margin-bottom: 20px;
  }
</style>

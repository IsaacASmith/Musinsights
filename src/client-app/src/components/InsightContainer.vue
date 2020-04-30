<template>
    <div class="insight-container">
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
      <v-btn color="#1d2935" class="connect-again-btn" @click="connectNewAccount">Connect A Different Account</v-btn>
    </div>
</template>

<script>
import TimeBasedInsight from './TimeBasedInsight'
import authHelper from '../helpers/authHelper.js'

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
      return this.userInsights.filter(insight => {
        return insight.timeRange === this.selectedTimeRange
      })[0]
    }
  },
  methods: {
    connectNewAccount () {
      authHelper.getAccessKey(true)
    }
  }
}
</script>

<style scoped>
  .insight-container {
    width: 100%;
  }

  .title {
    margin-bottom: 30px;
    text-align: left;
  }

  .time-range-select {
    margin-bottom: 20px;
  }

  .connect-again-btn {
    margin-top: 25px;
    color: white;
  }
</style>

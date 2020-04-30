<template>
    <div class="tracks-graph-container">
        <h3>Listening Across The Decades</h3>
            <v-sparkline :labels="dataPointLabels" 
                        :value="dataPointValues"
                        type="bar"
                        :lineWidth="10"
                        :width="200"
                        :labelSize="labelSize"
                        :gradient="['#416180']">
            </v-sparkline>
    </div>
</template>

<script>

export default {
  name: 'TracksPerDecade',
  props: ["model"],
  data () {
    return {
      labelSize: 8
    }
  },
  mounted () {
    this.onResize()
    window.addEventListener('resize', this.onResize, { passive: true })
  },
  computed: {
    dataPointLabels () {
      if (this.model == undefined) {
          return []
      }
      return Object.keys(this.model).map(val => { return val + 's' })
    },
    dataPointValues () {
      if (this.model == undefined) {
          return []
      }
      return Object.values(this.model)
    },
  },
  methods: {
    onResize() {
      this.labelSize = window.innerWidth < 1100 ? 6 : 3
    }
  }
}
</script>

<style scoped>
  .tracks-graph-container {
      background-color: #1d2935;
      border-radius: 10px;
      box-shadow: 2px 2px 3px #131a21;
      padding: 20px 8px;
  }

  .tracks-graph-container h3{
    margin-bottom: 20px;
  }
</style>
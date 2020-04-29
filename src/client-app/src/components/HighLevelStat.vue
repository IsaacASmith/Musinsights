<template>
    <div class="container">
        <h3>{{title}}</h3>
        <h3 class="value-text">{{value}}</h3>
        <canvas :id="uniqueId" class="value-canvas" width="800" height="800"></canvas>
    </div>
</template>

<script>
import DrawingHelper from '../helpers/DrawingHelper'

export default {
  name: 'HighLevelStat',
  props: ['title', 'value', 'maxValue', 'uniqueId'],
  watch: {
    value () {
      this.drawValue()
    }
  },
  mounted: function () {
    this.drawValue()
  },
  methods: {
    drawValue () {
      const drawing = new DrawingHelper()
      drawing.drawBGCircle(this.uniqueId)
      drawing.drawValueCircle(this.uniqueId, this.value / this.maxValue)
    }
  }
}
</script>

<style scoped>
  .container {
    width: 300px;
  }
  
  h3 {
    font-size: 16pt;
  }
  .value-text {
    margin-top: 25px;
    margin-bottom: -2px;
    font-size: 20pt;
  }

  .value-canvas {
    margin-top: -58px;
    width: 80px;
    height: 80px;
  }
</style>

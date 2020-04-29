class DrawingHelper {
  drawBGCircle (canvasId) {
    const canvas = document.getElementById(canvasId)
    const ctx = canvas.getContext('2d')
    ctx.strokeStyle = '#000'
    ctx.lineWidth = 50
    ctx.beginPath()
    ctx.arc(400, 400, 350, 0, 2 * Math.PI)
    ctx.stroke()
  }

  drawValueCircle (canvasId, percentToDraw) {
    const canvas = document.getElementById(canvasId)
    const ctx = canvas.getContext('2d')
    ctx.translate(400, 400)
    ctx.rotate(270 * Math.PI / 180)
    ctx.translate(-400, -400)

    var i = 0
    var timer = setInterval(function () {
      ctx.strokeStyle = '#344a5f'
      ctx.lineWidth = 50
      ctx.beginPath()
      ctx.arc(400, 400, 350, 0, 2 * Math.PI * percentToDraw * i / 100, false)
      ctx.stroke()
      i = i + 1
      if (i >= 100) {
        ctx.translate(400, 400)
        ctx.rotate(90 * Math.PI / 180)
        ctx.translate(-400, -400)
        clearInterval(timer)
      }
    }, 10)
  }
}

export default DrawingHelper

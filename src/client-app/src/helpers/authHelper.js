const spotifyAccessKey = 'spotifyAccessKey'
const accessKeyExpiration = 'accessKeyExpiration'
const userIdKey = 'userId'

export default class authHelper {
  static hasAccessKey () {
    if (new Date(localStorage[accessKeyExpiration]) <= new Date()) {
      return false
    }
    return localStorage[spotifyAccessKey]
  }

  static getAccessKey (shouldReprompt = false) {
    var accessKey = localStorage[spotifyAccessKey]
    if (!accessKey || new Date(localStorage[accessKeyExpiration]) <= new Date()) {
      const userId = this.getOrCreateUserId()
      window.location.href = `https://accounts.spotify.com/authorize?client_id=${process.env.VUE_APP_SPOTIFY_CLIENT_ID}&response_type=token&redirect_uri=${process.env.VUE_APP_SPOTIFY_REDIRECT_URL}&scope=${process.env.VUE_APP_SPOTIFY_SCOPES}&show_dialog=${shouldReprompt}&state=${userId}`
    }
    return accessKey
  }

  static clearAccessKey () {
    localStorage[spotifyAccessKey] = ''
  }

  static setAccessKey (authResponse) {
    const stateStartIndex = authResponse.indexOf('state') + 6
    const state = authResponse.substring(stateStartIndex, authResponse.length)
    console.log(state, this.getOrCreateUserId())
    if (state !== this.getOrCreateUserId()) {
      return
    }

    const tokenStartIndex = authResponse.indexOf('access_token') + 13
    const tokenEndIndex = authResponse.indexOf('&')
    const accessKey = authResponse.substring(tokenStartIndex, tokenEndIndex)
    localStorage[spotifyAccessKey] = accessKey

    const expiresInStartIndex = authResponse.lastIndexOf('expires_in') + 11
    const expirationSubstr = authResponse.substring(expiresInStartIndex, authResponse.length)
    const expiresInEndIndex = expirationSubstr.indexOf('&')
    const expiresIn = expirationSubstr.substring(0, expiresInEndIndex)

    const expirationDate = new Date()
    expirationDate.setSeconds(expirationDate.getSeconds() + Number(expiresIn) - 120)
    localStorage[accessKeyExpiration] = expirationDate
  }

  static getOrCreateUserId () {
    if (!localStorage[userIdKey]) {
      localStorage[userIdKey] = this.guidGenerator()
    }
    return localStorage[userIdKey]
  }

  static guidGenerator () {
    var S4 = function () {
      return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1)
    }
    return (S4() + S4() + '-' + S4() + '-' + S4() + '-' + S4() + '-' + S4() + S4() + S4())
  }
}

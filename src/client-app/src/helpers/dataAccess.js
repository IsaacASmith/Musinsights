import apiHelper from './apiHelper.js'

const insightsCacheKey = 'InsightsValue'
const insightsCacheExpiration = 'InsightsExpiration'

export default class dataAccess {
  static async hasCachedValue () {
    return localStorage[insightsCacheKey] === undefined || new Date(localStorage[insightsCacheExpiration]) <= new Date()
  }

  static async getInsights (userId) {
    if (localStorage[insightsCacheKey] !== undefined && localStorage[insightsCacheKey] !== '') {
      const insights = JSON.parse(localStorage[insightsCacheKey])
      if (insights.apiVersion !== process.env.VUE_APP_INSIGHTS_API_VERSION) {
        localStorage[insightsCacheKey] = ''
      }
    }

    if (localStorage[insightsCacheKey] === undefined ||
        localStorage[insightsCacheKey] === '' ||
        new Date(localStorage[insightsCacheExpiration]) <= new Date()) {
      const expirationDate = new Date()
      expirationDate.setSeconds(expirationDate.getSeconds() + Number(86400))

      localStorage[insightsCacheExpiration] = expirationDate

      localStorage[insightsCacheKey] = JSON.stringify(await apiHelper.getInsights(userId))
    }
    return JSON.parse(localStorage[insightsCacheKey]).insights
  }

  static async clearCache () {
    localStorage[insightsCacheKey] = undefined
    localStorage[insightsCacheExpiration] = new Date(1990, 1, 1, 1, 1, 1, 1)
  }
}

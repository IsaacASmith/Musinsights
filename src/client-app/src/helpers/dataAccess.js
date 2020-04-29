import apiHelper from './apiHelper.js'

const insightsCacheKey = 'InsightsValue'
const insightsCacheExpiration = 'InsightsExpiration'

export default class dataAccess {
  static async getInsights (userId) {
    if (localStorage[insightsCacheKey] === undefined || new Date(localStorage[insightsCacheExpiration]) <= new Date()) {
      const expirationDate = new Date().setHours(new Date().getHours() + 48)
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

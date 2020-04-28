import authHelper from './authHelper.js'

export default class apiHelper {
  static async getInsights (userId) {
    const reqUrl = `${process.env.VUE_APP_INSIGHTS_ROUTE}?userId=${userId}`
    return await this.makeReq('POST', reqUrl)
  }

  static makeReq (method, url) {
    return new Promise(function (resolve, reject) {
      const xhr = new XMLHttpRequest()
      xhr.open(method, url)
      xhr.setRequestHeader('AccessToken', authHelper.getAccessKey())
      xhr.onload = function () {
        if (this.status >= 200 && this.status < 300) {
          resolve(JSON.parse(xhr.response))
        } else {
          reject(new Error(xhr.statusText))
        }
      }
      xhr.onerror = function () {
        reject(new Error(xhr.statusText))
      }
      xhr.send()
    })
  }
}

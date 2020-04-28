<template>
  <div class="explore">
    <div class="content-container">
        <div class="connect-container" v-if="!isAuthenticated">
            <h2>Connect To Spotify</h2>
            <p>
                In order to learn about your music tastes, we need to communicate with Spotify.
            </p>
            <v-btn color="#344a5f" @click="authUser">Connect >></v-btn>
            <p class="privacy-text">
                Your spotify information is never shared outside of this site.
            </p>
        </div>
        <div v-else>
            <InsightContainer :userInsights="userInsights"/>
        </div>
    </div>
  </div>
</template>

<script>
import authHelper from '../helpers/authHelper.js'
import dataAccess from '../helpers/dataAccess.js'
import InsightContainer from '../components/InsightContainer'

export default {
  name: 'Explore',
  components: {
    InsightContainer
  },
  data () {
    return {
      isAuthenticated: false,
      userInsights: []
    }
  },
  mounted: async function () {
    if (authHelper.hasAccessKey()) {
      this.isAuthenticated = true
      await this.loadData()
    } else {
      this.isAuthenticated = false
    }
  },
  methods: {
    authUser: () => {
      authHelper.getAccessKey()
    },
    loadData: async function () {
      this.userInsights = await dataAccess.getInsights(authHelper.getOrCreateUserId())
    }
  }
}
</script>

<style scoped>
  .explore{
    display: flex;
    align-items: center;
    justify-content: center;
    min-height: 90vh;
  }

  .explore *{
      color: white;
  }

  .explore p{
      text-align: left;
      font-size: 12pt;
      margin: 20px;
  }

  .content-container{
    width: 500px;
    background-color: #2c3e50;
    box-shadow: 0px 0px 15px black;
    border-radius: 5px;
    padding: 30px;
    display: flex;
    align-items: center;
    flex-direction: column;
    text-align: center;
  }
</style>

<template>
  <div class="explore">
    <div class="content-container">
        <div class="connect-container" v-if="!isAuthenticated">
            <h2>Connect To Your Music</h2>
            <p>
                In order to learn about your music tastes, we need to communicate with a music service.
            </p>
            <v-btn color="#2c3e50" @click="authUser">Connect Spotify >></v-btn>
            <p class="privacy-text">
                Your information is never shared outside of this site.
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
    background-color: #344a5f;
    box-shadow: 0px 0px 15px #131a21;
    border-radius: 5px;
    padding: 30px;
    display: flex;
    align-items: center;
    flex-direction: column;
    text-align: center;
    margin: 30px 0;
  }
</style>

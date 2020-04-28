<template>
  <v-app>
    <v-app-bar
      app
      color="#2c3e50"
      dark
      class="app-bar"
    >
      <router-link class="nav-title" to="/">
        <h1>Musinsights</h1>
      </router-link>
      <router-link to="/explore">
        <v-btn class="nav-btn" color="#344a5f">Explore</v-btn>
      </router-link>
      <router-link to="/about">
        <v-btn class="nav-btn" color="#344a5f">About</v-btn>
      </router-link>
    </v-app-bar>
    <v-content class="content-wrapper">
      <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
import authHelper from './helpers/authHelper.js'
export default {
  name: 'App',
  mounted: function () {
    if (this.$route.path.includes('access_token')) {
      this.handleSpotifyRedirect()
    }
  },
  methods: {
    handleSpotifyRedirect: function () {
      if (!authHelper.hasAccessKey()) {
        authHelper.setAccessKey(this.$route.path)
      }
      this.$router.push('explore')
    }
  }
}
</script>

<style scoped>
  .nav-title{
    color: white;
    text-decoration: none;
  }
 .content-wrapper{
   background-color: #19191a;
 }
 .nav-btn{
   margin-left: 30px;
 }
</style>

<style>
  button, button *{
    text-decoration: none !important;
    outline: none !important;
  }
</style>

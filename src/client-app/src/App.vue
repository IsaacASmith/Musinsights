<template>
  <v-app>
    <v-app-bar
      app
      color="#2c3e50"
      dark
      class="app-bar"
    >
    <div class="nav-links-container">
      <router-link class="nav-title" to="/">
        <h1>Musinsights</h1>
      </router-link>
      <div>
        <router-link to="/explore">
          <v-btn class="nav-btn" color="#344a5f">Explore</v-btn>
        </router-link>
        <router-link to="/about">
          <v-btn class="nav-btn" color="#344a5f">About</v-btn>
        </router-link>
      </div>
    </div>
    </v-app-bar>
    <v-content class="content-wrapper">
      <transition name="fade">
        <router-view></router-view>
      </transition>
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
  .nav-links-container {
    display: flex;
    align-items: center;
  }

  .nav-title{
    color: white;
    text-decoration: none;
  }
 .content-wrapper{
   background-color: #1d2935;
 }
 .nav-btn{
   margin-left: 30px;
 }

 .fade-enter-active {
    transition-property: margin-top;
    transition-duration: .25s;
  }

  .fade-enter-active {
    transition-delay: 0s;
  }

  .fade-enter {
    margin-top: 15px;
  }

  @media screen and (max-width: 485px){
    .nav-links-container {
      flex-direction: column;
      margin-left: -15px;
      margin-top: 40px;
    }
    header {
      height: 105px !important;
    }
    .nav-btn{
      margin-left: 15px;
    }
    .content-wrapper {
      margin-top: 60px;
    }
  }
</style>

<style>
  button, button *{
    text-decoration: none !important;
    outline: none !important;
  }
</style>

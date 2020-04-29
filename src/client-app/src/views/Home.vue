<template>
  <div class="home">
    <div class="welcome-container">
      <div class="home-action-container">
        <h1>Musinsights</h1>
        <h3>Learn more about your music interests</h3>
        <div class="try-it-container">
          <router-link to="/explore">
            <v-btn color="#2c3e50">Try it now >></v-btn>
          </router-link>
        </div>
      </div>
    </div>
    <div class="bottom-container"></div>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped>
.home * {
  color: white;
}

.home {
  width: 100%;
  height: 100%;
}

.welcome-container {
  background-color: #1d2935;
  background-size: cover;
  width: 100%;
  display: flex;
  align-items: center;
  flex-direction: column;
}

.home-action-container {
  background-color: #344a5f;
  padding: 20px;
  margin: 175px 0;
  max-width: 500px;
  box-shadow: 0px 0px 15px #131a21;
  border-radius: 5px;
}

.home-action-container * {
  margin-top: 10px;
}

.bottom-container {
  background-color: #344a5f;
  width: 100%;
  min-height: 300px;
}

@media screen and (min-width: 1300px) {
  .home-action-container {
    margin: 250px 0;
  }
}

@media screen and (max-width: 500px) {
  .home-action-container {
    width: 100%;
    margin: 200px 0;
  }
}
</style>

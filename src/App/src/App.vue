<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script lang="ts">
export default {
  name: 'App',
};
</script>

<style lang="scss" scoped>
*, *:before, *:after {
  box-sizing: border-box;
}

#app {
  padding: 1px 0;
  height: 100vh;
  width: 100vw;
  background-image: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/226578/campnou(optimized).jpg");
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  color: #fff;
  font-family: "Comfortaa", "Helvetica", sans-serif;
}
</style>


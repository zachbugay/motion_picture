<template>
  <div>
    <motion-pictures msg="Hello Dude!"></motion-pictures>
  </div>
</template>

<script>
import MotionPictures from './components/MotionPictures.vue'

export default {
  name: 'App',
  components: {
    MotionPictures
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

<template>
  <div>
    <h1>Motion Pictures</h1>
    <p>{{ msg }}</p>
  </div>
</template>

<script>
  export default {
    name: "MotionPictures",
    props: {
      msg: String
    }
  }
</script>

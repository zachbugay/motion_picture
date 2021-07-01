<template>
  <td class="col"> {{ displayNumber }} </td>
  <td class="col"> {{ name }} </td>
  <td class="col"> {{ releaseYear }} </td>
  <td class="col"> {{ description }} </td>
  <td class="col">
    <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'pen-square']" />
    <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'copy']" />
    <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'trash']" />
  </td>
</template>

<script>
export default {
  name: 'MotionPictures',
  props: {
    id: Number,
    displayNumber: Number,
    name: String,
    releaseYear: Number,
    description: String
  }
}
</script>

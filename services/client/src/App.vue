<template>
  <div id="app" class="container p-5 text-center">
    <h1>Motion Pictures</h1>
    <section v-if="errored">
      <p>We're sorry, but we are unable to retrieve this information at the moment. Please try again later. </p>
    </section>
    <section v-else>
      <div v-if="loading">Loading...</div>
      <div
        v-else
      >
        <div class="container p-1 text-end">
          <button class="btn btn-primary">
            <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'plus-circle']" />
            Add
          </button>
        </div>
        <table class="table table-striped table-hover table-bordered">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Name</th>
              <th scope="col">Release Year</th>
              <th scope="col">Description</th>
              <th scope="col">Actions</th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="(obj, index) in motionPictures"  v-bind:key="obj.id"
            >
            <motion-pictures
              class="row"
              :id=obj.id
              :displayNumber="index + 1"
              :name="obj.name"
              :releaseYear="obj.releaseYear"
              :description="obj.description"
            />
            </tr>
          </tbody>
        </table>
      </div>
    </section>
  </div>
</template>

<script>
import MotionPictures from './components/MotionPictures.vue'

export default {
  name: 'App',
  components: {
    MotionPictures
  },
  data() {
    return {
      motionPictures: [],
      loading: true,
      errored: false
    };
  },
  mounted: function() {
    fetch('http://localhost:5000/api/motionpictures', {
      method: 'GET'
    }).then((response) => {
      return response.json();
    }).then((data) =>  {
      this.motionPictures = data.payload.motionPictures;
    }).catch((error) => {
      console.log(error);
    }).finally(() => {
      this.loading = false;
    });
  }
}
</script>

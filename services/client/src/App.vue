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
          <add-motion-picture-modal
            buttonMessage="Add"
            modalTitle="Add a Motion Picture"
            apiUrl="http://localhost:5000/api/motionpictures"
            :showModal=showAddModal
            @showToastNotification="showToastMessage"
          />
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
        <toast-notification
          :notificationMessage=toastMessage
          :showToast=showToast
        />
      </div>
    </section>
  </div>
</template>

<script>
import AddMotionPictureModal from './components/AddMotionPictureModal.vue';
import MotionPictures from './components/MotionPictures.vue'
import ToastNotification from './components/ToastNotification.vue';

export default {
  name: 'App',
  components: {
    MotionPictures,
    AddMotionPictureModal,
    ToastNotification
  },
  data() {
    return {
      motionPictures: [],
      loading: true,
      errored: false,
      showAddModal: false,
      showToast: false,
      toastMessage: ""
    };
  },
  mounted: function() {
    // fetch('https://localhost:44324/api/motionpictures', {
    fetch('http://localhost:5000/api/motionpictures', {
      method: 'GET'
    }).then((response) => {
      return response.json();
    }).then((data) =>  {
      this.motionPictures = data.payload.motionPictures;
    }).catch((error) => {
      console.log(error);
      this.errored = true;
    }).finally(() => {
      this.loading = false;
    });
  }, methods: {
    showToastMessage(message) {
      this.showToast = true;
      this.toastMessage = message;
    }
  }
}
</script>

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
            modalTitle="Add a Motion Picture"
            buttonMessage="Add"
            apiUrl="http://localhost:5000/api/motionpictures"
            :showModal=showAddModal
            @onShowToastNotification="showToastMessage"
          />
          <confirmation-modal
            modalTitle="Are You Sure?"
            :motionPicture=motionPictureForDeletion
            @onShowToastNotification="showToastMessage"
          />
          <edit-motion-picture-modal
            modalTitle="Edit a Motion Picture"
            buttonMessage="Edit"
            apiUrl="http://localhost:5000/api/motionpictures"
            :showModal=showAddModal
            :motionPicture=this.motionPictureForEdit
            @onShowToastNotification="showToastMessage"
            @onClickDelete="deleteMotionPicture"
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
              v-for="(obj, index) in motionPictures" v-bind:key="obj.id" v-bind="$attrs"
            >
            <motion-pictures
              class="row"
              :id=obj.id
              :displayNumber="index + 1"
              :name="obj.name"
              :releaseYear="obj.releaseYear.toString()"
              :description="obj.description"
              apiUrl="http://localhost:5000/api/motionpictures"
              @onShowToastNotification="showToastMessage"
              @onEditClick="editButtonClicked"
            />
            </tr>
          </tbody>
        </table>
        <toast-notification
          :notificationMessage=toastMessage
          :showToast=showToast
          @onHideToast="hideToastMessage"
        />
      </div>
    </section>
  </div>
</template>

<script>
import AddMotionPictureModal from './components/AddMotionPictureModal.vue';
import ConfirmationModal from './components/ConfirmationModal.vue';
import EditMotionPictureModal from './components/EditMotionPictureModal.vue';
import MotionPictures from './components/MotionPictures.vue'
import ToastNotification from './components/ToastNotification.vue';

export default {
  name: 'App',
  components: {
    MotionPictures,
    AddMotionPictureModal,
    ToastNotification,
    ConfirmationModal,
    EditMotionPictureModal
  },
  data() {
    return {
      motionPictures: [],
      loading: true,
      errored: false,
      showAddModal: false,
      showToast: false,
      toastMessage: "",
      motionPictureForDeletion: {},
      motionPictureForEdit: {}
    };
  }, created: function() {
    this.fetchMotionPictures();
  }, methods: {
    showToastMessage(message) {
      console.log("MESSAGE RECIEVED: ", message);
      this.showToast = true;
      this.toastMessage = message;
      this.fetchMotionPictures();
      setTimeout(() => this.showToast = false, 6000)
    },
    hideToastMessage() {
      console.log('hideToastMessage');
      this.showToast = false;
    },
    editButtonClicked(value) {
      this.motionPictureForEdit = value;
    },
    fetchMotionPictures() {
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
        }
      );
    },
    deleteMotionPicture(value) {
      console.log('this is going to be deleted');
      console.log(value);
      this.motionPictureForDeletion = value;
    }
  }
}
</script>

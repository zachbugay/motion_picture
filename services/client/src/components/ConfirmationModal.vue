<template>
<div>
<div class="modal fade show" id="deleteStaticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="deleteStaticBackdropLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="deleteStaticBackdropLabel">{{ modalTitle }}</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <p>Are you sure you wish to delete the Motion Picture</p>
          <p>{{ this.motionPicture.Name}}</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary" @click="clickedDeleteConfirmation">Delete</button>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import { Modal } from 'bootstrap';

export default {
    name: "ConfirmationModal",
    emits: [
      "onShowToastNotification",
    ],
    props: {
      "modalTitle": String,
      "motionPicture": Object,
    },
    methods: {
      clickedDeleteConfirmation() {
        fetch(`${process.env.VUE_APP_MP_APIURL}/api/motionpictures/${this.motionPicture.id}`, {
            method: 'DELETE',
            body: {}
          }).then((response) => {
            console.log(response);
          }).catch((error) => {
            console.log(error);
          }).finally(() => {
            console.log("Deleted I hope");
            // this.$emit("onShowToastNotification", `Successfully Deleted: ${this.deleteId}`);
            const container = document.querySelector("#deleteStaticBackdrop");
            const modal = Modal.getInstance(container);
            modal.hide();
            this.$emit("onShowToastNotification", "Motion Picture was Successfully Deleted!");
          }
        );
      }
    }
  };
</script>

<template>
  <div>
    <!-- Modal -->
    <div class="modal fade"
      id="editStaticBackDrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="editStaticBackDropLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="editStaticBackDropLabel">{{ modalTitle }}</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
            <div class="modal-body">
              <form
                @submit="checkForm"
              >
                <name-input
                  id="nameInput"
                  inputLabel="Name"
                  :defaultValue=motionPicture.Name
                  @nameChange="nameChange"
                  @nameIsValid="onValidName"
                />
                <description-input
                  id="descriptionInput"
                  inputLabel="Description"
                  :defaultValue=motionPicture.Description
                  @descChange="descChange"
                  @descIsValid="onValidDesc"
                />
                <year-input
                  id="yearInput"
                  inputLabel="Release Year"
                  :defaultValue=motionPicture.Year
                  @yearChange="yearChange"
                  @yearIsValid="onValidYear"
                />
              </form>
            </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
            <button id="btn-add-mp" @click="click" type="button" class="btn btn-primary"
              :class="[
                (this.nameIsValid && this.descIsValid && this.yearIsValid) ? '' : 'disabled'
              ]"
            >Edit</button>
            <button id="btn-add-mp" @click="deleteMotionPicture" type="button" class="btn bg-danger text-light"
              data-bs-toggle="modal" data-bs-target="#deleteStaticBackdrop"
            >Delete</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DescriptionInput from './DescriptionInput.vue';
import NameInput from './NameInput.vue';
import YearInput from './YearInput.vue';
import { Modal } from 'bootstrap';

export default {
  components: { NameInput, DescriptionInput, YearInput },
    name: "EditMotionPictureModal",
    emits: [
      "onEditClick",
      "onShowToastNotification",
    ],
    props: {
      "buttonMessage": String,
      "modalTitle": String,
      "apiUrl": String,
      "showAddModal": Boolean,
      "motionPicture": Object
    },
    data() {
      return {
        nameValue: "",
        descValue: "",
        yearValue: "",
        nameIsValid: false,
        descIsValid: false,
        yearIsValid: false
      }
    },
    methods: {
      nameChange(value) {
        this.nameValue = value;
      },
      descChange(value) {
        this.descValue = value;
      },
      yearChange(value) {
        this.yearValue = value;
      },
      checkForm(event) {
        event.preventDefault();
      },
      onValidName(value) {
        this.nameIsValid = value;
      },
      onValidDesc(value) {
        this.descIsValid = value;
      },
      onValidYear(value) {
        this.yearIsValid = value;
      },

      click() {
        let payload = {
          "Name": this.nameValue,
          "Description": this.descValue,
          "ReleaseYear": parseInt(this.yearValue)
        };
        console.log("-=-=-- PAYLOAD IS -==-=-")
        console.log(JSON.stringify(payload));
        fetch(this.apiUrl, {
          method: "POST",
          headers: {
            "Content-Type": "application/json"
          },
          body: JSON.stringify(payload)
        }).then((response) => {
          if (response.ok === false) {
            this.$emit("onShowToastNotification", "There was an error trying to upload your Motion Picture.");
            console.log(response);
            throw response;
          } else {
            return response.json();
          }
        }).then((data) => {
          data;
          const container = document.querySelector("#editStaticBackDrop");
          const modal = Modal.getInstance(container);
          modal.hide();
          this.nameValue = "",
          this.descValue = "",
          this.yearValue = "",
          console.log(this.$refs);
          this.$emit("onShowToastNotification", "Successfully Uploaded!");
        }).catch((error) => {
          this.$emit("onShowToastNotification", "There was an error trying to upload your Motion Picture.");
          console.log(error);
        }).finally(() => {
          console.log("end");
        });
      },
      deleteMotionPicture() {
        const container = document.querySelector("#editStaticBackDrop");
        const modal = Modal.getInstance(container);
        modal.hide();
        this.$emit("onClickDelete", this.motionPicture);
      }
    }
  };
</script>

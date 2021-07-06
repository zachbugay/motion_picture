<template>
  <div>

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
      <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'plus-circle']" />
      {{ buttonMessage }}
    </button>

    <!-- Modal -->
    <div class="modal fade"
      :class="[
        showModal ? 'show' : 'hide'
      ]"
      id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="staticBackdropLabel">{{ modalTitle }}</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
            <div class="modal-body">
                <name-input
                  inputLabel="Name"
                  id="nameInput"
                  @nameChange="nameChange"
                />
                <description-input
                  inputLabel="Description"
                  id="descriptionInput"
                  @descChange="descChange"
                />
                <year-input
                  inputLabel="Release Year"
                  id="yearInput"
                  @yearChange="yearChange"
                />
            </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
            <button @click="click" type="button" class="btn btn-primary">Add</button>
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

export default {
  components: { NameInput, DescriptionInput, YearInput },
    name: "AddMotionPictureModal",
    emits: [
      "showToastNotification"
    ],
    props: {
      "buttonMessage": String,
      "modalTitle": String,
      "apiUrl": String,
      "showAddModal": Boolean
    },
    data() {
      return {
        nameValue: "",
        descValue: "",
        yearValue: "",
        showModal: false
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
      click() {
        let payload = {
          "Name": this.nameValue,
          "Description": this.descValue,
          "ReleaseYear": parseInt(this.yearValue)
        };
        console.log(JSON.stringify(payload));
        fetch(this.apiUrl, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(payload)
        }).then((response) => {
          return response.json();
        }).then((data) =>  {
          console.log(data);
          this.$emit('showToastNotification', 'Successfully Uploaded!');
          this.showModal = false;
        }).catch((error) => {
          console.log(error);
        }).finally(() => {
          console.log('end');
        });
      }
    }
  };
</script>

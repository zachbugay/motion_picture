<template>
  <td class="col"> {{ displayNumber }} </td>
  <td class="col"> {{ name }} </td>
  <td class="col"> {{ releaseYear }} </td>
  <td class="col"> {{ description }} </td>
  <td class="col">
    <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'pen-square']" @click="editMotionPicture"
      data-bs-toggle="modal" data-bs-target="#editStaticBackDrop"
    />
    <font-awesome-icon class="fa fa-cog fa-fw" :icon="['fas', 'copy']" @click="copyMotionPicture" />
  </td>
</template>

<script>
export default {
  name: "MotionPictures",
  emits: [
    "onShowToastNotification"
  ],
  props: {
    id: Number,
    displayNumber: Number,
    name: String,
    releaseYear: String,
    description: String,
    apiUrl: String
  },
  methods: {
    copyMotionPicture() {
      let payload = {
        "Name": this.name,
        "Description": this.description,
        "ReleaseYear": parseInt(this.releaseYear)
      };
      fetch(this.apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
      }).then((response) => {
        return response.json();
      }).then((data) =>  {
        console.log(data);
        this.$emit("onShowToastNotification", `Successfully Copied: ${data.name}!`);
      }).catch((error) => {
        console.log(error);
      });
    },
    editMotionPicture() {
      this.$emit("onEditClick", {
        id: this.id,
        Name: this.name,
        Description: this.description,
        Year: this.releaseYear
      });
    },
  }
}
</script>

<style scoped>
  .fa:hover {
    cursor: pointer;
    transform: scale(1.5);
  }
</style>

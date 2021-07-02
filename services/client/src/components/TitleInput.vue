<template>
  <div class="form-group col-md-4">
    <label for="titleInput" class="form-label">{{ inputLabel }}</label>
    <div class="input-group flex-wrap">
      <input
        id="{{ id }}"
        v-model="name"
        placeholder="Name"
        class="form-control"
        type="text"
        :class="[
          valid === '' ? '' :
            valid ? 'is-valid' : 'is-invalid',
        ]"
        required
      />
      <div v-if="valid" class="valid-feedback">Looks good!</div>
      <div v-if="!valid" class="invalid-feedback"> {{ errorMessages.name }}</div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "nameInput",
    props: {
      inputLabel: String,
      id: String,
    },
    data() {
      return {
        name: "",
        errorMessages: [],
        valid: "",
      }
    },
    watch: {
      name(value) {
        this.name = value;
        this.validatename(value);
      }
    },
    methods: {
      validatename(value) {
        if (value === '' || value === null || value.value === 0) {
          this.errorMessages["name"] = "A name is required!";
          this.valid = false;
        } else if (value.length > 50) {
          this.errorMessages["name"] = "Your name must not exceed 50 characters.";
          this.valid = false;
        }
        else {
          this.errorMessages["name"] = "";
          this.valid = true;
        }
      }
    }
  };
</script>

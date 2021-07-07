<template>
  <div class="row mb-3">
    <!-- <label :for=id class="col-lg col-form-label">{{ inputLabel }}</label> -->
    <div class="col-sm">
      <input
        :id=id
        v-model="name"
        placeholder="Name"
        class="form-control"
        type="text"
        :class="[
          name === '' ? 'no-validate' : (
          valid === '' ? '' :
            valid ? 'is-valid' : 'is-invalid'),
        ]"
        required
        @change="$emit('nameChange', $event.target.value)"
        data-cy="name-input"
      />
      <div v-if="valid" class="valid-feedback">Looks good!</div>
      <div v-if="!valid" class="invalid-feedback"> {{ errorMessages.name }}</div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "nameInput",
    emits: [
      "nameChange",
      "nameIsValid"
    ],
    props: {
      inputLabel: String,
      defaultValue: String,
      id: String,
    },
    data() {
      return {
        name: this.defaultValue,
        errorMessages: [],
        valid: "",
      }
    },
    watch: {
      name(value) {
        this.name = value;
        this.validateName(value);
      },
      defaultValue(value) {
        this.name = value;
        this.validateName(value);
      }
    },
    methods: {
      validateName(value) {
        if (value === '' || value === null || value.value === 0) {
          this.errorMessages["name"] = "A name is required!";
          this.valid = false;
          this.$emit("nameIsValid", this.valid);
        } else if (value.length > 50) {
          this.errorMessages["name"] = "Your name must not exceed 50 characters.";
          this.valid = false;
          this.$emit("nameIsValid", this.valid);
        }
        else {
          this.errorMessages["name"] = "";
          this.valid = true;
          this.$emit("nameIsValid", this.valid);
        }
      }
    }
  };
</script>

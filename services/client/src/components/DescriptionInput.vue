<template>
  <div class="row mb-3">
      <!-- <label :for=id class="col-sm-5 col-form-label">{{ inputLabel }}</label> -->
      <div class="col-sm">
        <textarea
          :id=id
          v-model="description"
          placeholder="Description"
          class="form-control"
          type="text"
          :class="[
            description === '' ? 'no-validate' : (
            valid === '' ? '' :
              valid ? 'is-valid' : 'is-invalid'),
          ]"
          required
          rows="10"
          @change="$emit('descChange', $event.target.value)"
          data-cy="desc-input"
        />
        <div v-if="valid" class="valid-feedback">Looks good!</div>
        <div v-if="!valid" class="invalid-feedback"> {{ errorMessages.description }}</div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "descriptionInput",
    emits: [
      "descChange"
    ],
    props: {
      inputLabel: String,
      defaultValue: String,
      id: String,
    },
    data() {
      return {
        description: "",
        errorMessages: [],
        valid: "",
      }
    },
    watch: {
      description(value) {
        this.description = value;
        this.validateDescription(value);
      },
      defaultValue(value) {
        this.description = value;
        this.validateDescription(value);
      }
    },
    methods: {
      validateDescription(value) {
        if (value.length > 500) {
          this.errorMessages["description"] = "Your description must not exceed 500 characters.";
          this.valid = false;
          this.$emit("descIsValid", this.valid = true);
        } else {
            this.errorMessages["description"] = "";
            this.valid = true;
            this.$emit("descIsValid", this.valid = true);
        }
      }
    }
  };
</script>

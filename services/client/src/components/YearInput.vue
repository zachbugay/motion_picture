<template>
  <div class="row mb-3">
    <!-- <label :for=id class="col-sm col-form-label">{{ inputLabel }}</label> -->
    <div class="col-sm">
      <input
        :id=id
        v-model="year"
        placeholder="Release Year"
        class="form-control"
        type="number"
        :class="[
          year === '' ? 'no-validate' : (
          valid === '' ? '' :
            valid ? 'is-valid' : 'is-invalid'),
        ]"
        required
        @change="$emit('yearChange', $event.target.value)"
        data-cy="year-input"
      />
      <div v-if="valid" class="valid-feedback">Looks good!</div>
      <div v-if="!valid" class="invalid-feedback"> {{ errorMessages.year }}</div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "yearInput",
    emits: [
      "yearChange",
      "yearIsValid"
    ],
    props: {
      inputLabel: String,
      defaultValue: String,
      id: String,
    },
    data() {
      return {
        year: "",
        errorMessages: [],
        valid: "",
      }
    },
    watch: {
      year(value) {
        this.year = value;
        this.validateYear(value);
      },
      defaultValue(value) {
        this.year = value;
        this.validateYear(value);
      }
    },
    methods: {
      validateYear(value) {
        const regex = /\d{4}/g;
        if (value === '' || value === null || value.value === 0) {
          this.errorMessages["year"] = "A valid year is required!";
          this.valid = false;
          this.$emit("yearIsValid", this.valid);
        } else if (value.length !== 4 || !value.match(regex)) {
          this.errorMessages["year"] = "Year must be in YYYY format!";
          this.valid = false;
          this.$emit("yearIsValid", this.valid);
        }
        else {
          this.errorMessages["year"] = "";
          this.valid = true;
          this.$emit("yearIsValid", this.valid);
        }
      }
    }
  };
</script>

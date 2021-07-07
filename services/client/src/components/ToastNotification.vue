<template>
  <div class="position-fixed bottom-0 end-0 p-3" style="z-index: 11">
    <div id="liveToast" class="toast fade" role="alert" aria-live="assertive" aria-atomic="true"
      :class="[
        showToast ? 'show' : 'hide'
      ]"
    >
      <div class="toast-header">
        <svg class="bd-placeholder-img rounded me-2" width="20" height="20" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" preserveAspectRatio="xMidYMid slice" focusable="false"><rect width="100%" height="100%" fill="#007aff"></rect></svg>
        <strong class="me-auto">Motion Picture</strong>
        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"
          @click="clickedClose"
        ></button>
      </div>
      <div class="toast-body" data-cy="toast-message">
        {{ notificationMessage }}
      </div>
    </div>
  </div>
</template>

<script>
export default(
  {
  name: "ToastNotification",
  emits: [
    "onHideToast"
  ],
  props: {
    notificationMessage: String,
    showToast: Boolean
  },
  data() {
    return {
      undefined
    }
  },
  methods: {
    clickedClose() {
      console.log("Clicked Close");
      this.$emit("onHideToast");
    }
  }
})
</script>

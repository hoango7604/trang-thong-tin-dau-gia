<template>
  <div
    :class="{ 'sf-badge sf-product-card__badge': isBadge }"
    v-if="!isExpired"
  >
    {{ days }}d {{ hours }}h {{ minutes }}m {{ seconds }}s
  </div>
  <div :class="{ 'sf-badge sf-product-card__badge': isBadge }" v-else>
    Kết thúc
  </div>
</template>

<script>
export default {
  props: {
    endDate: {
      type: String,
    },

    isBadge: {
      type: Boolean,
      default: true,
    },
  },

  data() {
    return {
      days: "",
      hours: "",
      minutes: "",
      seconds: "",
      isExpired: false,
    };
  },

  created() {
    // Set the date we're counting down to
    let countDownDate = new Date(this.endDate).getTime();

    // Update the count down every 1 second
    let x = setInterval(() => {
      // Get today's date and time
      let now = new Date().getTime();

      // Find the distance between now and the count down date
      let distance = countDownDate - now;

      // Time calculations for days, hours, minutes and seconds
      this.days = Math.floor(distance / (1000 * 60 * 60 * 24));
      this.hours = Math.floor(
        (distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
      );
      this.minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
      this.seconds = Math.floor((distance % (1000 * 60)) / 1000);

      // If the count down is finished, write some text
      if (distance < 0) {
        this.isExpired = true;
        this.$emit("expired");
        clearInterval(x);
      }
    }, 1000);
  },
};
</script>

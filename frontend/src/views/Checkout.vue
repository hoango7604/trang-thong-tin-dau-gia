<template>
  <div class="row">
    <div class="col-12 col-md-7">
      <SfSteps v-model="active" :steps="steps" :can-go-back="canGoBack">
        <SfStep v-for="(step, key) in steps" :key="key" :name="step">
          <div
            style="
          display: flex;
          align-items: center;
          justify-content: center;
          height: 18.75rem;
          background-color: #f2f2f2;
        "
          >
            [#default slot content] {{ step }}
          </div>
        </SfStep>
      </SfSteps>
    </div>
    <div class="col-12 col-md-5"></div>
  </div>
</template>

<script>
import { SfSteps, SfInput } from "@storefront-ui/vue";
export default {
  components: {
    SfSteps,
    SfInput,
  },
  data() {
    return {
      active: 0,
      steps: ["Personal details", "Shipping", "Payment"],
      canGoBack: true,
    };
  },
};
</script>

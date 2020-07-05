<template>
  <div class="row">
    <div class="col-12 col-md-7">
      <SfSteps v-model="active" :can-go-back="canGoBack">
        <SfStep name="Thông tin">
          <SfInput v-model="form.name" label="Họ và tên" />
          <SfInput v-model="form.phone" label="Số điện thoại" />
          <SfInput v-model="form.address" label="Địa chỉ" />
          <SfButton @click="active++">
            <span class="mr-3">
              Thanh toán Paypal
            </span>
            <img :src="require('@/assets/icon/paypal.svg')" />
          </SfButton>
        </SfStep>
      </SfSteps>
    </div>
    <div class="col-12 col-md-5 sidebar">
      Sản phẩm ở đây
    </div>
  </div>
</template>

<script>
import { SfSteps, SfInput, SfButton, SfIcon } from "@storefront-ui/vue";
export default {
  components: {
    SfSteps,
    SfInput,
    SfButton,
    SfIcon,
  },
  data() {
    return {
      form: {
        name: "",
        phone: "",
        address: "",
      },
      active: 0,
      canGoBack: true,
    };
  },
};
</script>

<style scoped>
.sidebar {
  background: rgb(212, 209, 209);
}
</style>

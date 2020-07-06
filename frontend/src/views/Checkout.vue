<template>
  <div class="checkout-page">
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
      <div class="col-12 col-md-5 checkout__aside-order">
        <div class="text-center">
          <img
            src="https://firebasestorage.googleapis.com/v0/b/newagent-kgryfg.appspot.com/o/dongho3_2.jpg?alt=media&token=b1ddf338-1058-46d4-9b43-2435fbdcb4ee"
            alt="#"
            class="img-fluid w-50 mb-4"
          />
          <h2 class="mb-4">Rolex 2</h2>
        </div>
        <SfProperty
          class="sf-property--large sf-property--full-width"
          name="Giá đấu"
          :value="1000000 | formatCurrency"
        />
        <hr />
        <SfCharacteristic
          title="Safe"
          description="It carefully packaged with a personal touch"
          icon="info_shield"
          class="characteristics__item"
        />
        <SfCharacteristic
          title="Changed your mind?"
          description="Rest assured, we offer free returns within 30 days"
          icon="info_shield"
          class="characteristics__item"
        />
      </div>
    </div>
  </div>
</template>

<script>
import {
  SfSteps,
  SfInput,
  SfButton,
  SfIcon,
  SfProperty,
  SfCharacteristic,
} from "@storefront-ui/vue";

export default {
  components: {
    SfSteps,
    SfInput,
    SfButton,
    SfIcon,
    SfProperty,
    SfCharacteristic,
  },
  data() {
    return {
      form: {
        name: "",
        phone: "",
        address: "",
      },
      price: 1000000,
      active: 0,
      canGoBack: true,
    };
  },
};
</script>

<style scoped>
.checkout__aside-order {
  box-sizing: border-box;
  width: 100%;
  background: #f1f2f3;
  padding: 48px 64px;
}

.checkout-page {
  padding: 16px;
}
.characteristics__item {
  margin: 32px 0;
}
</style>

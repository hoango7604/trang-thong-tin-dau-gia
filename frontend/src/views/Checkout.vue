<template>
  <div class="checkout-page">
    <div class="row">
      <div class="col-12 col-md-8">
        <SfSteps v-model="active" :can-go-back="canGoBack">
          <SfStep name="Thông tin">
            <SfInput v-model="form.name" label="Họ và tên" />
            <SfInput v-model="form.phone" label="Số điện thoại" />
            <SfInput v-model="form.address" label="Địa chỉ" />
            <Paypal :payment="payment" />
          </SfStep>
        </SfSteps>
      </div>
      <div class="col-12 col-md-4 checkout__aside-order">
        <div
          v-if="!products.length"
          class="d-flex align-items-center w-100 h-100"
          style="font-weight: 100"
        >
          Chưa đấu giá thành công sản phẩm nào!
        </div>
        <!-- product card  -->
        <div
          v-else
          class="d-flex justify-content-start p-3"
          v-for="index in 5"
          :key="index"
        >
          <img
            src="https://firebasestorage.googleapis.com/v0/b/newagent-kgryfg.appspot.com/o/dongho3_2.jpg?alt=media&token=b1ddf338-1058-46d4-9b43-2435fbdcb4ee"
            alt="#"
            width="110"
            class="img-fluid mb-4"
          />
          <div class="ml-3">
            <h4 class="mb-4">Rolex 2</h4>
            {{ 1000000 | formatCurrency }}
          </div>
        </div>
        <!-- <hr /> -->
        <!-- <SfCharacteristic
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
        /> -->
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
import Paypal from "@/components/Paypal";

export default {
  components: {
    SfSteps,
    SfInput,
    SfButton,
    SfIcon,
    SfProperty,
    Paypal,
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
      products: [],
    };
  },

  computed: {
    payment() {
      return {
        description: "Payment by paypal",
        total: this.price,
        currency: "USD",
      };
    },
  },

  created() {
    this.$store
      .dispatch("common/getCartByUserId", {
        userId: this.$route.params.id,
      })
      .then((data) => {
        this.products = data;
        console.log(this.products);
      });
  },
};
</script>

<style scoped>
.checkout__aside-order {
  box-sizing: border-box;
  width: 100%;
  /* background: #f1f2f3; */
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
  padding: 48px 64px;
}

.checkout-page {
  padding: 16px;
}
.characteristics__item {
  margin: 32px 0;
}
</style>

<template>
  <div class="checkout-page">
    <div class="row">
      <div class="col-12 col-md-8">
        <SfSteps v-model="active" :can-go-back="canGoBack">
          <SfStep name="Thông tin">
            <SfInput v-model="form.name" label="Họ và tên" />
            <SfInput v-model="form.phone" label="Số điện thoại" />
            <SfInput v-model="form.address" label="Địa chỉ" />
            <Paypal :payment="payment" :products="products" :user="user" />
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
          v-for="(product, index) in products"
          :key="index"
        >
          <img
            :src="product.imageUrl"
            alt="#"
            width="110"
            class="img-fluid mb-4"
          />
          <div class="ml-3">
            <h4 class="mb-4">{{ product.name }}</h4>
            {{ product.currentPrice | formatCurrency }}
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
      totalPrice: 0,
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
        total: this.totalPrice / 20000,
        currency: "USD",
      };
    },
    user() {
      return {
        userId: JSON.parse(localStorage.getItem("user")).id,
        address: this.form.address,
      };
    },
  },

  created() {
    this.$store
      .dispatch("common/getCartByUserId", {
        userId: this.$route.params.id,
      })
      .then((data) => {
        this.products = data.filter((el) => !el.isPaid);
        let totalPrice = 0;
        this.products.forEach((el) => {
          totalPrice += el.currentPrice;
        });
        this.totalPrice = totalPrice;
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
